using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lenium.NeuralNetwork.TransferFunctions.Interfaces;

namespace Lenium.NeuralNetwork.TransferFunctions
{
    public class SigmoidTransferFunction : ITransferFunction
    {
        public double Compute(double x)
        {
            return 1.0 / (1.0 + Math.Exp(-x));
        }


        public double Derivative(double x)
        {
            return Compute(x) * (1 - Compute(x));
        }
    }
}
