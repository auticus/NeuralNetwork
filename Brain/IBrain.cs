using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork.Brain
{
    public interface IBrain
    {
        void Think(int trainingIterations);
    }
}
