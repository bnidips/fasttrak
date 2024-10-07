using DIPS.FastTrak.UI;

namespace DIPS.FastTrak.Services;

public delegate void ExecutedHandler();

public interface IGlobalSearch
{
    void Add(ISearchProvider provider);
    Task SearchAsync(string value);
    IList<ISearchResult> SearchResults { get; }
    Task InvokeAsync(ISearchResult searchResult);

    event ExecutedHandler? Executed;
}

public class GlobalSearch : IGlobalSearch
{
    public event ExecutedHandler? Executed;

    readonly List<ISearchProvider> _providers = [];

    List<ISearchResult> _searchResults = [];

    public IList<ISearchResult> SearchResults => _searchResults;

    public void Add(ISearchProvider provider) => _providers.Add(provider);

    public async Task InvokeAsync(ISearchResult searchResult)
    {
        searchResult.Provider.Execute(searchResult);
        Executed?.Invoke();
    }

    public async Task SearchAsync(string search)
    {
        var tasks = _providers.Select(provider => provider.SearchAsync(search));

        var results = await Task.WhenAll(tasks);

        _searchResults = results.SelectMany(z => z).ToList();
    }
}
