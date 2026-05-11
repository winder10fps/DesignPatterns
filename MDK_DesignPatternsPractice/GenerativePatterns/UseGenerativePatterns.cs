namespace MDK_DesignPatternsPractice.GenerativePatterns
{
    /// <summary>
    /// <para>Позволяют сделать систему независимой от способа создания, композиции и представления объектов. Эти паттерны начинают играть более важную роль, когда система эволюционирует и начинает в большей степени зависеть от композиции объектов, чем от наследования классов.</para>
    /// <para>Для порождающих паттернов характерны два аспекта:</para>
    /// <para>1. Они инкапсулируют знания о конкретных класса, которые применяются в системе.</para>
    /// <para>2. Они скрывают подробности создания и компоновки экземпляров этих классов.</para>
    /// </summary>
    public static class UseGenerativePatterns
    {
        /// <summary>
        /// <para>1. Абстрактная фабрика (Abstract Factory)</para>
        /// <para>Паттерн, предоставляющий интерфейс для создания семейств связанных или зависимых объектов без указания их конкретных классов.</para>
        /// </summary>
        public static void AbstractFactory()
        {
            IGUIFactory factory;

            if (OperatingSystem.IsWindows())
            {
                factory = new WindowsGUIFactory();
            }

            else if (OperatingSystem.IsMacOS())
            {
                factory = new MacGUIFactory();
            }

            else
            {
                Console.WriteLine("У вас не Mac и не Windows!");
                return;
            }

            var client = new ComputerUser(factory);
            client.UseGUI();
        }

        /// <summary>
        /// <para>Строитель (Builder)</para>
        /// <para>Паттерн, отделяющий конструирование сложного объекта от его представления, позволяя в одном процессе создания получать разные представления.</para>
        /// </summary>
        public static void Builder()
        {
            PizzaBuilder builder = new();
            builder.SetDough(Pizza.Doughs.Thick);
            builder.SetSause(Pizza.Sauces.Sour);
            builder.SetFilling(Pizza.Fillings.Mashrooms);
            builder.SetSize(Pizza.Sizes.Medium);

            var pizza = builder.Build();
            pizza.Display();
        }

        /// <summary>
        /// <para>Фабричный метод (Factory Method)</para>
        /// <para>Паттерн, определяющий интерфейс для создания объекта, но позволяющий подклассам решать, какой класс инстанцировать.</para>
        /// </summary>
        public static void FactoryMethod()
        {
            Logistics logistics = new RoadLogistics();
            logistics.PlanDelivery();

            logistics = new SeaLogistics();
            logistics.PlanDelivery();
        }

        /// <summary>
        /// <para>Прототип (Prototype)</para>
        /// <para>Паттерн, создающий новые объекты путём клонирования существующего объекта (прототипа) вместо вызова конструктора.</para>
        /// </summary>
        public static void Prototype()
        {
            Shape ogCube = new("cube", "black", 23.2, 43.2);
            Shape clonedCube = (Shape)ogCube.Clone();
            clonedCube.Color = "green";
            ogCube.Display();
            clonedCube.Display();

            Shape ogRound = new("round", "red", 23.2, 43.2);
            Shape clonedRound = (Shape)ogRound.Clone();
            clonedRound.PositionX = 34.6;
            clonedRound.PositionY = 34.6;
            ogRound.Display();
            clonedRound.Display();
        }

        /// <summary>
        /// <para>Одиночка (Singleton)</para>
        /// <para>Паттерн, гарантирующий, что класс имеет только один экземпляр, и предоставляющий глобальную точку доступа к нему.</para>
        /// </summary>
        public static void Singleton()
        {
            Loger logger = Loger.GetLoger();
            logger.Log("lalala");

            Loger logger2 = Loger.GetLoger();
            logger2.Log("llllll");
        }
    }
}
