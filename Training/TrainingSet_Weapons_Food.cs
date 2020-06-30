using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork.Training
{
    public class TrainingSet_Weapons_Food : ITrainingSet
    {
        public List<TrainingSet> TrainingSets { get; private set; }
        public double[] InitialWeights { get; } = { 0, 0 };

        public TrainingSet_Weapons_Food()
        {
            TrainingSets = new List<TrainingSet>();
            ConstructTrainingSet();
        }

        private void ConstructTrainingSet()
        {
            //Sharpness vs Edible - a 0 = a weapon and a 1 = food

            TrainingSets.Add(new TrainingSet { Inputs = new double[] { 0.5, 1 }, Output = 1 }); //croisant
            TrainingSets.Add(new TrainingSet { Inputs = new double[] { 0, 0.8 }, Output = 1 }); //burger
            TrainingSets.Add(new TrainingSet { Inputs = new double[] { 0.2, 1 }, Output = 1 }); //strawberry
            TrainingSets.Add(new TrainingSet { Inputs = new double[] { 0.1, 0.5 }, Output = 1 }); //cupcake
            TrainingSets.Add(new TrainingSet { Inputs = new double[] { 0.1, 0.5 }, Output = 1 }); //fries
            TrainingSets.Add(new TrainingSet { Inputs = new double[] { 0.3, 0.5 }, Output = 1 }); //cutlet
            TrainingSets.Add(new TrainingSet { Inputs = new double[] { 0.5, 0.9 }, Output = 1 }); //carrot
            TrainingSets.Add(new TrainingSet { Inputs = new double[] { 0.8, 1 }, Output = 1 }); //pineabple
            TrainingSets.Add(new TrainingSet { Inputs = new double[] { 0.1, 0 }, Output = 1 }); //numchucks
            TrainingSets.Add(new TrainingSet { Inputs = new double[] { 0.5, 0.3 }, Output = 1 }); //bow
            TrainingSets.Add(new TrainingSet { Inputs = new double[] { 0.5, 0.3 }, Output = 1 }); //stick
            TrainingSets.Add(new TrainingSet { Inputs = new double[] { 0.1, 0.1 }, Output = 1 });//sword
            TrainingSets.Add(new TrainingSet { Inputs = new double[] { 0.7, 0 }, Output = 1 }); //axe
            TrainingSets.Add(new TrainingSet { Inputs = new double[] { 0.9, 0 }, Output = 1 }); //kunai

            //if you graph these you will see the food items are towards the up part of the graph and the weapons toward the bottom and a clear line you can 
            //draw (decision boundary) to see what that looks like
        }
    }
}
