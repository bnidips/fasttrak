namespace DIPS.FastTrak.UI;

public interface ISearchProvider
{
    Task<IList<ISearchResult>> SearchAsync(string search);
}