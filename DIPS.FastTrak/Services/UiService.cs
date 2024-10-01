using DIPS.FastTrak.Models;
using DIPS.FastTrak.UI;

namespace DIPS.FastTrak.Services
{
    public interface IUiService : ISearchProvider
    {
        bool DarkMode { get; set; }
    }

    public class UiService : IUiService, ISearchProvider
    {
        #region Private fields

        readonly List<ISearchResult> _options = [];

        #endregion

        public UiService(IGlobalSearch globalSearch)
        {
            globalSearch.Add(this);
            _options = [
                new UiOption("Dark Mode", 
                p => ((IUiService)p).DarkMode = true,
                this)
            ];
        }

        #region Properties

        public bool DarkMode { get; set; }

        #endregion

        public async Task<IList<ISearchResult>> SearchAsync(string search)
        {
            return await Task.FromResult(_options.Where(o => o.Match(search)).Cast<ISearchResult>().ToList());
        }
    }
}
