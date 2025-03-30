// TO DO - быстрое возведение в степень
namespace AADT
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine(Algorithm.Fib(45));
        }
    }
    public static class Algorithm
    {
        public static bool IsPrimeEasy(int num)
        {
            if (num % 2 == 0 || num % 3 == 0) return false;

            for (int i = 5; i * i < num; i += 2)
            {
                if (num % i == 0)
                    return false;
            }
            return true;
        }

        public static int Fib(int n)
        {
            if (n == 0 || n == 1)
                return 1;

            int prev = 1;
            int curr = 1;

            for (int i = 1; i < n; i++)
            {
                (prev, curr) = (curr, prev + curr);
            }
            return curr;
        }
    }

    public class MatrixFib
    {
        public static readonly int[,] _matrix = new int[2, 2] { { 1, 1 }, { 1, 0 } };

        public static int[,] findFibByNumber(int n, int[,] matrix )
        {

            if (n == 0 || n == 1)
            {
                return matrix;
            }

            else if (n % 2 == 0)
            {
                return findFibByNumber(n / 2, PowSecondOrderMatrix(matrix));
            }

            else if (n % 2 == 1)
            {
                return MultiplyMatrixByMatrix(findFibByNumber(n / 2, PowSecondOrderMatrix(matrix)), matrix);
            }
            else throw new Exception("Невозможно, Ошибка!");
        }

        public static int[,] PowSecondOrderMatrix(int[,] matrix)
        {
            var result = new int[2, 2];

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    int num = 0;

                    for (int k = 0; k < 2; k++)
                    {
                        num += matrix[i, k] * matrix[k, j];
                    }
                    result[i, j] = num;
                }
            }

            return result;
        }

        public static int[,] MultiplyMatrixByMatrix(int[,] first, int[,] second)
        {
            var result = new int[2,2];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    int num = 0;

                    for (int k = 0; k < 2; k++)
                    {
                        num += first[i, k] * second[k, j];
                    }
                    result[i, j] = num;
                }
            }

            return result;
        }
    }
}
