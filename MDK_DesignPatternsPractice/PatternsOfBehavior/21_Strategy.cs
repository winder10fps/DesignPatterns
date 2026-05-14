namespace MDK_DesignPatternsPractice.PatternsOfBehavior
{
    public interface IRouteStrategy
    {
        void BuildRoute(string start, string end);
    }

    public class CarRoute : IRouteStrategy
    {
        public void BuildRoute(string start, string end)
        {
            Console.WriteLine($"Маршрут на машине от {start} до {end}");
        }
    }
    
    public class WalkingRoute : IRouteStrategy
    {
        public void BuildRoute(string start, string end)
        {
            Console.WriteLine($"Маршрут на пешком от {start} до {end}");
        }
    }
    
    public class PublicTransportRoute : IRouteStrategy
    {
        public void BuildRoute(string start, string end)
        {
            Console.WriteLine($"Маршрут на общественном транспорте от {start} до {end}");
        }
    }

    // context
    public class Navigator
    {
        private IRouteStrategy? _strategy;
        public void SetStrategy( IRouteStrategy strategy ) => _strategy = strategy;
        public void BuildRoute(string start, string end) => _strategy!.BuildRoute(start, end);
    }
}
