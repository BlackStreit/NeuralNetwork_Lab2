using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Lenium.NeuralNetwork.Interfaces;
using Lenium.NeuralNetwork.SavingAndLoading.ByteArraySavingAndLoading.Models;
using Lenium.NeuralNetwork.SavingAndLoading.Interfaces;
using Lenium.NeuralNetwork.TransferFunctions;
using Lenium.NeuralNetwork.TransferFunctions.Interfaces;

namespace Lenium.NeuralNetwork.SavingAndLoading.ByteArraySavingAndLoading
{
    public class ByteArrayLoadingStrategy : ILoadingStrategy<byte[]>
    {
        private readonly IList<ITransferFunction> _addedTransferFunctions;


        /// <summary>
        /// </summary>
        /// <param name="addedTransferFunctions"></param>
        public ByteArrayLoadingStrategy(IList<ITransferFunction> addedTransferFunctions)
        {
            _addedTransferFunctions = addedTransferFunctions;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="segment"></param>
        /// <param name="context"></param>
        public void Load(IMultiLayerSegment segment, byte[] context)
        {
            MultiLayerSegmentModel model;

            using (var stream = new MemoryStream(context))
            {
                var formatter = new BinaryFormatter();

                model = (MultiLayerSegmentModel) formatter.Deserialize(stream);
            }

            var transferFunctions = new Dictionary<string, ITransferFunction>();

            var defaultTransferFunction = new DefaultTransferFunction();
            transferFunctions.Add(defaultTransferFunction.GetType().Name, defaultTransferFunction);

            var gaussianTransferFunction = new GaussianTransferFunction();
            transferFunctions.Add(gaussianTransferFunction.GetType().Name, gaussianTransferFunction);

            var linearTransferFunction = new LinearTransferFunction();
            transferFunctions.Add(linearTransferFunction.GetType().Name, linearTransferFunction);

            var rationalSigmoidTransferFunction = new RationalSigmoidTransferFunction();
            transferFunctions.Add(rationalSigmoidTransferFunction.GetType().Name, rationalSigmoidTransferFunction);

            var sigmoidTransferFunction = new SigmoidTransferFunction();
            transferFunctions.Add(sigmoidTransferFunction.GetType().Name, sigmoidTransferFunction);

            if (_addedTransferFunctions != null && _addedTransferFunctions.Count > 0)
            {
                foreach (ITransferFunction addedTransferFunction in _addedTransferFunctions)
                {
                    if (!transferFunctions.ContainsKey(addedTransferFunction.GetType().Name))
                        transferFunctions.Add(addedTransferFunction.GetType().Name, addedTransferFunction);
                }
            }

            segment.Title = model.Title;

            var layersList = new List<ILayer>();
            foreach (LayerModel layerModel in model.Layers)
            {
                var layer = new Layer();

                var neuronsList = new List<INeuron>();
                foreach (NeuronModel neuronModel in layerModel.Neurons)
                {
                    var neuron = new Neuron();
                    neuron.Bias = neuronModel.Bias;

                    neuron.Weights = neuronModel.Weights;

                    neuron.TransferFunction = transferFunctions[neuronModel.TransferFunctionTypeName];

                    neuronsList.Add(neuron);
                }

                layer.Neurons = neuronsList.ToArray();

                layersList.Add(layer);
            }

            segment.Layers = layersList.ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="segment"></param>
        /// <param name="stream"></param>
        public void LoadFromStream(IMultiLayerSegment segment, Stream stream)
        {
            MultiLayerSegmentModel model;

            var formatter = new BinaryFormatter();

            model = (MultiLayerSegmentModel) formatter.Deserialize(stream);

            stream.Flush();

            stream.Dispose();

            segment.Title = model.Title;

            var transferFunctions = new Dictionary<string, ITransferFunction>();

            var defaultTransferFunction = new DefaultTransferFunction();
            transferFunctions.Add(defaultTransferFunction.GetType().Name, defaultTransferFunction);

            var gaussianTransferFunction = new GaussianTransferFunction();
            transferFunctions.Add(gaussianTransferFunction.GetType().Name, gaussianTransferFunction);

            var linearTransferFunction = new LinearTransferFunction();
            transferFunctions.Add(linearTransferFunction.GetType().Name, linearTransferFunction);

            var rationalSigmoidTransferFunction = new RationalSigmoidTransferFunction();
            transferFunctions.Add(rationalSigmoidTransferFunction.GetType().Name, rationalSigmoidTransferFunction);

            var sigmoidTransferFunction = new SigmoidTransferFunction();
            transferFunctions.Add(sigmoidTransferFunction.GetType().Name, sigmoidTransferFunction);

            if (_addedTransferFunctions != null && _addedTransferFunctions.Count > 0)
            {
                foreach (ITransferFunction addedTransferFunction in _addedTransferFunctions)
                {
                    if (!transferFunctions.ContainsKey(addedTransferFunction.GetType().Name))
                        transferFunctions.Add(addedTransferFunction.GetType().Name, addedTransferFunction);
                }
            }

            segment.Title = model.Title;

            var layersList = new List<ILayer>();
            foreach (LayerModel layerModel in model.Layers)
            {
                var layer = new Layer();

                var neuronsList = new List<INeuron>();
                foreach (NeuronModel neuronModel in layerModel.Neurons)
                {
                    var neuron = new Neuron();
                    neuron.Bias = neuronModel.Bias;

                    neuron.Weights = neuronModel.Weights;

                    neuron.TransferFunction = transferFunctions[neuronModel.TransferFunctionTypeName];

                    neuronsList.Add(neuron);
                }

                layer.Neurons = neuronsList.ToArray();

                layersList.Add(layer);
            }

            segment.Layers = layersList.ToArray();
        }
    }
}