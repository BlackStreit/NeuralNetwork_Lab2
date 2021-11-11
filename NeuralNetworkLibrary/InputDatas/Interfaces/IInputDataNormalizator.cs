using System.Collections.Generic;

namespace Lenium.NeuralNetwork.InputDatas.Interfaces
{
    public interface IInputDataNormalizator<T>
    {
        IInputSettings InputSettings { get; set; }

        IList<IInputData<double>> Normalize(T input);
    }
}
