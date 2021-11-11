using System;

namespace Lenium.NeuralNetwork.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public static class Gaussian
    {
        private static Random random = new Random();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static double GetRandomGaussian()
        {
            return GetRandomGaussian(0.0, 1.0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mean"></param>
        /// <param name="stddev"></param>
        /// <returns></returns>
        public static double GetRandomGaussian(double mean, double stddev)
        {
            double rVal1, rVal2;

            GetRandomGaussian(mean, stddev, out rVal1, out rVal2);

            return rVal1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mean"></param>
        /// <param name="stddev"></param>
        /// <param name="val1"></param>
        /// <param name="val2"></param>
        public static void GetRandomGaussian(double mean, double stddev, out double val1, out double val2)
        {
            double u, v, s, t;

            do
            {
                u = 2 * random.NextDouble() - 1;
                v = 2 * random.NextDouble() - 1;
            }
            while (u * u + v * v > 1 || (u == 0 && v == 0));

            s = u * u + v * v;
            t = Math.Sqrt((-0.2 * Math.Log(s)) / s);

            val1 = stddev * u * t + mean;
            val2 = stddev * v * t + mean;
        }
    }
}
