using DIPS.FastTrak.Models;
using DIPS.FastTrak.UI;
using System.Diagnostics;

namespace DIPS.FastTrak.Services;

public interface IDrugsService
{
    List<DrugTreatment>? DrugTreatments { get; }
}

public class DrugsService : IDrugsService, ISearchProvider
{
    #region Private fields

    StudyCase? _activeStudyCase;

    #endregion

    #region Constructors

    public DrugsService(IPopulationsService populationsService, IGlobalSearch globalSearch)
    {
        populationsService.ActiveStudyCaseChanged += OnActiveCaseChanged;
        globalSearch.Add(this);
    }

    #endregion
    public List<DrugTreatment> DrugTreatments { get; private set; } = [];

    private void OnActiveCaseChanged(StudyCase? studyCase)
    {
        _activeStudyCase = studyCase;
        DrugTreatments = GetDrugTreatments(studyCase);
    }

    private List<DrugTreatment> GetDrugTreatments(StudyCase? studyCase)
    {
        List<DrugTreatment> list = [];
        if (studyCase != null)
        {
            switch (studyCase.PersonId)
            {
                case 1:
                    list.Add(new DrugTreatment(searchProvider: this, drugName: "Marevan"));
                    list.Add(new DrugTreatment(searchProvider: this, drugName: "Burinex"));
                    list.Add(new DrugTreatment(searchProvider: this, drugName: "Levaxin"));
                    break;
                case 2:
                    list.Add(new DrugTreatment(searchProvider: this, drugName: "Zocor"));
                    break;
            }
        }
        return list;
    }

    public async Task<IList<ISearchResult>> SearchAsync(string search)
    {
        List<ISearchResult> results = [];
        if (_activeStudyCase != null)
        {
            return await Task.FromResult(DrugTreatments.Where(dt => dt.Match(search)).Cast<ISearchResult>().ToList());
        }
        return results;
    }

    public void Execute(ISearchResult result)
    {
        throw new NotImplementedException();
    }
}
