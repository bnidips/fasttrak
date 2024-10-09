using DIPS.FastTrak.Models;
using DIPS.FastTrak.UI;
using Microsoft.AspNetCore.Components;

namespace DIPS.FastTrak.Services;

public delegate void StudyCaseDelegate(StudyCase? studyCase);

public interface IPopulationsService
{
    event StudyCaseDelegate? ActiveStudyCaseChanged;
    IList<StudyCase> ActivePopulation { get; }

    /// <summary>
    /// StudyCases recently open
    /// </summary>
    IList<StudyCase> RecentStudyCases { get; }
    string StudyCasesFilter { get; set; }
    IList<StudyCase> FilterStudyCases(IList<StudyCase> studyCases, string filter);
    StudyCase? ActiveStudyCase { get; set; }
}

public class PopulationsService : IPopulationsService, ISearchProvider
{
    #region Private fields

    StudyCase? _activeStudyCase;

    string _studyCasesFilter = "";

    readonly NavigationManager _navigation;

    readonly IList<StudyCase> _allStudyCases;

    readonly List<StudyCase> _recentStudyCases = [];

    public event StudyCaseDelegate? ActiveStudyCaseChanged;

    #endregion

    public PopulationsService(IGlobalSearch search, NavigationManager navigation)
    {
        search.Add(this);
        _navigation = navigation;
        _allStudyCases = [
            new StudyCase(this) { PersonId = 3, FirstName = "Dina", LastName = "Ekeberg" },
            new StudyCase(this) { PersonId = 1, FirstName = "Line", LastName = "Danser" },
            new StudyCase(this) { PersonId = 2, FirstName = "Gry", LastName = "Telok" },
            new StudyCase(this) { PersonId = 4, FirstName = "Roland", LastName = "Gundersen" }
        ];
        ActivePopulation = [.. _allStudyCases];
    }

    public IList<StudyCase> ActivePopulation { get; private set; }

    public StudyCase? ActiveStudyCase
    {
        get => _activeStudyCase;
        set
        {
            if (_activeStudyCase != value)
            {
                _activeStudyCase = value;
                ActiveStudyCaseChanged?.Invoke(_activeStudyCase);
                if (_activeStudyCase != null && !_recentStudyCases.Contains(_activeStudyCase))
                {
                    _recentStudyCases.Add(_activeStudyCase);
                }
            }
        }
    }

    public string StudyCasesFilter
    {
        get => _studyCasesFilter;
        set
        {
            _studyCasesFilter = value;
            ActivePopulation = FilterStudyCases(_allStudyCases, _studyCasesFilter);
        }
    }

    public IList<StudyCase> RecentStudyCases => _recentStudyCases;

    public void Execute(ISearchResult result)
    {
        ActiveStudyCase = (StudyCase)result;
        _navigation.NavigateTo("PatientJournal");
    }

    public IList<StudyCase> FilterStudyCases(IList<StudyCase> studyCases, string filter)
    {
        return studyCases.Where(sc => sc.Match(filter)).ToList();
    }

    public async Task<IList<ISearchResult>> SearchAsync(string search)
    {
        return await Task.FromResult(_allStudyCases.Where(sc => sc.Match(search)).Cast<ISearchResult>().ToList());
    }
}