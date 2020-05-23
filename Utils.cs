using System;

namespace UnimodalFunctions
{
    public static class Utils
    {
        public static double RoundToEps(double epsilon, double number)
        {
            return Math.Round(number * Math.Pow(epsilon, -1)) / Math.Pow(epsilon, -1);
        }

        public static void Print
        (
            string method,
            double epsilon,
            double point,
            double function,
            int iterationAmount,
            int functionCallAmount
        )
        {
            Console.WriteLine(
                $"\n----- {method} -----" +
                $"\nEpsilon: {epsilon}" +
                $"\nx*: {point}" +
                $"\nf*: {function}" +
                $"\nIteration amount: {iterationAmount}" +
                $"\nFunction calls amount: {functionCallAmount}"
            );
        }
    }
}