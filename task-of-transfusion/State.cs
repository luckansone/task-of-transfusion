using System;
using System.Collections.Generic;
using System.Text;

namespace task_of_transfusion
{
    public class State
    {
        public int NLB { get; set; }
        public int FLB { get; set; }
        public int NLBCapacity { get; set; }
        public int FLBCapacity { get; set; }

        public State(int NLB, int NLBCapacity, int FLB, int FLBCapacity)
        {
            this.NLB = NLB;
            this.NLBCapacity = NLBCapacity;
            this.FLB = FLB;
            this.FLBCapacity = FLBCapacity;
        }
    }
}
