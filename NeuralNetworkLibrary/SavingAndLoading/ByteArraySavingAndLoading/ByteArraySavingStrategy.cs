using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Lenium.NeuralNetwork.SavingAndLoading.Interfaces;
using Lenium.NeuralNetwork.SavingAndLoading.ByteArraySavingAndLoading.Models;

namespace Lenium.NeuralNetwork.SavingAndLoading.ByteArraySavingAndLoading
{
    public class ByteArraySavingStrategy : ISavingStrategy<byte[]> 
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="segment"></param>
        /// <returns></returns>
        public byte[] Save(Lenium.NeuralNetwork.Interfaces.IMultiLayerSegment segment)
        {
            var model = new MultiLayerSegmentModel(segment);

            var formatter = new BinaryFormatter();
            using (var stream = new MemoryStream())
            {
                formatter.Serialize(stream, model);
                return stream.ToArray();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="segment"></param>
        /// <param name="stream"></param>
        public void SaveToStream(Lenium.NeuralNetwork.Interfaces.IMultiLayerSegment segment, Stream stream)
        {
            var model = new MultiLayerSegmentModel(segment);

            var formatter = new BinaryFormatter();

            formatter.Serialize(stream, model);

            stream.Flush();

            stream.Dispose();
        }
    }
}
