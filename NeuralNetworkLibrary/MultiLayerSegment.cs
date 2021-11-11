using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lenium.NeuralNetwork.TransferFunctions;
using Lenium.NeuralNetwork.Enums;
using Lenium.NeuralNetwork.InputDatas;
using Lenium.NeuralNetwork.InputDatas.Interfaces;
using Lenium.NeuralNetwork.Interfaces;

namespace Lenium.NeuralNetwork
{
    public class MultiLayerSegment : IMultiLayerSegment
    {
        private ILayer[] _layers;
        private Guid _id;
        private string _title = String.Empty;

        /// <summary>
        /// 
        /// </summary>
        public ILayer[] Layers
        {
            get { return _layers; }
            set { _layers = value; }
        }
        
        public Guid ID
        {
            get { return _id; }
            private set { _id = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public MultiLayerSegment()
        {
            _id = Guid.NewGuid();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public MultiLayerSegment(Guid id)
        {
            _id = id;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        public MultiLayerSegment(Guid id, string title)
        {
            _id = id;
            _title = title;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputData"></param>
        /// <param name="regenerateLayers"></param>
        /// <returns></returns>
        public IInputData<double> CalculateOutput(IInputData<double> inputData, bool regenerateLayers = false)
        {
            if (_layers == null || _layers.Length == 0 || regenerateLayers)
                GenerateLayers(inputData);

            _layers.First().Calculate(inputData.Input);

            for (int i = 1; i < _layers.Length; i++)
            {
                _layers[i].Calculate(_layers[i - 1].LastOutput);
            }

            inputData.SetOutput(_layers.Last().LastOutput);

            return inputData;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputData"></param>
        public void GenerateLayers(IInputData<double> inputData)
        {
            var inputSettings = inputData.InputSettings;

            if (inputSettings.LayersCreationType == LayersCreationType.Manual && inputSettings.HiddenLayersDescriptions.Count > 0)
            {
                List<ILayer> layers = new List<ILayer>();

                layers.Add(new Layer(inputSettings.HiddenLayersDescriptions.First().NeuronsCount, inputData.Input.Length, inputSettings.HiddenLayersDescriptions.First().TransferFunction));

                foreach (var hiddenLayersDescription in inputSettings.HiddenLayersDescriptions.Skip(1))
                {
                    layers.Add(new Layer(hiddenLayersDescription.NeuronsCount, layers.Last().Neurons.Length, hiddenLayersDescription.TransferFunction));
                }

                layers.Add(new Layer(inputData.Output.Length, layers.Last().Neurons.Length, inputSettings.OutputLayerTransferFunction));

                _layers = layers.ToArray();
            }
            else if (inputSettings.LayersCreationType == LayersCreationType.Automatic || inputSettings.HiddenLayersDescriptions.Count == 0)
            {

                var list = new List<int>();

                int neuronesCount = inputData.Input.Length + 1;

                list.Add(neuronesCount);

                for (int i = neuronesCount - 1; i > inputData.Output.Length - 1; i = i / 2)
                {
                    list.Add(i);
                }

                list.Add(inputData.Output.Length);

                _layers = new ILayer[list.Count];

                for (int i = 0; i < list.Count; i++)
                {
                    if (i == 0)
                    {
                        _layers[i] = new Layer(list[i], inputData.Input.Length, inputSettings.OutputLayerTransferFunction);

                        continue;
                    }

                    _layers[i] = new Layer(list[i], _layers[i - 1].Neurons.Length, inputSettings.OutputLayerTransferFunction);
                }

            }
        }
    }
}
