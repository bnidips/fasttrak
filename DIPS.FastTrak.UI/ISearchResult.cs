namespace DIPS.FastTrak.UI;

public interface ISearchResult
{
    Action<ISearchProvider>? Action { get; }
    ISearchProvider Provider { get; }
    string SearchIcon { get; }
    string SearchTitle { get; }
    bool Match(string search);
}