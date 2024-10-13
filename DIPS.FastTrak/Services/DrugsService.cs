using DIPS.FastTrak.Models;
using DIPS.FastTrak.UI;

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
                    list.Add(new DrugTreatment(searchProvider: this, drugName: "Marevan", treatType: TreatType.Regular, rxText: "2 x 1"));
                    list.Add(new DrugTreatment(searchProvider: this, drugName: "Burinex", treatType: TreatType.AsNeeded, rxText: "2 x 1"));
                    list.Add(new DrugTreatment(searchProvider: this, drugName: "Levaxin", treatType: TreatType.Regular, rxText: "2 x 1"));
                    break;
                default:
                    list.Add(new DrugTreatment(searchProvider: this, drugName: "Zocor", treatType: TreatType.Regular, rxText: "2 x 1"));
                    list.Add(new DrugTreatment(searchProvider: this, drugName: "Keflex", treatType: TreatType.AsNeeded, rxText: "2 x 1"));
                    list.Add(new DrugTreatment(searchProvider: this, drugName: "Paralgin", treatType: TreatType.Regular, rxText: "2 x 1"));
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
        
    }
}
