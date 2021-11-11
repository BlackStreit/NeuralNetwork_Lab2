using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lenium.NeuralNetwork.TransferFunctions.Interfaces;

namespace Lenium.NeuralNetwork.TransferFunctions
{
    public class DefaultTransferFunction : ITransferFunction
    {
        public double Compute(double x)
        {
            return 0.0;
        }

        public double Derivative(double x)
        {
            return 0.0;
        }
    }
}
