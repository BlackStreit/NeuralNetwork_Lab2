using Lenium.NeuralNetwork.TransferFunctions.Interfaces;
using Lenium.NeuralNetwork.Helpers;
using Lenium.NeuralNetwork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lenium.NeuralNetwork
{
    public class Neuron : INeuron
    {
        private double[] _weights;

        /// <summary>
        /// 
        /// </summary>
        public double[] Weights
        {
            get { return _weights; }
            set { _weights = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public double LastActivateState { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double Bias { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double LastNET { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ITransferFunction TransferFunction { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Neuron()
        {}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="weightsCount"></param>
        public Neuron(int weightsCount)
        {
            _weights = new double[weightsCount];

            for (int i = 0; i < weightsCount; i++)
            {
                _weights[i] = Gaussian.GetRandomGaussian();
            }

            Bias = Gaussian.GetRandomGaussian();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputVector"></param>
        /// <returns></returns>
        public double Out(double[] inputVector)
        {
            double sum = NET(inputVector);

            return Activate(sum);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputVector"></param>
        /// <returns></returns>
        public double NET(double[] inputVector)
        {
            double sum = 0.0d;

            for (int i = 0; i < inputVector.Length; i++)
            {
                sum += Weights[i] * inputVector[i];
            }

            sum += Bias;

            LastNET = sum;

            return sum;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public double Activate(double net)
        {
            LastActivateState = TransferFunction.Compute(net);

            return LastActivateState;
        }
    }
}
