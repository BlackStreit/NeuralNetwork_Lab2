using System.Collections.Generic;
using Lenium.NeuralNetwork.TransferFunctions;
using Lenium.NeuralNetwork.TransferFunctions.Interfaces;
using Lenium.NeuralNetwork.Enums;
using Lenium.NeuralNetwork.InputDatas.Interfaces;

namespace Lenium.NeuralNetwork.InputDatas
{
    public class InputSettings : IInputSettings
    {
        /// <summary>
        /// 
        /// </summary>
        public LayersCreationType LayersCreationType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ITransferFunction OutputLayerTransferFunction { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<LayerDescription> HiddenLayersDescriptions { get; set; } 

        /// <summary>
        /// 
        /// </summary>
        public InputSettings()
        {
            LayersCreationType = LayersCreationType.Automatic;

            OutputLayerTransferFunction = new SigmoidTransferFunction();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="layersCteationType"></param>
        /// <param name="?"></param>
        public InputSettings(LayersCreationType layersCteationType, List<LayerDescription> hiddenLayersDescriptions, ITransferFunction outputLayerTransferFunction)
        {
            this.LayersCreationType = layersCteationType;
            this.HiddenLayersDescriptions = hiddenLayersDescriptions;
            this.OutputLayerTransferFunction = outputLayerTransferFunction;
        }
    }
}
