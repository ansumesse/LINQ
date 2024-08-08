using System.Linq.Expressions;

namespace LINQ.ExpressionTrees_16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ExpressionEx3();
        }
        public static void ExpressionEx1()
        {
            Expression<Func<int, bool>> isEvenEx = x => x % 2 == 0;
            Func<int, bool> isEven = isEvenEx.Compile();
            Console.WriteLine(isEven(10));
        }
        public static void ExpressionEx2()
        {
            Expression<Func<int, bool>> isEven = x => x % 2 == 0;

            ParameterExpression numPar = isEven.Parameters[0];
            BinaryExpression EquaOperation = (BinaryExpression)isEven.Body;
            BinaryExpression ModOperation = (BinaryExpression)EquaOperation.Left;
            ConstantExpression two = (ConstantExpression)ModOperation.Right;
            ConstantExpression zero = (ConstantExpression)EquaOperation.Right;

            Console.WriteLine($"{numPar.Name} => {numPar.Name} {ModOperation.NodeType} {two.Value} {EquaOperation.NodeType} {zero.Value}");

        }
        public static void ExpressionEx3()
        {
            // x => x % 2 == 0;
            ParameterExpression parameter = Expression.Parameter(typeof(int), "number");
            ConstantExpression two = Expression.Constant(2);
            BinaryExpression modulus = Expression.Modulo(parameter, two);
            ConstantExpression zero = Expression.Constant(0);
            BinaryExpression checkEqual = Expression.Equal(modulus, zero);

            Expression<Func<int, bool>> isEvenExp = Expression.Lambda<Func<int, bool>>(checkEqual, new ParameterExpression[]
            {
                parameter
            });

            Func<int, bool> isEven = isEvenExp.Compile();
            Console.WriteLine(isEven(11));
        }
    }
}
