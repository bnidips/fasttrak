using DIPS.FastTrak.UI;

namespace DIPS.FastTrak.Services;

public interface IGlobalSearch
{
    void Add(ISearchProvider provider);
    Task SearchAsync(string value);
    IList<ISearchResult> SearchResults { get; }
    void Invoke(ISearchResult searchResult);
}

public class GlobalSearch : IGlobalSearch
{
    readonly List<ISearchProvider> _providers = [];

    List<ISearchResult> _searchResults = [];

    public IList<ISearchResult> SearchResults => _searchResults;

    public void Add(ISearchProvider provider) => _providers.Add(provider);

    public void Invoke(ISearchResult searchResult)
    {
        searchResult.Action?.Invoke(searchResult.Provider);
    }

    public async Task SearchAsync(string search)
    {
        var tasks = _providers.Select(provider => provider.SearchAsync(search));

        var results = await Task.WhenAll(tasks);

        _searchResults = results.SelectMany(z => z).ToList();
    }
}
