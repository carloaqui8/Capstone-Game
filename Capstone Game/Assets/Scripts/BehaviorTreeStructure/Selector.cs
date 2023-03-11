using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public class Selector : Node
    {
        //properties
        public Selector() : base() { }          //Constructor calls Node Constructor
        public Selector(List<Node> children) : base(children) { }   //Same with this one

        //methods
        public override NodeState Evaluate()
        {
            foreach (Node node in children)
            {
                switch (node.Evaluate())
                {
                    case NodeState.FAILURE:
                        break;
                    case NodeState.SUCCESS:
                        state = NodeState.SUCCESS;
                        return state;
                    case NodeState.RUNNING:
                        state = NodeState.SUCCESS;
                        return state;
                    default:
                        break;
                }
            }
            state = NodeState.FAILURE;
            return state;
        }
    }
}
