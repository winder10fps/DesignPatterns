namespace MDK_DesignPatternsPractice.GenerativePatterns
{
    // продукт
    public class Pizza
    {
        public enum Doughs { Thick, Thin }
        public enum Sauces { Caesar, Sour, Barbecue }
        public enum Fillings { Cheese, Mashrooms, Pepperoni }
        public enum Sizes { Small, Medium, Big }


        public Doughs Dough { get; set; }
        public Sauces Sauce { get; set; }
        public Fillings Filling { get; set; }
        public Sizes Size { get; set; }

        public void Display() => Console.WriteLine($"Инфо о пицце:\n" +
            $"Тесто: {Dough}\n" +
            $"Соус: {Sauce}\n" +
            $"Начинка: {Filling}\n" +
            $"Размер: {Size}");
    }


    // фбстрактный строитель
    public interface IPizzaBuilder
    {
        void SetDough(Pizza.Doughs dough);
        void SetSause(Pizza.Sauces sause);
        void SetFilling(Pizza.Fillings filling);
        void SetSize(Pizza.Sizes size);
        Pizza Build();
    }


    // конкретный строитель
    public class PizzaBuilder : IPizzaBuilder
    {
        private readonly Pizza _pizza = new();

        public void SetDough(Pizza.Doughs dough)
        {
            _pizza.Dough = dough;
        }

        public void SetSause(Pizza.Sauces sause)
        {
            _pizza.Sauce = sause;
        }

        public void SetFilling(Pizza.Fillings filling)
        {
            _pizza.Filling = filling;
        }

        public void SetSize(Pizza.Sizes size)
        {
            _pizza.Size = size;
        }

        public Pizza Build()
        {
            // можно валидацию
            return _pizza;
        }
    }
}
