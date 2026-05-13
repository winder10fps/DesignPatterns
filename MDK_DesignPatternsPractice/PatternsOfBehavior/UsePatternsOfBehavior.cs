using System;
using System.Collections.Generic;
using System.Text;

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
    } 
}
