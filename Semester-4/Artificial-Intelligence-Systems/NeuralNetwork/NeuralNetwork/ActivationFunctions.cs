namespace NeuralNetwork
{
    using System;
    static class ActivationFunctions
    {
        #region Activaiton Functions

        public static decimal Linear(decimal x)
        {
            return x;
        }

        public static decimal BinaryStep(decimal x)
        {
            return x < 0 ? 0 : 1;
        }

        public static decimal Sigmoid(decimal x)
        {
            return (decimal)(1 / (1 + Math.Pow(Math.E, -(double)x)));
        }

        public static decimal Signum(decimal x)
        {
            return x < 0 ? -1 : 1;
        }

        #endregion

        #region Derivative Activation Fuctions

        public static decimal DLinear(decimal x)
        {
            return 1;
        }

        public static decimal DBinaryStep(decimal x)
        {
            if (x == 0)
                throw new Exception("Can't use this function in x = 0.");
            return 0;
        }

        public static decimal DSigmoid(decimal x)
        {
            return Sigmoid(x) * (1 - Sigmoid(x));
        }

        public static decimal DSignum(decimal x)
        {
            if (x == 0)
                throw new Exception("Can't use this function in x = 0.");
            return 0;
        }

        #endregion
    }
}
