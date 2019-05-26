using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    class Tree
    {
        Node root;
        //end of field

        public Tree()
        {
            //empty tree
            root = null;
        }
        public Tree(Node root)
        {
            //start with one item, make user create node
            this.root = root;
        }
        public Tree(int startValue)
        {
            //create a tree with one item. ask for node value only.
            Node n = new Node(startValue);
            root = n;

            //or
            root = new Node(startValue);
        }//end of constuctors

        public void Insert(int value)
        {
            //if there's nothing in the list, add to root
            if (root == null)
            {
                root = new Node(value);
            }
            else
            {
                //add to a leaf/child/end node
                Node current = root;
                Node parent = root;
                bool left = true;
                while (current != null)
                {
                    // System.Console.WriteLine(current.value);
                    //set parent
                    parent = current;
                    //traverse the tree (value < current.value)
                    if (current.value > value)
                    {
                        //change current to left child
                        current = current.left;
                        // System.Console.WriteLine("left");
                        left = true;
                    }
                    else if (current.value < value)
                    {
                        current = current.right;
                        //  System.Console.WriteLine("right");
                        left = !true;  //same as left = false
                    }
                    else
                    {
                        return;
                    }

                }
                //add value
                if (left)
                {
                    //  Console.WriteLine(value);
                    parent.left = new Node(value);
                }
                else
                {
                    //     Console.WriteLine(value);
                    parent.right = new Node(value);
                }
                //   Console.WriteLine("++========================++");
            }
        }

        public void PrintInOrder()
        {
            //start from root of each tree created
            InOrder(root);
        }

        private void InOrder(Node node)
        {
            //if there is no value set in this node, stop traversing
            if (n == null)
            {
                return;
            }

            //update for left
            InOrder(p.left);
            //print the value
            Console.WriteLine(p.value);
            //update for right
            InOrder(p.right);
        }

        public int FindRightSmallest(Node n)
        {
            //keeping track of where we are:
            Node current = n;
            Node parent;

            //Try to go right 1
            parent = current;
            current = current.right;
            if (current.left == null)
            {
                int value = current.value;
                parent.right = null;
                return value;
            }
            else
            {
                //while there are left nodes, go left
                while (current.left != null)
                {
                    parent = current;
                    current = current.left;
                }
                //replace our node to delete with our smallest big number 
                //(the smallest number from the right hand side of tree)
                int value = current.value;
                parent.left = null;
                return value;
            }

        }

        public int FindRightSmallestWithBool(Node n)
        {
            //keeping track of where we are:
            Node current = n;
            Node parent;

            //Try to go right 1
            parent = current;
            current = current.right;
            bool isLeft = false;

            //while there are left nodes, go left
            while (current.left != null)
            {
                parent = current;
                current = current.left;
                isLeft = true;
            }
            //replace our node to delete with our smallest big number 
            //(the smallest number from the right hand side of tree)
            if (isLeft == true)
            {
                parent.left = null;
            }
            else
            {
                parent.right = null;
            }
            int value = current.value;
            current = null;
            return value;
        }
    }
}
