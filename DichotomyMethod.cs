namespace UnimodalFunctions
{
    public class DichotomyMethod
    {
        private double _a;
        private double _b;
        private readonly double _eps;
        private int _iterationAmount;
        private readonly Function _function;

        public DichotomyMethod(int a, int b, double eps)
        {
            _a = a;
            _b = b;
            _eps = eps;
            _function = new Function();
        }

        public void Solve()
        {
            var delta = _eps / 3;

            do
            {
                var x1 = (_a + _b - delta) / 2;
                var x2 = (_a + _b + delta) / 2;

                var firstFunction = _function.Solve(x1);
                var secondFunction = _function.Solve(x2);

                if (firstFunction <= secondFunction)
                {
                    _b = x2;
                }
                else
                {
                    _a = x1;
                }

                _iterationAmount++;
            } while (!(_b - _a < _eps));

            var point = Utils.RoundToEps(_eps, (_a + _b) / 2);
            var function = Utils.RoundToEps(_eps, _function.Solve(point));

            Utils.Print("Dichotomy", _eps, point, function, _iterationAmount, _function.CallAmount);
        }
    }
}