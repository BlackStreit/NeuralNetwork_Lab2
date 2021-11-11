using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lenium.NeuralNetwork.TransferFunctions;
using Lenium.NeuralNetwork.InputDatas.Interfaces;

namespace Lenium.NeuralNetwork.InputDatas
{
    public class InputData<T> : IInputData<T>
    {
        private T[] _input;
        private T[] _output;

        /// <summary>
        /// 
        /// </summary>
        public T[] Input
        {
            get
            {
                return _input;
            }
            set
            {
                _input = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public T[] Output
        {
            get { return _output; }
        }

        /// <summary>
        /// 
        /// </summary>
        public IInputSettings InputSettings { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="output"></param>
        public InputData(T[] input, T[] output)
        {
            _input = input;
            _output = output;

            InputSettings = new InputSettings();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="output"></param>
        public InputData(T[] input, T[] output, IInputSettings settings)
        {
            _input = input;
            _output = output;

            InputSettings = settings;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="output"></param>
        public void SetOutput(T[] output)
        {
            _output = output;
        }
    }
}
