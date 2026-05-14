namespace MDK_DesignPatternsPractice.PatternsOfBehavior
{
    public interface IObserver
    {
        void Update(string message);
    }


    public class NewsAgency
    {
        private readonly List<IObserver> _observers = [];
        public void Subscribe(IObserver observer) => _observers.Add(observer);
        public void Unsubscribe(IObserver observer) => _observers.Remove(observer);
        public void PublishNews(string news)
        {
            foreach (var observer in _observers)
                observer.Update(news);
        }
    }


    public class Subscriber(string email) : IObserver
    {
        public string Email { get; set; } = email;
        public void Update(string message) => Console.WriteLine($"Email {Email}: {message}");
    }
}
