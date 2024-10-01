namespace DIPS.FastTrak.Models
{
    public class MetaForm
    {
        public int FormId { get; set; } 
        public string FormName { get; set; }

        public string FormTitle { get;set; }

        public MetaForm(int formId, string formName, string formTitle)
        {
            FormName = formName;
            FormId = formId;
            FormTitle = formTitle;
        }
    }
}
