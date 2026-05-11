namespace MDK_DesignPatternsPractice.StructuralPatterns
{
    public interface ICoffee
    {
        string GetDescription();
        decimal GetCost();
    }


    public class SimpleCoffee : ICoffee
    {
        public string GetDescription() => "Coffee";
        public decimal GetCost() => 50;
    }

     
    public class CoffeeDecorator(ICoffee coffee) : ICoffee
    {
        protected ICoffee _coffee = coffee;
        public virtual string GetDescription() => _coffee.GetDescription();
        public virtual decimal GetCost() => _coffee.GetCost();
    }


    public class MilkDecorator(ICoffee coffee) : CoffeeDecorator(coffee)
    {
        public override string GetDescription() => _coffee.GetDescription() + ", milk";
        public override decimal GetCost() => _coffee.GetCost() + 10;
    }


    public class SugarDecorator(ICoffee coffee) : CoffeeDecorator(coffee)
    {
        public override string GetDescription() => _coffee.GetDescription() + ", sugar";
        public override decimal GetCost() => _coffee.GetCost() + 2;
    }


    public class CreamDecorator(ICoffee coffee) : CoffeeDecorator(coffee)
    {
        public override string GetDescription() => _coffee.GetDescription() + ", cream";
        public override decimal GetCost() => _coffee.GetCost() + 14;
    }
}
