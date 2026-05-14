namespace MDK_DesignPatternsPractice.PatternsOfBehavior
{
    public abstract class ReportGenerator
    {
        public void Generate()
        {
            FetchData();
            FormatData();
            Save();
        }
        private void FetchData() => Console.WriteLine("Извлечение данных");
        private void Save() => Console.WriteLine("Сохранение данных");
        protected abstract void FormatData();
    }


    public class PDF : ReportGenerator
    {
        protected override void FormatData() => Console.WriteLine("Форматирование PDF");
    }


    public class HTML : ReportGenerator
    {
        protected override void FormatData() => Console.WriteLine("Форматирование HTML");
    }


    public class CSV : ReportGenerator
    {
        protected override void FormatData() => Console.WriteLine("Форматирование CSV");
    }
}
