using System;

namespace UnimodalFunctions.methods
{
    public class SearchMethod
    {
        private readonly double _x0;
        private double _h;
        private readonly double _eps;
        private readonly Function _function;
        private double[] LuckyThree { get; set; }

        public SearchMethod(double x0, double h, double eps)
        {
            _x0 = x0;
            _h = h;
            _eps = eps;
            _function = new Function();
        }

        public void Solve()
        {
            var firstFunction = _function.Solve(_x0);
            double secondFunction;
            double x2;
            do
            {
                _h /= 2;
                x2 = _x0 + _h;
                secondFunction = _function.Solve(x2);

                if (!(firstFunction <= secondFunction)) continue;
                _h = -_h;
                x2 = _x0 + _h;
                secondFunction = _function.Solve(x2);
            } while (!(firstFunction > secondFunction || Math.Abs(_h) < _eps));

            if (Math.Abs(_h) > _eps)
            {
                double x1;
                do
                {
                    x1 = x2;
                    firstFunction = secondFunction;

                    x2 = x1 + _h;
                    secondFunction = _function.Solve(x2);
                } while (!(firstFunction < secondFunction));

                var a = _h > 0 ? x1 - _h : x2;
                var b = _h > 0 ? x2 : x1 - _h;

                LuckyThree = new[] {x2, x1, _x0};
            }

            var point = _x0;
            var function = Utils.RoundToEps(_eps, _function.Solve(point));

            LuckyThree = new[] {x2, x2 + _h, _x0};
        }
    }
}