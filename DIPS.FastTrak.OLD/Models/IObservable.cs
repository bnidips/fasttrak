namespace DIPS.FastTrak.Models
{
    public interface IObservable<T> where T : IObserver
    {
        List<T> Observers { get; }

        void AddObserver(T observer)
        {
            Observers.Add(observer);
        }

        void NotifyObservers()
        {
            foreach (var observer in Observers)
            {
                observer.Notify();
            }
        }
    }
}
