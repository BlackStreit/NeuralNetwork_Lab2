namespace Lenium.NeuralNetwork.InputDatas.Interfaces
{
    public interface IInputData<T>
    {
        T[] Input { get; set; }

        T[] Output { get; }

        IInputSettings InputSettings { get; set; }

        void SetOutput(T[] output);
    }
}
