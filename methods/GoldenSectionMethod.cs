using System;

namespace UnimodalFunctions.methods
{
    public class GoldenSectionMethod
    {
        private double _a;
        private double _b;
        private readonly double _eps;
        private int _iterationAmount;
        private readonly Function _function;

        public GoldenSectionMethod(int a, int b, double eps)
        {
            _a = a;
            _b = b;
            _eps = eps;
            _function = new Function();
        }

        public void Solve()
        {
            var u = _a + (3 - Math.Sqrt(5)) / 2 * (_b - _a);
            var v = _a + _b - u;

            var uFunction = _function.Solve(u);
            var vFunction = _function.Solve(v);

            do
            {
                if (uFunction <= vFunction)
                {
                    _b = v;
                    v = u;
                    vFunction = uFunction;
                    u = _a + _b - v;
                    uFunction = _function.Solve(u);
                }
                else
                {
                    _a = u;
                    u = v;
                    uFunction = vFunction;
                    v = _a + _b - u;
                    vFunction = _function.Solve(v);
                }

                if (u > v)
                {
                    u = _a + (3 - Math.Sqrt(5)) / 2 * (_b - _a);
                    v = _a + _b - u;
                    vFunction = _function.Solve(v);
                    uFunction = _function.Solve(u);
                }

                _iterationAmount++;
            } while (!(_b - _a < _eps));

            var point = Utils.RoundToEps(_eps, (_a + _b) / 2);
            var function = Utils.RoundToEps(_eps, _function.Solve(point));

            Utils.Print("Golden Section", _eps, point, function, _iterationAmount, _function.CallAmount);
        }
    }
}