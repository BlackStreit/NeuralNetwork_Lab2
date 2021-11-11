using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lenium.NeuralNetwork.InputDatas;
using Lenium.NeuralNetwork.InputDatas.Interfaces;

namespace Lenium.NeuralNetwork.Interfaces
{
    public interface IMultiLayerSegment : ISegment
    {
        ILayer[] Layers { get; set; }

        void GenerateLayers(IInputData<double> inputData);
    }
}
