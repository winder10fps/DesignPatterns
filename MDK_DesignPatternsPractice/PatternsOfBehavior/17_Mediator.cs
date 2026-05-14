namespace MDK_DesignPatternsPractice.PatternsOfBehavior
{
    public interface IChatMediator
    {
        void SendMessage(string message, User user);
        void AddUser(User user);
    }


    public abstract class User(string name, IChatMediator mediator)
    {
        protected IChatMediator _mediator = mediator;
        public string Name { get; } = name;

        public void Send(string message) => _mediator.SendMessage(message, this);
        public void Receive(string message) => Console.WriteLine($"{Name} получил: {message}");
    }


    public class ChatUser(string name, IChatMediator mediator) : User(name, mediator)
    {
    }


    public class ChatRoom : IChatMediator
    {
        private readonly List<User> _users = [];

        public void AddUser(User user) => _users.Add(user);

        public void SendMessage(string message, User sender)
        {
            foreach (var user in _users)
            {
                if (user != sender)
                    user.Receive(message);
            }
        }
    }
}
