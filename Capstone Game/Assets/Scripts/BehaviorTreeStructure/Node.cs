using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Node {
    //properties
    protected NodeState _nodeState;

    //methods
    public NodeState nodeState                  //getter
    {
        get {
            return _nodeState;
        }
    }
    public abstract NodeState Evaluate();       //Abstract is similar to virtual,
                                                //but you have to override them
}

public enum NodeState
{
    RUNNING,
    SUCCESS,
    FAILURE
}