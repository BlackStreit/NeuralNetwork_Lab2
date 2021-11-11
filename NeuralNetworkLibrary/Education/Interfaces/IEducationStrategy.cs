using System.Collections.Generic;
using Lenium.NeuralNetwork.InputDatas.Interfaces;

namespace Lenium.NeuralNetwork.Education.Interfaces
{
    public interface IEducationStrategy<T>
    {
        void Train(T segment, IList<IInputData<double>> inputData);
    }
}
