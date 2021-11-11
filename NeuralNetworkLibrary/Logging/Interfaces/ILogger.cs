using Lenium.NeuralNetwork.Logging.Args;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lenium.NeuralNetwork.Logging.Interfaces
{
    public interface ILogger
    {
        event EventHandler<LogMessageEventArgs> MessageReceived;

        void AddMessage(string message);
    }
}
