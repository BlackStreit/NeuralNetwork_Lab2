using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lenium.NeuralNetwork.Interfaces;

namespace Lenium.NeuralNetwork.SavingAndLoading.ByteArraySavingAndLoading.Models
{
    [Serializable]
    internal class MultiLayerSegmentModel
    {
        public LayerModel[] Layers;

        public string Title;

        public MultiLayerSegmentModel()
        { }

        public MultiLayerSegmentModel(IMultiLayerSegment segment)
        {
            Title = segment.Title;

            Layers = new LayerModel[segment.Layers.Length];

            for (int i = 0; i < Layers.Length; i++)
            {
                Layers[i] = new LayerModel(segment.Layers[i]);
            }
        }
    }
}
