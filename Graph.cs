using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    public class Graph
    {
        //example graph code
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
            //graph.DrawRaw((float)(-(bias/weights[1])/(bias/weights[0])),(float)(-bias/weights[1]), Color.White); 
        }
    }
}
