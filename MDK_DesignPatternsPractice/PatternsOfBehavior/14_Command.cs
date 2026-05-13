using System.Text;

namespace MDK_DesignPatternsPractice.PatternsOfBehavior
{

    public interface ICommand
    {
        void Execute();
        void Undo();
    }


    public class Redactor
    {
        public StringBuilder Text { get; private set; } = new();

        public void InsertText(string text) => Text.Append(text);

        public void DeleteText(int length)
        {
            if (length > Text.Length) length = Text.Length;
            Text.Remove(Text.Length - length, length);
        }

        public void Display() => Console.WriteLine($"Текущий текст: \"{Text}\"");
    }


    public class InsertTextCommand(Redactor redactor) : ICommand
    {
        private readonly Redactor _redactor = redactor;
        private string _text = string.Empty;  
        private bool _executed;

        public void Execute()
        {
            Console.Write("Введите текст для вставки: ");
            var text = Console.ReadLine();
            if (string.IsNullOrEmpty(text))
            {
                Console.WriteLine("Вы не ввели текст!");
                return;
            }
            _text = text;
            _redactor.InsertText(_text);
            _executed = true;
        }

        public void Undo()
        {
            if (_executed)
                _redactor.DeleteText(_text.Length);
        }
    }


    public class DeleteTextCommand(Redactor redactor) : ICommand
    {
        private readonly Redactor _redactor = redactor;
        private string _deletedText = string.Empty;
        private bool _executed;

        /// <summary>
        /// Удалит последнюю букву в тексте
        /// </summary>
        public void Execute()
        {
            if (_redactor.Text.Length == 0)
            {
                Console.WriteLine("Нечего удалять!");
                return;
            }

            _deletedText = _redactor.Text[^1].ToString();
            _redactor.DeleteText(1);
            _executed = true;
        }

        public void Undo()
        {
            if (_executed)
                _redactor.InsertText(_deletedText);
        }
    }


    public class RemoteControl
    {
        private readonly Stack<ICommand> _history = new();

        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
            _history.Push(command);
        }

        public void Undo()
        {
            if (_history.Count == 0)
            {
                return;
            }

            var command = _history.Pop();
            command.Undo();
        }
    }
}

