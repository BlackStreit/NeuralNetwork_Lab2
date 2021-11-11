using Lenium.NeuralNetwork.Logging.Args;
using Lenium.NeuralNetwork.Logging.Interfaces;
using System;

namespace Lenium.NeuralNetwork.Logging
{
    public class Logger : ILogger
    {
        /// <summary>
        /// 
        /// </summary>
        public static Logger Current { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        static Logger()
        {
            Current = new Logger();
        }

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<LogMessageEventArgs> MessageReceived;

        /// <summary>
        /// 
        /// </summary>
        private Logger()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public void AddMessage(string message)
        {
            OnMessageReceived(message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        private void OnMessageReceived(string message)
        {
            if (MessageReceived != null)
                MessageReceived(this, new LogMessageEventArgs(message));
        }
    }
}
