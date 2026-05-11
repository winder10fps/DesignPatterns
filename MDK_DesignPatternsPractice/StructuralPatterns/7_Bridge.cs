namespace MDK_DesignPatternsPractice.StructuralPatterns
{
    public interface IDevice
    {
        void TurnOn();
        void TurnOff();
    }

    public class TV : IDevice
    {
        public void TurnOn() => Console.WriteLine("TV On");
        public void TurnOff() => Console.WriteLine("TV Off");
    }

    public class Radio : IDevice
    {
        public void TurnOn() => Console.WriteLine("Radio On");
        public void TurnOff() => Console.WriteLine("Radio Off");
    }

    // пульт (абстракция)
    public abstract class RemoteControl(IDevice device)
    {
        protected IDevice Device = device;
        public abstract void PressPower();
    }

    // конкретные абстракции
    public class BasicRemote(IDevice device) : RemoteControl(device)
    {
        public override void PressPower()
        {
            Console.WriteLine("Basic remote: ");
            Device.TurnOn();
        }
    }

    public class AdvancedRemote(IDevice device) : RemoteControl(device) 
    {
        public override void PressPower()
        {
            Console.WriteLine("Advanced remote: ");
            Device.TurnOn();
            Console.WriteLine(" + set volume");
        }
    }
}
