using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public abstract class Tree : MonoBehaviour          //abstract similar to virtual but you
    {                                                   //have to override specified methods
        //properties
        private Node root = null;

        //methods
        protected void Start()
        {
            root = CreateTree();
        }

        private void Update()
        {
            if (root != null)
            {
                root.Evaluate();
            }
        }

        protected abstract Node CreateTree();           //abstract method
    }

}