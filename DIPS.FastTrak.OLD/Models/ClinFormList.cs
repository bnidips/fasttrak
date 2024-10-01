using System.Collections;

namespace DIPS.FastTrak.Models
{
    public class ClinFormList
    {
        const string Recent = "Nylig";
        const string LastWeek = "Forige uke";
        const string Older = "Eldre";

        private IEnumerable? _forms;

        public List<ClinForm> ClinForms { get; set; } = new List<ClinForm>();

        public bool IsGrouped { get; set; }

        public IEnumerable? GroupByDate()
        {
            DateTime today = DateTime.Today;
            DateTime thisWeekStart = today.AddDays(-(int)today.DayOfWeek);
            DateTime thisWeekEnd = thisWeekStart.AddDays(6);
            DateTime lastWeekStart = thisWeekStart.AddDays(-7);
            DateTime lastWeekEnd = thisWeekEnd.AddDays(-7);
            var groupedForms = ClinForms.GroupBy(form =>
            {
                if (form.EventTime >= thisWeekStart && form.EventTime <= thisWeekEnd)
                    return Recent;
                else if (form.EventTime >= lastWeekStart && form.EventTime <= lastWeekEnd)
                    return LastWeek;
                else
                    return Older;
            });
            return groupedForms;
        }
    }
}