using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace task_of_transfusion
{
    public class AStarSearch
    {
        public Dictionary<State, State> cameFrom
        = new Dictionary<State, State>();
        public Dictionary<State, double> costSoFar
            = new Dictionary<State, double>();

        static public double Heuristic(State state, int goal)
        {
            return Math.Abs(state.FLB - goal) + Math.Abs(state.NLB - goal);
        }

        public bool Contains(State state)
        {
            foreach (var el in cameFrom.Keys)
            {
                if (el.FLB == state.FLB && el.NLB ==state.NLB && el.NLBCapacity == state.NLBCapacity && el.FLBCapacity == state.FLBCapacity)
                {
                    return true;
                }
            }

            return false;
        }
         
        public AStarSearch(WeightedGraph graph, State start, int goal)
        {
            var frontier = new PriorityQueue<State>();
            frontier.Enqueue(start, 0);

            cameFrom[start] = start;
            costSoFar[start] = 0;
            while (frontier.Count > 0)
            {
                var current = frontier.Dequeue();

                Console.WriteLine();
                Console.WriteLine("node: NLB:{0}, FLB:{1}", current.NLB, current.FLB);

                if (current.FLB == goal || current.NLB==goal)
                {
                    Console.WriteLine("Goal is found: NLB:{0}, FLB:{1}", current.NLB, current.FLB);
                    break;
                }

                var children = graph.GetChildren(current);

                Console.WriteLine("daughter nodes:");
                foreach (var next in children)
                {
                   
                    double newCost = costSoFar[current];

                    if (!Contains(next))
                    {
                        costSoFar[next] = newCost;
                        double priority = newCost + Heuristic(next, goal);
                        frontier.Enqueue(next, priority);
                        cameFrom[next] = current;
                        
                        Console.WriteLine("NLB:{0}, FLB:{1}", next.NLB, next.FLB);
                    }
                    
                }
            }
        }

    }
}
