using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    public class TrainingSet_Xor : ITrainingSet
    {
        /*
         * An xor cannot be classified by a binary classifier because it is impossible to graph
         * the xor into two distinct groups.  If you graph out the training set you will find that you cannot 
         * draw a line between the two groups
         */

        public List<TrainingSet> TrainingSets { get; private set; }
        public double[] InitialWeights { get; } = { 0, 0 };

        public TrainingSet_Xor()
        {
            TrainingSets = new List<TrainingSet>();
            ConstructTrainingSet();
        }

        private void ConstructTrainingSet()
        {
            //OR training set
            //0 || 0 = 0
            //0 || 1 = 1
            //1 || 0 = 1
            //1 || 1 = 1

            TrainingSets.Add(new TrainingSet { Inputs = new double[] { 0, 0 }, Output = 0 });
            TrainingSets.Add(new TrainingSet { Inputs = new double[] { 0, 1 }, Output = 1 });
            TrainingSets.Add(new TrainingSet { Inputs = new double[] { 1, 0 }, Output = 1 });
            TrainingSets.Add(new TrainingSet { Inputs = new double[] { 1, 1 }, Output = 0 });
        }
    }
}
