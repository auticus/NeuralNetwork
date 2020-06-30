using System;
using NeuralNetwork.ActivationFunction;
using NeuralNetwork.Brain;
using NeuralNetwork.Training;

namespace NeuralNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            //TrainPerceptor();
            TrainNeuralNetwork(); //will train an xor neural network

            //neural networks sit under tensor flow in google, which is also what unity utilizes for its ML

            var x = Console.ReadLine();
        }

        private static void TrainNeuralNetwork()
        {
            var input = new BrainFactoryInput()
            {
                ActivationFunctionInputOutput = new Sigmoid(),
                ActivationFunctionHiddenLayers = new Sigmoid(), //do not use TanH for the xorbrain it is counter productive.  The xor needs 0 or 1, TanH brings in negative values as well
                Inputs = 2,
                Outputs = 1,
                HiddenLayers = 1,
                NeuronsPerHiddenLayer = 2,
                Alpha = 0.8 //how much impact the training has, sometimes you'll see NaN come back and this dials back the calculations a bit
            };
            var brain = BrainFactory.CreateBrain<XorBrain>(input);
            brain.Think(trainingIterations: 1000);
        }

        private static void TrainPerceptor()
        {
            Train_Or();
            Train_And();
        }

        private static Perceptron Train_Or()
        {
            var ts = new TrainingSet_Or();
            var perceptron = new Perceptron(ts);
            perceptron.TrainPerceptron(8);

            TestLine(0, 0, perceptron.CalculateOutput(0, 0));
            TestLine(1, 0, perceptron.CalculateOutput(1, 0));
            TestLine(0, 1, perceptron.CalculateOutput(0, 1));
            TestLine(1, 1, perceptron.CalculateOutput(1, 1));

            return perceptron;
        }

        private static Perceptron Train_And()
        {
            var ts = new TrainingSet_And();
            var perceptron = new Perceptron(ts);
            perceptron.TrainPerceptron(8);

            TestLine(0, 0, perceptron.CalculateOutput(0, 0));
            TestLine(1, 0, perceptron.CalculateOutput(1, 0));
            TestLine(0, 1, perceptron.CalculateOutput(0, 1));
            TestLine(1, 1, perceptron.CalculateOutput(1, 1));

            return perceptron;
        }

        private static void TestLine(double input1, double input2, double output)
        {
            Console.WriteLine($"Testing Inputs {input1},{input2}:  {output}");
        }
    }
}
