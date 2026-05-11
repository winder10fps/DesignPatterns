using System;
using System.Collections.Generic;
using System.Text;

namespace MDK_DesignPatternsPractice.GenerativePatterns
{
    class Loger
    {
        // хранит единственный обьект
        private static Loger? _loger;

        // приватный конструктор, чтоыб из вне нельзя было создать обьект
        private Loger()
        {
            Console.WriteLine("Создан логгер");
        }

        // метод из которого получение логгера из вне
        public static Loger GetLoger()
        {
            // если логгера нет то создать новый
            _loger ??= new Loger();
            return _loger;
        }

        // обычный метод логгера
        public void Log(string message)
        {
            Console.WriteLine($"+ {message} | файл logs.l");
        }
    }
}
