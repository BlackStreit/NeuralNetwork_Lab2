using Lenium.NeuralNetwork.TransferFunctions.Interfaces;

namespace Lenium.NeuralNetwork.TransferFunctions
{
    public class LinearTransferFunction : ITransferFunction
    {
        public double Compute(double x)
        {
            return x;
        }

        public double Derivative(double x)
        {
            return 1.0;
        }
    }
}
