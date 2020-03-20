using System;

namespace task_of_transfusion
{
   public class Program
    {

        static void Main()
        {
            var graph = new WeightedGraph(9, 5);

            new AStarSearch(graph, new State(0,9, 0,5), 3);

            Console.ReadKey();
        }

    }


}