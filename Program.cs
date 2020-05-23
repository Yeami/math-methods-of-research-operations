namespace UnimodalFunctions
{
    internal static class Program
    {
        private const int A = 0;
        private const int B = 2;
        private static readonly double[] Epsilons = {0.01, 0.0001, 0.00000001};

        private static void Main()
        {
            foreach (var epsilon in Epsilons)
            {
                new DichotomyMethod(A, B, epsilon).Solve();
                new GoldenSectionMethod(A, B, epsilon).Solve();
            }
        }
    }
}