using System;

namespace UnimodalFunctions
{
    public class Function
    {
        public int CallAmount { get; private set; }

        public Function()
        {
            CallAmount = 0;
        }

        public double Solve(double x)
        {
            CallAmount += 1;
            return 4 * Math.Pow(3 - x, 2.0 / 3.0) + 2 * Math.Pow(x, 3.0);
        }
    }
}