using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lenium.NeuralNetwork.TransferFunctions.Interfaces;

namespace Lenium.NeuralNetwork.Interfaces
{
    public interface INeuron
    {
        double[] Weights { get; set; }

        ITransferFunction TransferFunction { get; set; }

        double Bias { get; set; }

        double Out(double[] inputVector);

        double NET(double[] inputVector);

        double Activate(double net);

        double LastActivateState { get; set; }

        double LastNET { get; set; }
    }
}
