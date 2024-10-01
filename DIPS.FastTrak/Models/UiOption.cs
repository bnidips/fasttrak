namespace DIPS.FastTrak.Models;

using DIPS.FastTrak.UI;

public class UiOption(string title, Action<ISearchProvider> action, ISearchProvider provider) : ISearchResult
{
    public Action<ISearchProvider>? Action { get; set; } = action;

    public string SearchTitle { get; set; } = title;

    public string SearchIcon => "settings.svg";

    public ISearchProvider Provider => provider;

    public bool Match(string search) => SearchTitle.Contains(search, StringComparison.CurrentCultureIgnoreCase);
}
