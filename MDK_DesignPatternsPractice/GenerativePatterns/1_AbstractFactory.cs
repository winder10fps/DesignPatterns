namespace MDK_DesignPatternsPractice.GenerativePatterns
{
    // Абстрактные продукты
    public interface IButton
    {
        public string KeyCode { get; }
        public void Click();
    }

    public interface ICheckbox
    {
        public bool IsChecked { get; }
        public void Click();
    }


    // Конкретные продукты для windows
    public class WindowsButton(string keyCode) : IButton
    {
        public string KeyCode { get; } = keyCode;

        public void Click() => Console.WriteLine($"Нажата клавиша {KeyCode} на windows");
    }

    public class WindowsCheckbox : ICheckbox
    {
        public bool IsChecked { get; private set; }
        public void Click()
        {
            IsChecked = !IsChecked;
            Console.WriteLine($"Изменено состояние чекбокса на windows: {IsChecked}");
        }
    }


    // Конкретные продукты для mac
    public class MacButton(string keyCode) : IButton
    {
        public string KeyCode { get; } = keyCode;

        public void Click() => Console.WriteLine($"Нажата клавиша {KeyCode} на mac");
    }

    public class MacCheckbox : ICheckbox
    {
        public bool IsChecked { get; private set; }
        public void Click()
        {
            IsChecked = !IsChecked;
            Console.WriteLine($"Изменено состояние чекбокса на mac: {IsChecked}");
        }
    }


    // Абстрактная фабрика
    public interface IGUIFactory
    {
        IButton CreateSpecialButton();
        ICheckbox CreateCheckbox();
    }


    // Конкретные фабрики
    public class WindowsGUIFactory : IGUIFactory
    {
        public IButton CreateSpecialButton() => new WindowsButton("ctrl");
        public ICheckbox CreateCheckbox() => new WindowsCheckbox();
    }

    public class MacGUIFactory : IGUIFactory
    {
        public IButton CreateSpecialButton() => new MacButton("cmd");
        public ICheckbox CreateCheckbox() => new MacCheckbox();
    }


    // клиент
    public class ComputerUser(IGUIFactory factory)
    {
        private IButton SpecialButton { get; set; } = factory.CreateSpecialButton();
        private ICheckbox Checkbox { get; set; } = factory.CreateCheckbox();

        public void UseGUI()
        {
            SpecialButton.Click();
            Checkbox.Click();
        }
    }
}
