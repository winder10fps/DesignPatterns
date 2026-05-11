namespace MDK_DesignPatternsPractice.StructuralPatterns
{
    public class LegacyRectangle
    {
        private int _x1;
        private int _y1;
        private int _x2;
        private int _y2;

        public void DrawLegacy(int x1, int y1, int x2, int y2)
        {
            _x1 = x1;
            _y1 = y1;
            _x2 = x2;
            _y2 = y2;

            Console.WriteLine($"Рисую прямоугольник в старом формате:");
            Console.WriteLine($"  Левый верхний угол: ({_x1}, {_y1})");
            Console.WriteLine($"  Правый нижний угол: ({_x2}, {_y2})");
            Console.WriteLine($"  Ширина: {_x2 - _x1}, Высота: {_y2 - _y1}");
        }
    }


    public interface IShape
    {
        void Draw(int x, int y, int width, int height);
    }

    public class RectangleAdapter(LegacyRectangle legacyRectangle) : IShape
    {
        private readonly LegacyRectangle _legacyRectangle = legacyRectangle;

        public void Draw(int x, int y, int width, int height)
        {
            var x2 = width + x;
            var y2 = height + y;
            _legacyRectangle.DrawLegacy(x, y, x2, y2);
        }
    }
}
