using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lenium.NeuralNetwork.TransferFunctions.Interfaces;

namespace Lenium.NeuralNetwork.TransferFunctions
{
    public class RationalSigmoidTransferFunction : ITransferFunction
    {
        public double Compute(double x)
        {
            return x / (1.0 + Math.Sqrt(1.0 + x * x));
        }

        public double Derivative(double x)
        {
            double val = Math.Sqrt(1.0 + x * x);

            return 1.0 / (val * (1 + val));
        }
    }
}
