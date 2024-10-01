namespace DIPS.FastTrak.Models
{
    public enum MetaAlertLevel
    {
        Normal,
        Information,
        Warning,
        Stop,
        Danger
    }

    public class Alert
    {
        public MetaAlertLevel Level { get; set; }   
        public string Text { get; set; } = "";
        public string Title { get; set; } = "";
    }
}
