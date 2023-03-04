using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : Node
{
    //properties
    protected List<Node> nodes = new List<Node>();

    //methods
    public Sequence(List<Node> nodes)                   //constructor
    {
        this.nodes = nodes;
    }

    public override NodeState Evaluate()
    {
        bool anyNodeRunning = false;
        foreach(var node in nodes)
        {
            switch (node.Evaluate())
            {
                case NodeState.RUNNING:
                    anyNodeRunning = true;
                    break;
                case NodeState.SUCCESS:
                    break;
                case NodeState.FAILURE:
                    _nodeState = NodeState.FAILURE;
                    return _nodeState;
                default:
                    break;
            }
        }
        if (anyNodeRunning)
        {
            _nodeState = NodeState.RUNNING;
        }
        else
        {
            _nodeState = NodeState.SUCCESS;
        }
        return _nodeState;
    }
}
