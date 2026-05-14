using static MDK_DesignPatternsPractice.GenerativePatterns.UseGenerativePatterns;
using static MDK_DesignPatternsPractice.StructuralPatterns.UseStructuralPatterns;
using static MDK_DesignPatternsPractice.PatternsOfBehavior.UsePatternsOfBehavior;

namespace MDK_DesignPatternsPractice
{
    internal class Program
    {
        static void Main()
        {
            Action[] methods = [
                AbstractFactory, Builder, FactoryMethod, Prototype, Singleton,
                Adapter, Bridge, Composite, Decorator, Facade, Flyweight, Proxy,
                ChainOfResponsibility, Command, Interpreter, Iterator, Mediator,
                Memento, Observer, State, Strategy, TemplateMethod, Visitor
            ];

            foreach (var method in methods)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n[{method.Method.Name}]");
                Console.ResetColor();
                method();
            }
        }
    }
}
