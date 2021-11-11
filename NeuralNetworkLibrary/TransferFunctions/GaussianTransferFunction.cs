using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lenium.NeuralNetwork.TransferFunctions.Interfaces;

namespace Lenium.NeuralNetwork.TransferFunctions
{
    public class GaussianTransferFunction : ITransferFunction
    {
        public double Compute(double x)
        {
            return Math.Exp(-Math.Pow(x, 2));
        }

        public double Derivative(double x)
        {
            return -2.0 * x * Compute(x);
        }
    }
}
