namespace MDK_DesignPatternsPractice.PatternsOfBehavior
{
    public interface IVisitor
    {
        void Visit(Circle circle);
        void Visit(Rectangle rectangle);
    }


    // элементы, применяющие поситителя
    public interface IElement
    {
        void Accept(IVisitor visitor);
    }


    public class Circle : IElement
    {
        public string? Color { get; set; }
        public void Accept(IVisitor visitor) => visitor.Visit(this);
    }


    public class Rectangle : IElement
    {
        public string? Color { get; set; }
        public void Accept(IVisitor visitor) => visitor.Visit(this);
    }


    // посетители
    public class XMLExportVisitor : IVisitor
    {
        public void Visit(Circle circle) => Console.WriteLine($"Export {circle.Color} circle as XML");
        public void Visit(Rectangle rectangle) => Console.WriteLine($"Export {rectangle.Color} rectangle as XML");
    }


    public class JSONExportVisitor : IVisitor
    {
        public void Visit(Circle circle) => Console.WriteLine($"Export {circle.Color} circle as JSON");
        public void Visit(Rectangle rectangle) => Console.WriteLine($"Export {rectangle.Color} rectangle as JSON");
    }
}
