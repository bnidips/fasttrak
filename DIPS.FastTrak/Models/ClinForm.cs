namespace DIPS.FastTrak.Models;

public enum ClinFormStatus
{
    Started,
    Complete,
    Signed        
}

public class ClinForm(MetaForm metaForm, int clinFormId)
{
    public bool Archived { get; set; }
    public int ClinFormId { get; set; } = clinFormId;
    public DateTime CreatedAt { get; set; }
    public MetaForm MetaForm { get; set; } = metaForm;
    public ClinFormStatus Status { get; set; } = ClinFormStatus.Started;
}