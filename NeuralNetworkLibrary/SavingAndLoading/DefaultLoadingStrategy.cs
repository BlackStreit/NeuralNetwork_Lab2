using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Xml.Linq;
using Lenium.NeuralNetwork.Interfaces;
using Lenium.NeuralNetwork.SavingAndLoading.Interfaces;
using Lenium.NeuralNetwork.TransferFunctions;
using Lenium.NeuralNetwork.TransferFunctions.Interfaces;

namespace Lenium.NeuralNetwork.SavingAndLoading
{
    public class DefaultLoadingStrategy : ILoadingStrategy<string>
    {
        private IList<ITransferFunction> _addedTransferFunctions;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="addedTransferFunctions"></param>
        public DefaultLoadingStrategy(IList<ITransferFunction> addedTransferFunctions)
        {
            _addedTransferFunctions = addedTransferFunctions;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="segment"></param>
        /// <param name="context"></param>
        public void Load(IMultiLayerSegment segment, string context)
        {
            if (segment == null)
                throw new ArgumentNullException("segment");
            if (string.IsNullOrEmpty(context))
                throw new ArgumentNullException("context");

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
                foreach (var addedTransferFunction in _addedTransferFunctions)
                {
                    if (!transferFunctions.ContainsKey(addedTransferFunction.GetType().Name))
                        transferFunctions.Add(addedTransferFunction.GetType().Name, addedTransferFunction);
                }
            }



            XElement rootElement = XElement.Parse(context);

            string title = rootElement.Attribute("Title").Value;
            segment.Title = title;

            List<ILayer> layers = new List<ILayer>();

            foreach (var xElement in rootElement.Elements())
            {
                if (xElement.Name == "Layer")
                {
                    var layer = new Layer();

                    List<INeuron> neurons = new List<INeuron>();

                    foreach (var element in xElement.Elements())
                    {
                        if (element.Name == "Neuron")
                        {
                            INeuron neuron = new Neuron();

                            var var = element.Attribute("Bias").Value;

                            string transferFunctionType = element.Attribute("TransferFunctionType").Value;


                            if (!transferFunctions.ContainsKey(transferFunctionType))
                                throw new NullReferenceException("Не обнаружена необходимая активационная функция.");

                            neuron.TransferFunction = transferFunctions[transferFunctionType];

                            neuron.Bias = double.Parse(var, CultureInfo.InvariantCulture);

                            List<double> weights = new List<double>();

                            foreach (var neuronElement in element.Elements())
                            {
                                if (neuronElement.Name == "Axon")
                                {
                                    weights.Add(double.Parse(neuronElement.Attribute("Value").Value, CultureInfo.InvariantCulture));
                                }
                            }

                            neuron.Weights = weights.ToArray();

                            neurons.Add(neuron);
                        }
                    }

                    layer.Neurons = neurons.ToArray();

                    layers.Add(layer);
                }
            }

            segment.Layers = layers.ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="segment"></param>
        /// <param name="stream"></param>
        public void LoadFromStream(IMultiLayerSegment segment, System.IO.Stream stream)
        {
            using (var reader = new StreamReader(stream))
            {
                this.Load(segment, reader.ReadToEnd());
            }
        }
    }
}
