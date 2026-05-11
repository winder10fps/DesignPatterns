namespace MDK_DesignPatternsPractice.GenerativePatterns
{
    public interface IShapePrototype
    {
        IShapePrototype Clone();
    }

    public class Shape(string type, string color, double positionX, double positionY) : IShapePrototype
    {
        public string Type { get; } = type;
        public string Color { get; set; } = color;
        public double PositionX { get; set; } = positionX;
        public double PositionY { get; set; } = positionY;

        public IShapePrototype Clone()
        {
            return new Shape(Type, Color, PositionX, PositionY);
        }

        public void Display()
        {
            Console.WriteLine($"Type: {Type}, Color: {Color}, Position: {PositionX} {PositionY}");
        }
    }
}
