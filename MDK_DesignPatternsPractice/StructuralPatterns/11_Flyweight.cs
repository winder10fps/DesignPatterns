using System;
using System.Collections.Generic;
using System.Text;

namespace MDK_DesignPatternsPractice.StructuralPatterns
{
    public class Position(int x, int y)
    {
        public int X { get; } = x;
        public int Y { get; } = y;
        public string GetPosition() => X + " " + Y;
        public Position NewPosition() => new(X, Y);
    }


    public class CharacterFlyweight
    {
        private static int _countObjects;
        public char Symbol { get; }
        public string Font { get; }
        public int Size { get; }

        public CharacterFlyweight(char symbol, string font, int size)
        {
            Symbol = symbol;
            Font = font;
            Size = size;
            _countObjects++;
        }

        public void Display(Position position)
        {
            Console.WriteLine($"\"{Symbol}\" at {position.GetPosition()} with {Font} {Size}");
        }
        public static int GetCountObjects() => _countObjects;
    }


    // фабрика приспособленцев
    public class CharacterFactory
    {
        private Dictionary<char, CharacterFlyweight> _cache = [];

        public CharacterFlyweight GetCharacter(char symbol, string font, int size)
        {
            if (!_cache.ContainsKey(symbol))
            {
                _cache[symbol] = new CharacterFlyweight(symbol, font, size);
            }
            return _cache[symbol];
        }
    }
}
