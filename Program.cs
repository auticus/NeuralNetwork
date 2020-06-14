using System;

namespace NeuralNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            Train_Or();
            Train_And();
            var x = Console.ReadLine();
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
