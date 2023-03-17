using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public class Sequence : Node
    {
        //properties
        public Sequence() : base() { }          //Constructor calls Node Constructor
        public Sequence(List<Node> children) : base(children) { }   //Same with this one

        //methods
        public override NodeState Evaluate()
        {
            bool aChildRunning = false;
            
            foreach(Node node in children)
            {
                switch(node.Evaluate())
                {
                    case NodeState.FAILURE:
                        state = NodeState.FAILURE;
                        return state;
                    case NodeState.SUCCESS:
                        continue;
                    case NodeState.RUNNING:
                        aChildRunning = true;
                        continue;
                    default:
                        state = NodeState.SUCCESS;
                        return state;
                }
            }
            if (aChildRunning)
            {
                state = NodeState.RUNNING;
            }
            else
            {
                state = NodeState.SUCCESS;
            }
            return state;
        }
    }
}
