using DIPS.FastTrak.Services;
using DIPS.FastTrak.UI;

namespace DIPS.FastTrak.Models
{
    public interface IFilter
    {
        bool Match(string filter);
    }

    public class StudyCase(ISearchProvider searchProvider) : Person, IFilter, ISearchResult
    {
        public int StudyCaseId { get; set; }

        #region ISearchResult

        public Action<ISearchProvider>? Action { get; set; }

        public string SearchIcon => "person.svg";

        public string SearchTitle => FullName ?? "";

        public ISearchProvider Provider { get; set; } = searchProvider;

        public bool Match(string filter)
        {
            return FullName?.Contains(filter, StringComparison.CurrentCultureIgnoreCase) ?? false;
        }

        #endregion
    }
}