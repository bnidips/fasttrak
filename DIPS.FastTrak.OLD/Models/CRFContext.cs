namespace DIPS.FastTrak.Models
{
    public class CRFContext : IObservable<IActiveCaseObserver>
    {
        /// <summary>
        /// Indicates currently active Person and Study.
        /// </summary>
        public StudyCase? ActiveStudyCase { get; private set; }

        public List<Alert> Alerts { get; set; } = new();

        #region IObservable<IActiveCaseObserver>

        public List<IActiveCaseObserver> Observers { get; } = new();

        #endregion

        public void ActivateStudyCase(StudyCase studyCase)
        {
            ActiveStudyCase = studyCase;
        }
    }
}
