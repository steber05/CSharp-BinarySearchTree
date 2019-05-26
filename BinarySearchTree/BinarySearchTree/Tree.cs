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
        int size;
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
            //root is empty add value to root
            if (root == null)
            {
                root = new Node(value);
                size++;
            }
            else
            {
                Node current = root;
                Node parent = root;
                bool left = true;
                //end of variables

                //check whether to place as .left or .right
                while (current != null)
                {
                    //set parent
                    parent = current;
                    //traverse the tree
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
                //add value to tree based on set boolean
                if (left)
                {
                    parent.left = new Node(value);
                    size++;
                }
                else
                {
                    parent.right = new Node(value);
                    size++;
                }
            }
        }

        public void PrintInOrder()
        {
            //start from root of each tree created
            InOrder(root);
            DecreasingOrder(root);
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

        private void DecreasingOrder(Node node)
        {
            //if there is no value set in this node, stop traversing
            if (n == null)
            {
                return;
            }

            //update for right
            InOrder(p.right);
            //print the value
            Console.WriteLine(p.value);
            //update for left
            InOrder(p.left);
        }
    }
}
