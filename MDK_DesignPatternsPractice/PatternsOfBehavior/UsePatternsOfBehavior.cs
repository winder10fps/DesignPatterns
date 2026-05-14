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

        /// <summary>
        /// <para><b>Посредник (Mediator)</b></para>
        /// <para>Определяет объект, инкапсулирующий взаимодействие между множеством объектов, уменьшая связанность.</para>
        /// <para/>
        /// <b>Когда применять:</b>
        /// <br/>1. Много объектов связаны сложными взаимосвязями (паутина связей)
        /// <br/>2. Трудно переиспользовать объекты из-за их сильной связанности
        /// <br/>3. Нужно централизовать управление взаимодействиями
        /// <para/>
        /// <b>Пример из реальной жизни:</b> Диспетчерская вышка в аэропорту — самолёты не общаются друг с другом напрямую, все команды идут через диспетчера.
        /// </summary>
        public static void Mediator()
        {
            var chat = new ChatRoom();
            User user1 = new ChatUser("user1", chat);
            User user2 = new ChatUser("user2", chat);
            User user3 = new ChatUser("user3", chat);
            chat.AddUser(user1);
            chat.AddUser(user2);
            chat.AddUser(user3);
            user2.Send("Hi!");
        }

        /// <summary>
        /// <para><b>Снимок (Memento)</b></para>
        /// <para>Сохраняет и восстанавливает предыдущее состояние объекта, не раскрывая его внутренней структуры.</para>
        /// <para/>
        /// <b>Когда применять:</b>
        /// <br/>1. Нужно сохранять состояние для отмены операций (Ctrl+Z, Undo/Redo)
        /// <br/>2. Прямой доступ к внутреннему состоянию объекта опасен (нарушает инкапсуляцию)
        /// <br/>3. Нужно делать "чекпойнты" (сохранения) для возможного возврата к предыдущему состоянию
        /// <para/>
        /// <b>Пример из реальной жизни:</b> Сохранение игры — можно сохраниться, а потом загрузиться и продолжить с того же места.
        /// </summary>
        public static void Memento()
        {
            var editor = new Editor();
            var history = new History();

            editor.Text = "Version 1";
            history.Push(editor.Save());
            Console.WriteLine(editor.Text);

            editor.Text = "Version 2";
            Console.WriteLine(editor.Text);
            editor.Restore(history.Pop());
            Console.WriteLine(editor.Text);
        }

        /// <summary>
        /// <b>Наблюдатель (Observer)</b>
        /// <para/>
        /// Определяет зависимость "один ко многим", так что при изменении одного объекта все зависимые уведомляются автоматически.
        /// <para/>
        /// <b>Когда применять:</b>
        /// <br/>1. Изменение одного объекта требует изменения других
        /// <br/>2. Количество наблюдателей неизвестно и может меняться динамически
        /// <br/>3. Нужно реализовать механизм событий или подписок (pub-sub)
        /// <br/>4. Объект должен уведомлять других, но не должен зависеть от их конкретных типов
        /// <para/>
        /// <b>Пример из реальной жизни:</b> Подписка на YouTube — канал уведомляет всех подписчиков о выходе нового видео.
        /// </summary>
        public static void Observer()
        {
            var publisher = new NewsAgency();
            var s1 = new Subscriber("email@gmail.com");
            var s2 = new Subscriber("mail@gmail.com");

            publisher.Subscribe(s1);
            publisher.Subscribe(s2);
            publisher.PublishNews("News!");
        }

        /// <summary>
        /// <b>Состояние (State)</b>
        /// <para/>
        /// Позволяет объекту изменять своё поведение при изменении внутреннего состояния, создавая впечатление, что он изменил класс.
        /// <para/>
        /// <b>Когда применять:</b>
        /// <br/>1. Поведение объекта зависит от его состояния (например, документ: черновик, на модерации, опубликован)
        /// <br/>2. Много условных операторов (if/switch), проверяющих состояние объекта
        /// <br/>3. Код содержит дублирование логики для разных состояний
        /// <br/>4. Состояния могут меняться динамически во время выполнения
        /// <para/>
        /// <b>Пример из реальной жизни:</b> Кофемашина — в состоянии "Ожидание" она греет воду, в состоянии "Готово" наливает кофе, в состоянии "Нет воды" мигает лампочкой.
        /// </summary>
        public static void State()
        {
            var order = new Order();
            order.Next();
            order.Next();
            order.Next();
            order.Next();
        }

        /// <summary>
        /// <b>Стратегия (Strategy)</b>
        /// <para/>
        /// Определяет семейство алгоритмов, инкапсулирует их и делает их взаимозаменяемыми.
        /// <para/>
        /// <b>Когда применять:</b>
        /// <br/>1. Есть несколько способов сделать одно и то же (разные алгоритмы)
        /// <br/>2. Нужно избежать условных операторов (if/switch) при выборе алгоритма
        /// <br/>3. Алгоритмы могут меняться независимо от клиентского кода
        /// <br/>4. Нужно иметь возможность менять алгоритм во время выполнения
        /// <para/>
        /// <b>Пример из реальной жизни:</b> Навигатор — можно выбрать стратегию передвижения: пешком, на машине, на общественном транспорте. Маршрут строится по-разному, но интерфейс одинаковый.
        /// </summary>
        public static void Strategy()
        {
            var nav = new Navigator();
            nav.SetStrategy(new CarRoute());
            nav.BuildRoute("A", "B");
            nav.SetStrategy(new WalkingRoute());
            nav.BuildRoute("A", "B");

        }

        /// <summary>
        /// <b>Шаблонный метод (Template Method)</b>
        /// <para/>
        /// Определяет скелет алгоритма в методе, оставляя реализацию шагов подклассам.
        /// <para/>
        /// <b>Когда применять:</b>
        /// <br/>1. Алгоритм имеет неизменную структуру, но некоторые шаги могут меняться в подклассах
        /// <br/>2. Нужно избежать дублирования кода при реализации похожих алгоритмов
        /// <br/>3. Контроль над тем, какие шаги могут быть переопределены, а какие нет
        /// <br/>4. Хочется соблюсти принцип "Don't Repeat Yourself" (DRY)
        /// <para/>
        /// <b>Пример из реальной жизни:</b> Приготовление напитков в кофемашине — алгоритм одинаковый (вскипятить воду, заварить, налить в чашку), но шаг "заварить" разный для чая и кофе.
        /// </summary>
        public static void TemplateMethod()
        {
            ReportGenerator pdf = new PDF();
            pdf.Generate();
        }

        /// <summary>
        /// <b>Посетитель (Visitor)</b>
        /// <para/>
        /// Позволяет добавлять новые операции к объектам, не изменяя их классы.
        /// <para/>
        /// <b>Когда применять:</b>
        /// <br/>1. Нужно выполнить разные операции над объектами сложной структуры (дерево, граф)
        /// <br/>2. Классы редко меняются, но операции над ними добавляются часто
        /// <br/>3. Над объектами нужно выполнять разнородные операции (экспорт, расчёт, валидация)
        /// <br/>4. Логика операций не должна загромождать классы объектов
        /// <para/>
        /// <b>Пример из реальной жизни:</b> Налоговая проверка разных типов документов — документы не меняются, но проверяющие органы могут применять разные правила к одним и тем же документам.
        /// </summary>
        public static void Visitor()
        {
            var items = new List<IElement>
            {
                new Circle { Color = "red" },
                new Rectangle { Color = "blue" }
            };

            var xml = new XMLExportVisitor();
            var json = new JSONExportVisitor();

            foreach (var item in items)
            {
                item.Accept(xml);
                item.Accept(json);
            }
        }
    }
}
