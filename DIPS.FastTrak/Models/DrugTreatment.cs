using DIPS.FastTrak.UI;

namespace DIPS.FastTrak.Models;

public enum TreatType
{
    Undefined,
    AsNeeded,
    Cure,
    Regular,
    Weekly
}

public class DrugTreatment(ISearchProvider searchProvider, string drugName, string rxText, TreatType treatType) : ISearchResult
{
    public int TreatId { get; set; }

    public TreatType TreatType { get; set; } = treatType;

    public string DrugName { get; set; } = drugName;

    public string RxText { get; set; } = rxText;

    public Action<ISearchProvider>? Action => throw new NotImplementedException();

    public ISearchProvider Provider => searchProvider;

    public string SearchIcon => "pill.svg";

    public string SearchTitle => DrugName;

    public bool Match(string search)
    {
        return DrugName.Contains(search, StringComparison.CurrentCultureIgnoreCase);
    }
}
