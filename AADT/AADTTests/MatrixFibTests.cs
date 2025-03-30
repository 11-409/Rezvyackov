using AADT;

namespace AADTTests
{
    public class MatrixFibTests
    {
        [Theory]
        [MemberData(nameof(TestPowFibCases))]
        public void TestPowFib(int[,] input, int[,] expected)
        {
            var matrixFib = new MatrixFib();

            var result = MatrixFib.PowSecondOrderMatrix(input);

            Assert.True(CompareMatrix(expected, result));

        }

        [Theory]
        [MemberData(nameof(TestFindFibNumbersCases))]
        public void TestFindFibNumbers(int n, int expected)
        {
            var fib = new MatrixFib();

            var result = MatrixFib.findFibByNumber(n, MatrixFib._matrix)[0, 0];

            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(TestMultiplyMatrixByStandartCases))]
        public void TestMultiplyMatrixByStandart(int[,] matrix, int[,] expected)
        {
            var fib = new MatrixFib();

            var res = MatrixFib.MultiplyMatrixByMatrix(matrix, new int[2,2] { { 1, 1}, { 1, 0 } });

            Assert.True(CompareMatrix(res, expected));

        }
        public static bool CompareMatrix(int[,] first, int[,] second)
        {
            var flag = true;

            for(int i = 0; i < 2; i++)
            {
                for(int j = 1; j < 2; j++)
                {
                    if (first[i, j] != (second[i, j]))
                    {
                        flag = false;
                        break;
                    }
                }
            }
            return flag;
        }
        public static IEnumerable<object[]> TestPowFibCases()
        {
            yield return new object[] { new int[,] { { 1, 1 }, { 1, 0 } }, new int[,] { { 2, 1 }, { 1, 1 } } };
            yield return new object[] { new int[,] { { 2, 1 }, { 1, 1 } }, new int[,] { { 5, 3 }, { 3, 2 } } };
            yield return new object[] { new int[,] { { 3, 2 }, { 2, 1 } }, new int[,] { { 13, 8 }, { 8, 5 } } };
        }

        public static IEnumerable<object[]> TestFindFibNumbersCases()
        {
            yield return new object[] {0, 1};
            yield return new object[] {1, 1};
            yield return new object[] {2, 2};
            yield return new object[] { 3, 3 };
            yield return new object[] { 4, 5 };
            yield return new object[] { 5, 8 };
            yield return new object[] { 6, 13 };
            yield return new object[] { 7, 21 };
            yield return new object[] { 8, 34 };
            yield return new object[] { 20, 10946 };
            yield return new object[] { 40, 165580141 };
        }

        public static IEnumerable<object[]> TestMultiplyMatrixByStandartCases()
        {
            yield return new object[] { new int[,] { { 1, 1 }, { 1, 0 } }, new int[,] { { 2, 1 }, { 1, 1 } } };
            yield return new object[] { new int[,] { { 2, 1 }, { 1, 1 } }, new int[,] { { 3, 2 }, { 2, 1 } } };
            yield return new object[] { new int[,] { { 3, 2 }, { 2, 1 } }, new int[,] { { 5, 3 }, { 3, 2 } } };
        }
    }
}