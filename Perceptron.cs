using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Intrinsics;
using System.Text;

namespace NeuralNetwork
{
    /// <summary>
    /// Binary Classifier capable of sorting data into one group or the other
    /// </summary>
    public class Perceptron
    {
        private ITrainingSet _ts;
        private double _bias = 0;
        private double _totalError = 0;
        private double[] _weights = { 0 };

        public Perceptron(ITrainingSet ts)
        {
            _ts = ts;
            _weights = ts.InitialWeights;
        }

        /// <summary>
        /// Given the trained weights, have the perceptron execute the operator
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public double CalculateOutput (double v1, double v2)
        {
            var inputs = new double[] { v1, v2 };
            var dotProduct = DotProductBias(_weights, inputs);
            return dotProduct > 0 ? 1 : 0;
        }

        public void TrainPerceptron(int iterations)
        {
            InitializeWeights();
            for (int i = 0; i < iterations; i++)
            {
                _totalError = 0;
                for (int x = 0; x < _ts.TrainingSets.Count; x++)
                {
                    UpdateWeights(x);
                    WriteWeightsValues();
                }
                Console.WriteLine($"TOTAL ERROR: {_totalError}");
            }
        }

        private void InitializeWeights()
        {
            var rnd = new Random();
            var maxValue = 1.0f;
            var minValue = -1.0f;

            for(var i = 0; i < _weights.Length; i++)
            {
                _weights[i] = rnd.NextDouble() * (maxValue - minValue) + minValue;
            }
            _bias = rnd.NextDouble() * (maxValue - minValue) + minValue;
        }

        private void WriteWeightsValues()
        {
            var sb = new StringBuilder();
            for(int i = 0; i < _weights.Length; i++)
            {
                sb.Append($"Weight {i + 1}: {_weights[0]} ");
            }
            sb.Append($"Bias: {_bias}");
            Console.WriteLine(sb.ToString());
        }

        private void UpdateWeights(int trainingSetIndex)
        {
            //calculate the DOT PRODUCT of the weights and inputs
            //example if I'm doing the logical OR then lets say this line the output should be a "1", and CalculateOutput produces either a 0 or a 1.  The error
            //will be either a 0 or a 1 (if its a 0 no error occurred, if it is a 1 or -1 then we have an issue)
            var error = _ts.TrainingSets[trainingSetIndex].Output - CalculateOutput(trainingSetIndex);
            _totalError += MathF.Abs((float)error);
            for (var i = 0; i < _weights.Length; i++)
            {
                //now lets change the weight to be the old value plus the error value multiplied by the input that is associated with that weight
                _weights[i] = _weights[i] + error * _ts.TrainingSets[trainingSetIndex].Inputs[i];
            }
            _bias += error; //update the bias with the error produced
        }

        /// <summary>
        /// This is the output that the perceptron thinks that it should be producing
        /// </summary>
        /// <param name="trainingSetIndex"></param>
        /// <returns></returns>
        private double CalculateOutput(int trainingSetIndex)
        {
            var dotProduct = DotProductBias(_weights, _ts.TrainingSets[trainingSetIndex].Inputs);
            return dotProduct > 0 ? 1 : 0;
        }

        private double DotProductBias(double[] weights, double[] inputs)
        {
            //an input is sent in and that input will have a weight attached to it
            //the return is the value of (input_1 * weight_1) + (input_2 * weight_2) etc... + bias
            //this actually forms the slope of the line on the graph that we are trying to solve for
            //if you plot the points on a graph of the two values (0 and 1) from the inputs (ie in an or 1|0 = 1 so point 1,0 is a 1, or a blue color
            //whereas 0,0 = 0 would be point 0,0 being a red color.  you can draw a line to separate those two values

            if (weights == null || inputs == null) return -1;
            if (weights.Length != inputs.Length) return -1;

            double returnValue = 0;

            for (int i = 0; i < weights.Length; i++)
            {
                returnValue += weights[i] * inputs[i];
            }

            returnValue += _bias;
            return returnValue;
        }
    }
}
