using Lenium.NeuralNetwork.TransferFunctions.Interfaces;
using Lenium.NeuralNetwork.InputDatas.Interfaces;
using Lenium.NeuralNetwork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lenium.NeuralNetwork
{
    public class Layer : ILayer
    {
        private INeuron[] _neurons;
        private double[] _lastOutput;

        /// <summary>
        /// 
        /// </summary>
        public INeuron[] Neurons
        {
            get { return _neurons; }
            set { _neurons = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public double[] LastOutput { get { return _lastOutput; } }

        /// <summary>
        /// 
        /// </summary>
        public Layer()
        {}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="neuronsCount"></param>
        /// <param name="weightsCount"></param>
        public Layer(int neuronsCount, int weightsCount, ITransferFunction TransferFunction)
        {
            _neurons = new INeuron[neuronsCount];

            for (int i = 0; i < neuronsCount; i++)
            {
                _neurons[i] = new Neuron(weightsCount) { TransferFunction = TransferFunction };
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputVector"></param>
        /// <returns></returns>
        public double[] Calculate(double[] inputVector)
        {
            double[] result = new double[_neurons.Length];

            for (int i = 0; i < _neurons.Length; i++)
            {
                result[i] = _neurons[i].Out(inputVector);
            }

            _lastOutput = result;

            return result;
        }
    }
}
