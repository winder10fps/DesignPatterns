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
    } 
}
