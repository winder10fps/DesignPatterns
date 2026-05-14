namespace MDK_DesignPatternsPractice.PatternsOfBehavior
{
    public class Memento(string state)
    {
        public string State { get; } = state;
    }


    public class Editor
    {
        public string Text { get; set; } = string.Empty;
        public Memento Save() => new(Text);
        public void Restore(Memento memento) => Text = memento.State;
    }


    public class History
    {
        private Stack<Memento> _history = new();
        public void Push(Memento m) => _history.Push(m);
        public Memento Pop() => _history.Pop();
    }
}
