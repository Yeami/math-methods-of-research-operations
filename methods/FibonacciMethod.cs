namespace UnimodalFunctions.methods
{
    public class FibonacciMethod
    {
        private double _a;
        private double _b;
        private readonly double _eps;
        private int _iterationAmount;
        private readonly Function _function;
        private int _n = 1;

        public FibonacciMethod(int a, int b, double eps)
        {
            _a = a;
            _b = b;
            _eps = eps;
            _function = new Function();
            GetN();
        }

        public void Solve()
        {
            var u = _a + GetFibonacci(_n) / GetFibonacci(_n + 2) * (_b - _a);
            var v = _a + _b - u;

            var uFunction = _function.Solve(u);
            var vFunction = _function.Solve(v);

            for (var i = 1; i <= _n; i++)
            {
                if (uFunction < vFunction)
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
                    u = _a + GetFibonacci(_n - i + 1) / GetFibonacci(_n - i + 3) * (_b - _a);
                    v = _a + _b - u;

                    uFunction = _function.Solve(u);
                    vFunction = _function.Solve(v);
                }

                _iterationAmount++;
            }

            var point = Utils.RoundToEps(_eps, (_a + _b) / 2);
            var function = Utils.RoundToEps(_eps, _function.Solve(point));

            Utils.Print("Fibonacci", _eps, point, function, _iterationAmount, _function.CallAmount);
        }

        private void GetN()
        {
            while ((_b - _a) / GetFibonacci(_n + 2) > _eps) _n++;
        }

        private static double GetFibonacci(int n)
        {
            return n <= 1 ? 1 : GetFibonacci(n - 1) + GetFibonacci(n - 2);
        }
    }
}