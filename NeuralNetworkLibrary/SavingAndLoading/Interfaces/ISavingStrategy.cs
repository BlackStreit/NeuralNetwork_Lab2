using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Lenium.NeuralNetwork.Interfaces;
using Lenium.NeuralNetwork.TransferFunctions.Interfaces;

namespace Lenium.NeuralNetwork.SavingAndLoading.Interfaces
{
    public interface ISavingStrategy<T>
    {
        T Save(IMultiLayerSegment segment);

        void SaveToStream(IMultiLayerSegment segment, Stream stream);
    }
}
