using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace NeuralNetwork.Brain
{
    public class XorBrain : Brain
    {
        public XorBrain(NeuralNetwork network) : base(network)
        {

        }

        public override void Think(int trainingIterations)
        {
            List<double> result = null;

            for (int i = 0; i < trainingIterations; i++)
            {
                sumSquareError = 0;
                result = Train(1, 1, 0); //xor operator (1, 1, is a 0)
                sumSquareError += MathF.Pow((float)result[0] - 0, 2); //power of 2, or squared
                result = Train(1, 0, 1); //xor 1 and 0 is a 1
                sumSquareError += MathF.Pow((float)result[0] - 1, 2);
                result = Train(0, 1, 1); //xor 0 and 1 is a 1
                sumSquareError += MathF.Pow((float)result[0] - 1, 2);
                result = Train(0, 0, 0); //xor 0 and 0 is a 0
                sumSquareError += MathF.Pow((float)result[0] - 0, 2);
            }
            Debug.WriteLine($"Brain::Think() Sum Square Error:  {sumSquareError}"); //we want this value to be as small as possible like (0.00001 small)

            result = Train(1, 1, 0);
            Debug.WriteLine($"Brain::Think() final values:  1|1 =  {result[0]}");
            result = Train(1, 0, 1);
            Debug.WriteLine($"Brain::Think() final values:  1|0 =  {result[0]}");
            result = Train(0, 1, 1);
            Debug.WriteLine($"Brain::Think() final values:  0|1 =  {result[0]}");
            result = Train(0, 0, 0);
            Debug.WriteLine($"Brain::Think() final values:  0|0 =  {result[0]}");
        }

        private List<double> Train(double input1, double input2, double output)
        {
            var inputs = new List<double>();
            var outputs = new List<double>();
            inputs.Add(input1);
            inputs.Add(input2);
            outputs.Add(output);
            return network.Execute(inputs, outputs);
        }
    }
}
