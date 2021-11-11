using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lenium.NeuralNetwork.Interfaces
{
    public interface ILayer
    {
        INeuron[] Neurons { get; set; }

        double[] LastOutput { get; }

        double[] Calculate(double[] inputVector);
    }
}
