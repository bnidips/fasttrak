namespace DIPS.FastTrak.Models
{
    public class ClinForm
    {
        public ClinFormStatus Status { get; set; }
        public DateTime EventTime { get; set; }
        public MetaForm MetaForm { get; set; }
        public string FormTitle => MetaForm.FormTitle;

        public ClinForm(MetaForm metaForm, DateTime eventTime, ClinFormStatus status)
        {
            MetaForm = metaForm;
            EventTime = eventTime;
            Status = status;
        }
    }
}