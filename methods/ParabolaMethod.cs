using System;

namespace UnimodalFunctions.methods
{
    public class ParabolaMethod
    {
        private readonly double _a;
        private readonly double _b;
        private readonly double _eps;
        private int _iterationAmount;
        private readonly Function _function;
        private readonly double[] _luckyThree;
        private bool _flag;

        public ParabolaMethod(int a, int b, double eps)
        {
            _a = a;
            _b = b;
            _eps = eps;
            _function = new Function();
            _luckyThree = GetLuckyThree();
        }

        public void Solve()
        {
            var x0 = _luckyThree[0];
            var x1 = _luckyThree[1];
            var x2 = _luckyThree[2];

            var f0 = _function.Solve(x0);
            var f1 = _function.Solve(x1);
            var f2 = _function.Solve(x2);

            double point;
            double function;

            do
            {
                point = GetPoint(x0, x1, x2, f0, f1, f2);
                function = _function.Solve(point);

                if (Math.Abs(x1 - point) >= _eps && Math.Abs(x2 - point) >= _eps)
                {
                    _flag = false;
                    double x3 = 0;
                    double f3 = 0;

                    if (point < x1)
                    {
                        x3 = x2;
                        f3 = f2;
                        x2 = x1;
                        f2 = f1;
                        x1 = point;
                        f1 = function;
                    }
                    else if (point > x1)
                    {
                        x3 = x2;
                        f3 = f2;
                        x2 = point;
                        f2 = function;
                    }

                    if (f1 > f2)
                    {
                        x0 = x1;
                        f0 = f1;
                        x1 = x2;
                        f1 = f2;
                        x2 = x3;
                        f2 = f3;
                    }
                }
                else
                {
                    _flag = true;
                }

                _iterationAmount++;
            } while (!_flag);

            point = Utils.RoundToEps(_eps, point);
            function = Utils.RoundToEps(_eps, _function.Solve(point));

            Utils.Print("Parabola", _eps, point, function, _iterationAmount, _function.CallAmount);
        }

        private static double GetPoint(double x0, double x1, double x2, double f0, double f1, double f2)
        {
            return (x0 + x1) / 2 + (f1 - f0) * (x2 - x0) * (x2 - x1) / (2 * ((f1 - f0) * (x2 - x0) - (f2 - f0) * (x1 - x0)));
        }

        private double[] GetLuckyThree()
        {
            var searchMethod = new SearchMethod((_a + _b) / 2.0, 0.1, _eps);
            searchMethod.Solve();

            return searchMethod.LuckyThree;
        }
    }
}