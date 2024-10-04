using DIPS.FastTrak.Models;
using DIPS.FastTrak.UI;

namespace DIPS.FastTrak.Services
{
    public interface IUiService : ISearchProvider
    {
        bool DarkMode { get; set; }
        void ToggleDarkMode();
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
                new UiOption("Toggle Dark Mode", 
                p => ((IUiService)p).ToggleDarkMode(), this)
            ];
        }

        #region Properties

        public bool DarkMode { get; set; }


        #endregion
        public void ToggleDarkMode() => DarkMode = !DarkMode;


        public void Execute(ISearchResult result) => result.Action?.Invoke(this);

        public async Task<IList<ISearchResult>> SearchAsync(string search)
        {
            return await Task.FromResult(_options.Where(o => o.Match(search)).Cast<ISearchResult>().ToList());
        }
    }
}
