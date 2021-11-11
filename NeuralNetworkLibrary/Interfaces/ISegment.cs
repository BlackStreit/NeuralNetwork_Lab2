using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lenium.NeuralNetwork.InputDatas.Interfaces;

namespace Lenium.NeuralNetwork.Interfaces
{
    public interface ISegment
    {
        Guid ID { get; }

        string Title { get; set; }

        IInputData<double> CalculateOutput(IInputData<double> inputData, bool regenerateLayers = false);
    }
}
