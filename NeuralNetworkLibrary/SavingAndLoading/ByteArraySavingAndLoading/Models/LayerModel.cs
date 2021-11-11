using Lenium.NeuralNetwork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lenium.NeuralNetwork.SavingAndLoading.ByteArraySavingAndLoading.Models
{
    [Serializable]
    internal class LayerModel
    {
        public NeuronModel[] Neurons;

        public LayerModel()
        {}

        public LayerModel(ILayer layer)
        {
            Neurons = new NeuronModel[layer.Neurons.Length];

            for (int i = 0; i < Neurons.Length; i++)
            {
                Neurons[i] = new NeuronModel(layer.Neurons[i]);
            }
        }
    }
}
