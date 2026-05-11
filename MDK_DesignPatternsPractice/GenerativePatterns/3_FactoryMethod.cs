namespace MDK_DesignPatternsPractice.GenerativePatterns
{
    // абстрактные продукт
    interface ITransport
    {
        void Deliver();
    }

    // конкретные продукты
    class Truck : ITransport
    {
        public void Deliver() => Console.WriteLine("Доставка по земле");
    }

    class Ship : ITransport
    {
        public void Deliver() => Console.WriteLine("Доставка по воде");
    }

    // создатель с фабричным методом
    abstract class Logistics
    {
        // фабричный метод
        public abstract ITransport CreateTransport();

        // бизнес метод, использующий продукт
        public void PlanDelivery()
        {
            var transport = CreateTransport();
            transport.Deliver();
        }
    }

    // конкретные создатели
    class RoadLogistics : Logistics
    {
        public override ITransport CreateTransport() => new Truck();
    }

    class SeaLogistics : Logistics
    {
        public override ITransport CreateTransport() => new Ship();
    }
}
