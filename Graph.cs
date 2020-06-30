using System;
using System.Collections.Generic;
using System.Text;
using NeuralNetwork.Training;

namespace NeuralNetwork
{
    public class Graph
    {
        //example graph code, this is a console app so there are no graphics, but implmenting this in unity or something with a front end would be useful
        //and this is example code for how that could look
        ITrainingSet _ts;
        public Graph(ITrainingSet ts)
        {
            _ts = ts;
        }

        public void DrawPoints()
        {
            for (int i = 0; i < _ts.TrainingSets.Count; i++)
            {
                //if (_ts.TrainingSets[i].Output == 0)
                //graph.DrawPoint((float)input[0], (float)input[1], Color.red);
                //else
                //graph.DrawPoint((float)input[0], (float)input[1], Color.green);
            }
        }
        
        public void DrawPerceptronRay()
        {
            //shows the decision boundary of the perceptron

            //drawRay takes the slope which is change of Y over change in X, followed by the intercept which is the -bias divided by second weight
            //graph.DrawRay((float)(-(bias/weights[1])/(bias/weights[0])),(float)(-bias/weights[1]), Color.White); 
        }
    }
}
