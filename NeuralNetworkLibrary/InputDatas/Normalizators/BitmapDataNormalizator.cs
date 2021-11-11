using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Lenium.NeuralNetwork.InputDatas.Interfaces;

namespace Lenium.NeuralNetwork.InputDatas.Normalizators
{
    public class BitmapDataNormalizator : IInputDataNormalizator<IList<Bitmap>>
    {
        /// <summary>
        /// 
        /// </summary>
        public IInputSettings InputSettings { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputSettings"></param>
        public BitmapDataNormalizator(IInputSettings inputSettings)
        {
            InputSettings = inputSettings;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public IList<IInputData<double>> Normalize(IList<Bitmap> input)
        {
            if (!ValidateBitmaps(input)) throw new Exception("Invalid inputs!");

            List<IInputData<double>> list = new List<IInputData<double>>();

            for (int i = 0; i < input.Count; i++)
            {
                double[] inputArray = new double[input[i].Width * input[i].Height];
                double[] outputArray = new double[input.Count];

                for (int j = 0, k = 0; j < input[i].Height; j++)
                {
                    for (int u = 0; u < input[i].Width; u++)
                    {
                        double val = 0.3 * input[i].GetPixel(u, j).R + 0.59 * input[i].GetPixel(u, j).G + 0.11 * input[i].GetPixel(u, j).B;

                        if (val > 127)
                        {
                            inputArray[k++] = -0.5;
                        }
                        else
                        {
                            inputArray[k++] = 0.5;
                        }
                    }
                }

                for (int j = 0; j < outputArray.Length; j++)
                {
                    if (j == i)
                        outputArray[j] = 0.99;
                    else
                        outputArray[j] = 0.01;
                }

                var inputData = new InputData<double>(inputArray, outputArray, InputSettings);

                list.Add(inputData);
            }

            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bitmaps"></param>
        /// <returns></returns>
        private bool ValidateBitmaps(IList<Bitmap> bitmaps)
        {
            if (bitmaps == null || bitmaps.Count == 0)
                throw new ArgumentNullException("bitmaps");

            double width, height;
            width = bitmaps.First().Width;
            height = bitmaps.First().Height;

            foreach (var bitmap in bitmaps.Skip(1))
            {
                if (bitmap.Width != width || bitmap.Height != height || width == 0.0d || height == 0.0d)
                    return false;
            }

            return true;
        }
    }
}
