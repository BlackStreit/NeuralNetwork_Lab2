using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Lenium.NeuralNetwork.SavingAndLoading.Interfaces;
using Lenium.NeuralNetwork.TransferFunctions.Interfaces;

namespace Lenium.NeuralNetwork.SavingAndLoading
{
    public class DefaultSavingStrategy : ISavingStrategy<string>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="segment"></param>
        /// <returns></returns>
        public string Save(Lenium.NeuralNetwork.Interfaces.IMultiLayerSegment segment)
        {
            if (segment == null)
                throw new ArgumentNullException("segment");

            string result = String.Empty;

            XElement rootElement = new XElement("MultiLayerSegment", new XAttribute("Title", segment.Title));



            foreach (var layer in segment.Layers)
            {
                XElement xLayer = new XElement("Layer");

                foreach (var neuron in layer.Neurons)
                {
                    XElement xNeuron = new XElement("Neuron", new XAttribute("Bias", neuron.Bias.ToString(CultureInfo.InvariantCulture)), new XAttribute("TransferFunctionType", neuron.TransferFunction.GetType().Name));

                    foreach (var weight in neuron.Weights)
                    {
                        XElement xWeight = new XElement("Axon", new XAttribute("Value", weight.ToString(CultureInfo.InvariantCulture)));

                        xNeuron.Add(xWeight);
                    }

                    xLayer.Add(xNeuron);
                }

                rootElement.Add(xLayer);
            }

            result = rootElement.ToString(SaveOptions.DisableFormatting);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="segment"></param>
        /// <param name="stream"></param>
        public void SaveToStream(Lenium.NeuralNetwork.Interfaces.IMultiLayerSegment segment, Stream stream)
        {
            if (segment == null)
                throw new ArgumentNullException("segment");

            string xml = this.Save(segment);

            using (var streamWriter = new StreamWriter(stream))
            {
                streamWriter.Write(xml);
            }
        }
    }
}
