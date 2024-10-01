using DIPS.FastTrak.Models;
using DIPS.FastTrak.UI;

namespace DIPS.FastTrak.Services;

public delegate void StudyCaseDelegate(StudyCase? studyCase);

public interface IPopulationsService
{
    event StudyCaseDelegate? ActiveStudyCaseChanged;
    IList<StudyCase> ActivePopulation { get; }
    string StudyCasesFilter { get; set; }
    IList<StudyCase> FilterStudyCases(IList<StudyCase> studyCases, string filter);
    StudyCase? ActiveStudyCase { get; set; }
}

public class PopulationsService : IPopulationsService, ISearchProvider
{
    #region Private fields

    StudyCase? _activeStudyCase;

    string _studyCasesFilter = "";

    readonly IList<StudyCase> _allStudyCases;

    public event StudyCaseDelegate? ActiveStudyCaseChanged;

    #endregion

    public PopulationsService(IGlobalSearch search)
    {
        search.Add(this);
        _allStudyCases = [
            new StudyCase(this) { PersonId = 3, FirstName = "Dina", LastName = "Ekeberg" },
            new StudyCase(this){ PersonId = 1, FirstName = "Line", LastName = "Danser" },
            new StudyCase(this){ PersonId = 4, FirstName = "Gry", LastName = "Telok" },
            new StudyCase(this){ PersonId = 6, FirstName = "Roland", LastName = "Gundersen" }
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

    public IList<StudyCase> FilterStudyCases(IList<StudyCase> studyCases, string filter)
    {
        return studyCases.Where(sc => sc.Match(filter)).ToList();
    }

    public async Task<IList<ISearchResult>> SearchAsync(string search)
    {
        return await Task.FromResult(_allStudyCases.Where(sc => sc.Match(search)).Cast<ISearchResult>().ToList());
    }
}