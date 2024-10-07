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

public class DrugTreatment(ISearchProvider searchProvider, string drugName) : ISearchResult
{
    public int TreatId { get; set; }
    public TreatType TreatType { get; set; }
    public string DrugName { get; set; } = drugName;

    public Action<ISearchProvider>? Action => throw new NotImplementedException();

    public ISearchProvider Provider => searchProvider;

    public string SearchIcon => "person.svg";

    public string SearchTitle => DrugName;

    public bool Match(string search)
    {
        return DrugName.Contains(search, StringComparison.CurrentCultureIgnoreCase);
    }
}
