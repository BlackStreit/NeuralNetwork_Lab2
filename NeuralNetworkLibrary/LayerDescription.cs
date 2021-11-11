using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lenium.NeuralNetwork.TransferFunctions.Interfaces;

namespace Lenium.NeuralNetwork
{
    /// <summary>
    /// 
    /// </summary>
    public class LayerDescription
    {
        /// <summary>
        /// 
        /// </summary>
        public int NeuronsCount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ITransferFunction TransferFunction { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public LayerDescription()
        {}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="neuronsCount"></param>
        /// <param name="TransferFunction"></param>
        public LayerDescription(int neuronsCount, ITransferFunction TransferFunction)
        {
            this.NeuronsCount = neuronsCount;
            this.TransferFunction = TransferFunction;
        }
    }
}
