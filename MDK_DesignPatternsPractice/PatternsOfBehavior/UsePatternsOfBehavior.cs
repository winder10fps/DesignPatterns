namespace MDK_DesignPatternsPractice.PatternsOfBehavior
{
    /// <summary>
    /// <b>Поведенческие паттерны (Behavioral Patterns)</b>
    /// <para/>
    /// Решают задачи эффективного распределения обязанностей между объектами, инкапсуляции алгоритмов и управления потоком управления на уровне взаимодействия объектов.
    /// <para/>
    /// <b>Ключевой принцип:</b> работают не с «чем» (структура, создание), а с «как» — как объекты взаимодействуют.
    /// </summary>
    public static class UsePatternsOfBehavior
    {
        /// <summary>
        /// <para><b>Цепочка обязанностей (Chain of Responsibility)</b></para>
        /// <para>Позволяет передавать запрос последовательно по цепочке обработчиков, пока один из них не обработает запрос.</para>
        /// <para/>
        /// <b>Когда применять:</b>
        /// <br/>1. Запрос должен обрабатываться несколькими объектами в неизвестном порядке
        /// <br/>2. Нужно уменьшить связанность между отправителем и получателем запроса
        /// <br/>3. Обработчики могут быть динамически добавлены или изменены во время выполнения
        /// <para/>
        /// <b>Пример из реальной жизни:</b> Система техподдержки — запрос проходит: Робот-помощник → Оператор первой линии → Инженер → Руководитель. Каждый может обработать запрос или передать дальше.
        /// </summary>
        public static void ChainOfResponsibility()
        {
            SupportHandler basic = new BasicSupport();
            SupportHandler senior = new SeniorSupport();
            SupportHandler manager = new ManagerSupport();

            basic.SetNext(senior);
            senior.SetNext(manager);

            basic.Handle(SupportLevels.Basic);
            basic.Handle(SupportLevels.Senior);
            basic.Handle(SupportLevels.Manager);
            basic.Handle(SupportLevels.Manager + 1);
        }

        /// <summary>
        /// <para><b>Команда (Command)</b></para>
        /// <para>Превращает запрос в объект, позволяя передавать его, ставить в очередь, логировать и поддерживать отмену.</para>
        /// <para/>
        /// <b>Когда применять:</b>
        /// <br/>1. Нужно параметризовать объекты действиями (разные команды для разных кнопок)
        /// <br/>2. Нужна поддержка отмены/повтора (Undo/Redo) в редакторах, играх, приложениях
        /// <br/>3. Нужно ставить запросы в очередь, логировать их или отправлять по сети
        /// <para/>
        /// <b>Пример из реальной жизни:</b> Заказ в ресторане — официант берёт заказ (команду), повар выполняет, а при отмене клиент может отказаться.
        /// </summary>
        public static void Command()
        {
            var redactor = new Redactor();
            var insert = new InsertTextCommand(redactor);
            var delete = new DeleteTextCommand(redactor);
            var remote = new RemoteControl();

            remote.ExecuteCommand(insert);
            Console.WriteLine(redactor.Text);
            remote.ExecuteCommand(delete);
            Console.WriteLine(redactor.Text);
            remote.ExecuteCommand(delete);
            Console.WriteLine(redactor.Text);
            remote.Undo();
            Console.WriteLine(redactor.Text);
        }

        /// <summary>
        /// <para><b>Интерпретатор (Interpreter)</b></para>
        /// <para>Определяет грамматику языка и интерпретирует предложения на этом языке.</para>
        /// <para/>
        /// <b>Когда применять:</b>
        /// <br/>1. Грамматика простая и небольшая (не требует сложного парсера)
        /// <br/>2. Нужно часто интерпретировать однотипные выражения (запросы, команды, формулы)
        /// <br/>3. Грамматика легко разбивается на абстрактное синтаксическое дерево (AST)
        /// <para/>
        /// <b>Примеры использования:</b> SQL парсер, калькулятор формул, интерпретатор регулярных выражений, обработчик логов, DSL (предметно-ориентированные языки)
        /// </summary>
        public static void Interpreter()
        {
            IExpression expr = new AddExpression(
                new NumberExpression(5),
                new NumberExpression(3),
                new NumberExpression(2)
            );
            Console.WriteLine(expr.Interpret());
        }

        /// <summary>
        /// <para><b>Итератор (Iterator)</b></para>
        /// <para>Предоставляет способ последовательного доступа к элементам коллекции без раскрытия её внутренней структуры.</para>
        /// <para/>
        /// <b>Когда применять:</b>
        /// <br/>1. Нужно обойти коллекцию без раскрытия её внутреннего устройства (массив, список, дерево, граф)
        /// <br/>2. Нужна поддержка разных вариантов обхода (прямой, обратный, по условию, по уровням дерева)
        /// <br/>3. Нужно одновременно выполнять несколько обходов одной коллекции (независимые итераторы)
        /// <br/>4. Хочется унифицировать способ обхода для разных типов коллекций
        /// <para/>
        /// <b>Пример из реальной жизни:</b> Пульт управления музыкой — кнопки "Далее" и "Назад" перемещают по плейлисту, не раскрывая как треки хранятся (список, файлы, стриминг).
        /// </summary>
        public static void Iterator()
        {
            var playlist = new Playlist();
            playlist.Add("track1");
            playlist.Add("track2");
            playlist.Add("track3");
            playlist.Add("track4");
            playlist.Add("track5");

            IIterator<string> iterator = playlist.CreateIterator();

            Console.WriteLine(iterator.Change(0)); 
            Console.WriteLine(iterator.Next());
            Console.WriteLine(iterator.Next());
            Console.WriteLine(iterator.Next());
            Console.WriteLine(iterator.Next());
            Console.WriteLine(iterator.Previous());
            Console.WriteLine(iterator.Previous());

        }
    }
}
