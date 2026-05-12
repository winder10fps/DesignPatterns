namespace MDK_DesignPatternsPractice.PatternsOfBehavior
{
    public enum SupportLevels
    {
        Basic,
        Senior,
        Manager
    }

    public abstract class SupportHandler
    {
        protected SupportHandler? _next;
        public void SetNext(SupportHandler next) => _next = next;
        public abstract void Handle(SupportLevels level);
    }


    public class BasicSupport : SupportHandler
    {
        public override void Handle(SupportLevels level)
        {
            if (level <= SupportLevels.Basic)
            {
                Console.WriteLine("Обычная техподдержка ответила");
            }
            else
            {
                _next?.Handle(level);
            }
        }
    }


    public class SeniorSupport : SupportHandler
    {
        public override void Handle(SupportLevels level)
        {
            if (level <= SupportLevels.Senior)
            {
                Console.WriteLine("Продвинутая техподдержка ответила");
            }
            else
            {
                _next?.Handle(level);
            }
        }
    }


    public class ManagerSupport : SupportHandler
    {
        public override void Handle(SupportLevels level)
        {
            if (level <= SupportLevels.Manager)
            {
                Console.WriteLine("Менеджер ответил");
            }
            else
            {
                Console.WriteLine("Никто не ответил");
            }
        }
    }
}
