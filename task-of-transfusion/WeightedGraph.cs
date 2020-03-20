using System;
using System.Collections.Generic;
using System.Text;

namespace task_of_transfusion
{
    public class WeightedGraph
    {   
        public int SizeNLB { get; set; }
        public int SizeFLB { get; set; }

       
        public WeightedGraph(int SizeNLB, int SizeFLB)
        {

            this.SizeFLB = SizeFLB;
            this.SizeNLB = SizeNLB;
        }

        public bool IsValid(State state)
        {
            
            return (0 <= state.NLB) && (state.NLB <= SizeNLB) &&
                (0 <= state.FLB) && (state.FLB <= SizeFLB) &&
                (0<=state.NLBCapacity)&&(state.NLBCapacity<=SizeNLB)&&
                (0 <= state.FLBCapacity) && (state.FLBCapacity <= SizeFLB)&&
                (state.NLB+state.NLBCapacity==SizeNLB)&&(state.FLB + state.FLBCapacity==SizeFLB);
        }

        public void CheckState(List<State> children,State state)
        {
            if (IsValid(state))
            {
                children.Add(state);
            }
        }

        public List<State> GetChildren(State state)
        {
            List<State> children = new List<State>();


            //Умови переливання з більшої посудини у меншу
            CheckState(children, new State(state.NLB + state.NLBCapacity, 0, state.FLB, state.FLBCapacity));

            CheckState(children, new State(state.NLB - state.FLBCapacity, state.NLBCapacity + state.FLBCapacity, state.FLB + state.FLBCapacity, 0));

            CheckState(children, new State(state.NLB, state.NLBCapacity, 0, state.FLBCapacity + state.FLB));

            CheckState(children, new State(0, state.NLB + state.NLBCapacity, state.FLB + state.NLB, state.FLBCapacity - state.NLB));

            //Умови переливання з меншої посудини у більшу
            CheckState(children, new State(state.NLB, state.NLBCapacity, state.FLB + state.FLBCapacity, 0));

            CheckState(children, new State(state.NLB + state.FLB, state.NLBCapacity - state.FLB, 0 , state.FLBCapacity + state.FLB));

            CheckState(children, new State(state.NLB + state.NLBCapacity, 0, state.FLB - state.NLBCapacity, state.FLBCapacity +state.NLBCapacity));

            CheckState(children, new State(0, state.NLBCapacity + state.NLB, state.FLB, state.FLBCapacity));


            return children;
        }
    }
}
