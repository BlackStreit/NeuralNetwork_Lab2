using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lenium.NeuralNetwork.TransferFunctions.Interfaces;
using Lenium.NeuralNetwork.Enums;

namespace Lenium.NeuralNetwork.InputDatas.Interfaces
{
    public interface IInputSettings
    {
        ITransferFunction OutputLayerTransferFunction { get; set; }

        LayersCreationType LayersCreationType { get; set; }

        List<LayerDescription> HiddenLayersDescriptions { get; set; } 
    }
}
