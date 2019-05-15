using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    class Node
    {
        public int value;
        public Node left;
        public Node right;
        //end of instance variables

        //constructor
        public Node(int value)
        {
            this.value = value;
            left = null;
            right = null;
        }//end of constructor
    }
}
