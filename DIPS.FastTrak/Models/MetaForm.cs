namespace DIPS.FastTrak.Models
{
    public class MetaForm(int formId, string formName, string formTitle)
    {
        public int FormId { get; set; } = formId;
        public string FormName { get; set; } = formName;
        public string FormTitle { get; set; } = formTitle;
    }
}
