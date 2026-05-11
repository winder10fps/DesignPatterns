using System;
using System.Collections.Generic;
using System.Text;

namespace MDK_DesignPatternsPractice.StructuralPatterns
{
    ///<summary>
    /// <para><b>Структурные паттерны (Structural Patterns)</b></para>
    /// <para>Они нужны для того, чтобы строить устойчивые, гибкие и понятные связи между объектами и классами.</para>
    /// <para>Если кратко: они отвечают на вопрос «Как собрать объекты в более крупные структуры, сохраняя гибкость и переиспользуемость кода?»</para>
    /// <para/>
    /// <b>Решают задачи:</b>
    /// <br/>• Упрощение сложных систем
    /// <br/>• Адаптация несовместимых интерфейсов
    /// <br/>• Добавление новой функциональности без изменения кода
    /// <br/>• Управление памятью и производительностью
    /// <br/>• Сокрытие сложной композиции
    /// <para/>
    /// </summary>
    public static class UseStructuralPatterns
    {
        /// <summary>
        /// <para><b>Адаптер (Adapter)</b></para>
        /// <para>Преобразует интерфейс одного класса в интерфейс, ожидаемый клиентом, обеспечивая совместную работу несовместимых классов.</para>
        /// <para/>
        /// <b>Когда применять:</b>
        /// <br/>1. Хотите использовать существующий класс, но его интерфейс не подходит
        /// <br/>2. Нужно интегрировать стороннюю библиотеку без изменения её кода
        /// <para/>
        /// <b>Пример из реальной жизни:</b> Зарядка для телефона — адаптер между USB и розеткой
        /// </summary>
        public static void Adapter()
        {
            var legacyRectangle = new LegacyRectangle();
            legacyRectangle.DrawLegacy(10, 10, 100, 50);

            var shape = new RectangleAdapter(legacyRectangle);
            shape.Draw(10, 10, 90, 40);
        }

        /// <summary>
        /// <para><b>Мост (Bridge)</b></para>
        /// <para>Разделяет абстракцию и реализацию на независимые иерархии, позволяя изменять их независимо.</para>
        /// <para/>
        /// <b>Когда применять:</b>
        /// <br/>1. Нужно избежать взрывного роста числа классов при добавлении новых вариаций
        /// <br/>2. Абстракция и реализация могут изменяться независимо друг от друга
        /// <para/>
        /// <b>Пример из реальной жизни:</b> Пульт управления (абстракция) и разные устройства (реализация) — TV, радио, проектор.
        /// <br/>Можно добавить новый пульт или новое устройство, не меняя существующие классы.
        /// </summary>
        public static void Bridge()
        {
            IDevice tv = new TV();
            RemoteControl remote = new BasicRemote(tv);
            remote.PressPower();

            remote = new AdvancedRemote(tv);
            remote.PressPower();

            IDevice radio = new Radio();
            remote = new BasicRemote(radio);
            remote.PressPower();
        }

        /// <summary>
        /// <para><b>Компоновщик (Composite)</b></para>
        /// <para>Позволяет сгруппировать объекты в древовидную структуру для работы с отдельными объектами и их группами единообразно.</para>
        /// <para/>
        /// <b>Когда применять:</b>
        /// <br/>1. Древовидная структура (UI, файловая система, каталоги товаров)
        /// <br/>2. Нужно единообразно обрабатывать листья и контейнеры
        /// <para/>
        /// <b>Пример из реальной жизни:</b> Файловая система — папки (контейнеры) и файлы (листья)
        /// <br/>Можно выполнить действие (скопировать, удалить, показать размер) как для одного файла, так и для целой папки.
        /// </summary>
        public static void Composite()
        {
            var root = new Folder("root");

            var folder1 = new Folder("docs");
            folder1.Add(new File("resume.txt", 213));
            folder1.Add(new File("portfolio.docx",28));

            var folder2 = new Folder("games");
            folder2.Add(new File("cs2.exe", 1452));
            folder2.Add(new File("dota2.exe", 934));
            folder2.Add(new File("minecraft.exe", 1297));

            folder1.Add(folder2);

            root.Add(folder1);

            var file = new File("text.txt", 31);
            root.Add(file);
            file.Rename("newText.txt");
            root.Print();

            Console.WriteLine($"Вес: {root.GetSize()} байт");
        }

        /// <summary>
        /// <para><b>Декоратор (Decorator)</b></para>
        /// <para>Динамически добавляет объекту новые обязанности, оборачивая его в объекты-декораторы.</para>
        /// <para/>
        /// <b>Когда применять:</b>
        /// <br/>1. Нужно добавить обязанности объекту без наследования (чтобы избежать взрыва подклассов)
        /// <br/>2. Обязанности можно комбинировать в любом порядке
        /// <para/>
        /// <b>Пример из реальной жизни:</b> Кофе — можно добавить молоко, сахар, корицу, взбитые сливки в любом сочетании.
        /// <br/>Вместо создания 100500 подклассов (КофеСМолоком, КофеССахаром, КофеСМолокомИСахарами т.д.) — просто оборачиваем базовый объект декораторами.
        /// </summary>
        public static void Decorator()
        {
            ICoffee coffee = new SimpleCoffee();
            coffee = new MilkDecorator(coffee);
            coffee = new SugarDecorator(coffee);
            Console.WriteLine($"{coffee.GetDescription()} - {coffee.GetCost()}p");
        }

        /// <summary>
        /// <para><b>Фасад (Facade)</b></para>
        /// <para>Предоставляет унифицированный высокоуровневый интерфейс к сложной системе подсистем.</para>
        /// <para/>
        /// <b>Когда применять:</b>
        /// <br/>1. Сложная система с множеством классов — нужен простой интерфейс
        /// <br/>2. Хочется уменьшить связанность клиента с подсистемой
        /// <para/>
        /// <b>Пример из реальной жизни:</b> Кнопка "Заказать кофе" на кофемашине — за ней скрывается сложный процесс: смолоть зерна, нагреть воду, смешать, подать в чашку.
        /// </summary>
        public static void Facade()
        {
            var theatre = new HomeTheatreFacade();
            theatre.WatchMovie();
            theatre.EndMovie();
        }


        public static void Flyweight()
        {

        }


        public static void Proxy()
        {

        }
    }
}
