using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lenium.NeuralNetwork.Interfaces;

namespace Lenium.NeuralNetwork.SavingAndLoading.ByteArraySavingAndLoading.Models
{
    [Serializable]
    internal class NeuronModel
    {
        public double Bias;

        public double[] Weights;

        public string TransferFunctionTypeName;

        public NeuronModel()
        {
        }

        public NeuronModel(INeuron neuron)
        {
            Bias = neuron.Bias;
            Weights = neuron.Weights;
            TransferFunctionTypeName = neuron.TransferFunction.GetType().Name;
        }
    }
}
