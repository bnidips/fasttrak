﻿using DIPS.FastTrak.Models;

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

        public ClinFormsService(IPopulationsService populationsService)
        {
            populationsService.ActiveStudyCaseChanged += OnActiveCaseChanged;
        }

        private void OnActiveCaseChanged(StudyCase? studyCase)
        {
            ClinForms.Clear();
            if (studyCase != null)
            {
                ClinForms.Add(new ClinForm(new MetaForm(1307, "DIAPOL_INSULIN", "Insulinbehandling"), clinFormId: 12) { CreatedAt = DateTime.Today });
                ClinForms.Add(new ClinForm(new MetaForm(1430, "DIAPOL_MAIN", "Poliklinisk kontroll diabetes"), clinFormId: 16) { CreatedAt = DateTime.Today.AddDays(-1) });
                ClinForms.Add(new ClinForm(new MetaForm(1226, "DiaEpicrise", "Epikrise diabetes"), clinFormId: 18) { CreatedAt = DateTime.Today.AddDays(-3) });
            }
        }
    }
}
