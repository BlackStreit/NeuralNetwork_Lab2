using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lenium.NeuralNetwork.TransferFunctions.Interfaces
{
    public interface ITransferFunction
    {
        double Compute(double x);

        double Derivative(double x);
    }
}
