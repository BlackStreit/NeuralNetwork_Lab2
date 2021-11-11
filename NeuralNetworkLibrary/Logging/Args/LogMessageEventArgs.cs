using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lenium.NeuralNetwork.Logging.Args
{
    public class LogMessageEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public LogMessageEventArgs()
        {}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public LogMessageEventArgs(string message)
        {
            this.Message = message;
        }
    }
}
