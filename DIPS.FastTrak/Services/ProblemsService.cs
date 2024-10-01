using DIPS.FastTrak.Models;

namespace DIPS.FastTrak.Services
{
    public interface IProblemsService
    {

    }

    public class ProblemsService : IProblemsService
    {
        #region Private fields

        readonly IList<Problem> _allProblems;

        #endregion

        public ProblemsService()
        {
            _allProblems = [];                
        }
    }
}
