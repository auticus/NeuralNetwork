using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    public class TrainingSet_Xor : ITrainingSet
    {
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
