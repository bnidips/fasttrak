namespace DIPS.FastTrak.Models
{
    public interface IActiveCaseObserver : IObserver
    {
        void NotifyCaseActivated(IStudyCase studyCase);
    }
}
