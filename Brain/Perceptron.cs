using System;
using System.Text;
using System.IO;
using NeuralNetwork.Training;
using Newtonsoft.Json;

namespace NeuralNetwork.Brain
{
    /// <summary>
    /// Binary Classifier capable of sorting data into one group or the other
    /// </summary>
    [Serializable]
    public class Perceptron
    {
        public double Bias = 0; //used as an extra weight
        public double[] Weights = { 0 };
        private double _totalError = 0;
        private ITrainingSet _ts;

        /// <summary>
        /// Serialization constructor
        /// </summary>
        public Perceptron()
        {

        }

        public Perceptron(ITrainingSet ts)
        {
            _ts = ts;
            Weights = ts.InitialWeights;
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
            var dotProduct = DotProductBias(Weights, inputs);
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

        public void Save(string perceptronName)
        {
            var output = JsonConvert.SerializeObject(this);
            var fileName = perceptronName + ".dat";
            File.WriteAllText(fileName, output);
        }

        public void Load(string perceptronName)
        {
            var perceptron = new Perceptron();
            var fileName = perceptronName + ".dat";
            using (var sw = new StreamReader(fileName))
            {
                var json = sw.ReadToEnd();
                perceptron = JsonConvert.DeserializeObject<Perceptron>(json);
            }

            Bias = perceptron.Bias;
            Weights = perceptron.Weights;
        }

        private void InitializeWeights()
        {
            for(var i = 0; i < Weights.Length; i++)
            {
                Weights[i] = Util.RandomRange(-1.0f, 1.0f);
            }
            Bias = Util.RandomRange(-1.0f, 1.0f);
        }

        private void WriteWeightsValues()
        {
            var sb = new StringBuilder();
            for(int i = 0; i < Weights.Length; i++)
            {
                sb.Append($"Weight {i + 1}: {Weights[0]} ");
            }
            sb.Append($"Bias: {Bias}");
            Console.WriteLine(sb.ToString());
        }

        private void UpdateWeights(int trainingSetIndex)
        {
            //calculate the DOT PRODUCT of the weights and inputs
            //example if I'm doing the logical OR then lets say this line the output should be a "1", and CalculateOutput produces either a 0 or a 1.  The error
            //will be either a 0 or a 1 (if its a 0 no error occurred, if it is a 1 or -1 then we have an issue)
            var error = _ts.TrainingSets[trainingSetIndex].Output - CalculateOutput(trainingSetIndex);
            _totalError += MathF.Abs((float)error);
            for (var i = 0; i < Weights.Length; i++)
            {
                //now lets change the weight to be the old value plus the error value multiplied by the input that is associated with that weight
                Weights[i] = Weights[i] + error * _ts.TrainingSets[trainingSetIndex].Inputs[i];
            }
            Bias += error; //update the bias with the error produced
        }

        /// <summary>
        /// This is the output that the perceptron thinks that it should be producing
        /// </summary>
        /// <param name="trainingSetIndex"></param>
        /// <returns></returns>
        private double CalculateOutput(int trainingSetIndex)
        {
            var dotProduct = DotProductBias(Weights, _ts.TrainingSets[trainingSetIndex].Inputs);
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

            returnValue += Bias;
            return returnValue;
        }
    }
}
