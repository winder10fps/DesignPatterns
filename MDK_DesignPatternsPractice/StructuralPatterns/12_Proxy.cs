namespace MDK_DesignPatternsPractice.StructuralPatterns
{
    public interface IResourse
    {
        bool ShowAuthScreen();
        void Display();
    }


    // реальный тяжелый файл
    public class Resourse : IResourse
    {
        private readonly string _pageName;

        public Resourse(string pageText)
        {
            _pageName = pageText;
            LoadFromServer();
        }

        private void LoadFromServer()
        {
            Console.WriteLine("[LOADING] Start ...");
            Thread.Sleep(2000);
            Console.WriteLine($"[LOADING] Page {_pageName} loaded (20MB)");
        }

        public void Display()
        {
            Console.WriteLine($"[DISPLAY] Show {_pageName} in browser");
        }

        public bool ShowAuthScreen()
        {
            Console.WriteLine($"[AUTH] Show auth {_pageName}");
            return false;
        }
    }


    // виртуальный прокси
    public class ResourseProxy : IResourse
    {
        private readonly string _pageName;
        private Resourse? _page;

        public ResourseProxy(string pageName)
        {
            _pageName = pageName;
            Console.WriteLine($"[PROXY] Created proxy for {_pageName} without loading");
        }

        public void Display()
        {
            if (_page == null)
            {
                bool flowControl = ShowAuthScreen();
                if (!flowControl)
                {
                    return;
                }
            }
            _page?.Display();
        }

        public bool ShowAuthScreen()
        {
            Console.WriteLine($"[AUTH] Show auth {_pageName}");
            Console.Write($"[PROXY] First visit, enter password:");
            var input = Console.ReadLine();

            bool access = input == "111";
            if (access)
            {
                Console.WriteLine("You are authorized!");
                _page = new Resourse(_pageName);
            }
            else
            {
                Console.WriteLine("Incorrect password!");
                return false;
            }

            return true;
        }
    }
}
