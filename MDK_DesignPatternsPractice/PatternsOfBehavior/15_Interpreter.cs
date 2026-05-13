namespace MDK_DesignPatternsPractice.PatternsOfBehavior
{
    public interface IExpression
    {
        int Interpret();
    }

    public class NumberExpression(int number) : IExpression
    {
        private int _number = number;
        public int Interpret() => _number;
    }

    public class AddExpression(IExpression left, IExpression middle, IExpression right) : IExpression
    {
        private readonly IExpression _left = left;
        private readonly IExpression _middle = middle;
        private readonly IExpression _right = right;

        public int Interpret() => _left.Interpret() + _middle.Interpret() - _right.Interpret();
    }
}
