using DIPS.FastTrak.Models;

namespace DIPS.FastTrak.Services
{
    public interface IClinFormsService
    {
        ClinForm? ActiveForm { get; set; }
        List<ClinForm> ClinForms { get; }
    }

    public class ClinFormsService : IClinFormsService
    {
        public ClinForm? ActiveForm { get; set; }

        public List<ClinForm> ClinForms { get; private set; } = [];

        public ClinFormsService()
        {
            ClinForms.Add(new ClinForm(new MetaForm(1307, "DIAPOL_INSULIN", "Insulinbehandling"), clinFormId: 12));
            ClinForms.Add(new ClinForm(new MetaForm(1430, "DIAPOL_MAIN", "Poliklinisk kontroll diabetes"), clinFormId: 16));
        }
    }
}
