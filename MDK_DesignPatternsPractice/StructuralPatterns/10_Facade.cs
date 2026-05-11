namespace MDK_DesignPatternsPractice.StructuralPatterns
{
    public class Amplifier
    {
        public void TurnOn() => Console.WriteLine("Усислитель включен");
        public void TurnOff() => Console.WriteLine("Усислитель выключен");
    }

    public class DVDPlayer
    {
        public void Play() => Console.WriteLine("DVD запущено");
        public void Stop() => Console.WriteLine("DVD остановлено");
    }

    public class Projector
    {
        public void TurnUpBrightness() => Console.WriteLine("Яркость прожектора прибавлена");
        public void TurnDownBrightness() => Console.WriteLine("Яркость прожектора убавлена");
    }


    public class HomeTheatreFacade
    {
        private readonly Amplifier _amplifier = new();
        private readonly DVDPlayer _DVDPlayer = new();
        private readonly Projector _projector = new();

        public void WatchMovie()
        {
            Console.WriteLine("Start watching...");
            _amplifier.TurnOn();
            _DVDPlayer.Play();
            _projector.TurnUpBrightness();
            Console.WriteLine("Nice view!");
        }

        public void EndMovie()
        {
            Console.WriteLine("End watching...");
            _projector.TurnDownBrightness();
            _DVDPlayer.Stop();
            _amplifier.TurnOff();
            Console.WriteLine("Bye...");
        }
    }
}
