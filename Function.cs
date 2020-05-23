using System;

namespace UnimodalFunctions
{
    public static class Function
    {
        public static double Solve(double x)
        {
            return 4 * Math.Pow(3 - x, 2.0 / 3.0) + 2 * Math.Pow(x, 3.0);
        }
    }
}