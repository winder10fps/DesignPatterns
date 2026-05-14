namespace MDK_DesignPatternsPractice.PatternsOfBehavior
{
    public interface IOrderState
    {
        void Next(Order order);
    }


    public class Order
    {
        private IOrderState _state;
        public Order() => _state = new NewOrderState();

        public void SetState(IOrderState state) => _state = state;
        public void Next() => _state.Next(this);
    }


    public class NewOrderState : IOrderState
    {
        public void Next(Order order)
        {
            Console.WriteLine("Новый заказ создан, оплатите");
            order.SetState(new PaidState());
        }
    }


    public class PaidState : IOrderState
    {
        public void Next(Order order)
        {
            Console.WriteLine("Заказ оплачен, ожидайте отправки");
            order.SetState(new ShippedState());
        }
    }
    

    public class ShippedState : IOrderState
    {
        public void Next(Order order)
        {
            Console.WriteLine("Заказ в пути");
            order.SetState(new DeliveredState());
        }
    }
    

    public class DeliveredState : IOrderState
    {
        public void Next(Order order)
        {
            Console.WriteLine("Заказ доставлен");
        }
    }
}
