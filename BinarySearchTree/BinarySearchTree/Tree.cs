using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    class Tree
    {
        //all BST have a root:
        Node root;

        //constructors
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
        }
        //insert a value
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

        public void InOrderPrint()
        {
            //start checking our tree for values
            InOrder(root);
        }

        /// <summary>
        /// Recursive method to get values of this BST
        /// </summary>
        /// <param name="p"></param>
        private void InOrder(Node p)
        {
            //if there is no value set in this node, stop traversing
            if (p == null)
            {
                return;
            }
            //also written as:
            //if (p == null) return;

            //go as far left as possible
            InOrder(p.left);
            //print the value
            Console.WriteLine(p.value);
            //go as far right as possible
            InOrder(p.right);
            //done!
        }

        public void Delete2Noded()
        {

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


        public void DeleteNode(Node toDelete)
        {
            //Using the insert method to creat our delete method
            if (root != null)
            {
                //find the node to delete
                Node current = root;
                Node parent = root;
                bool left = true;
                while (current != null)
                {
                    //set parent
                    parent = current;
                    //if the current and value are the same, 
                    //then we have found the thing to delete
                    if (current.value == toDelete.value)
                    {
                        //check for children
                        if (current.left == null && current.right == null)
                        {
                            //delete the node as it has no children
                            if (left == true) parent.left = null;
                            else parent.right = null;

                            current = null;
                        }
                        if (current.left != null && current.right == null)
                        {
                            //one child on the left of current to move 
                            //up to parent/replace current
                            //if we went down the left of the parent,  
                            //then replace parent.left with the current's left child
                            //otherwise it was the right of parent.
                            if (left == true) parent.left = current.left;
                            else parent.right = current.left;

                            current = null;
                        }
                        else if (current.right != null && current.left == null)
                        {
                            //one child on the right of current to move 
                            //up to parent/replace current
                            if (left == true) parent.left = current.right;
                            else parent.right = current.right;

                            current = null;

                        }
                        else
                        {
                            //we have two children!
                            if (left == true) parent.left = current.left;
                            else parent.right = current.left;

                            // End of Code we started today
                        }
                    }

                    //traverse the tree (value < current.value)
                    if (current.value > toDelete.value)
                    {
                        //change current to left child
                        current = current.left;
                        // System.Console.WriteLine("left");
                        left = true;
                    }
                    else if (current.value < toDelete.value)
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
                    parent.left = new Node(toDelete.value);
                }
                else
                {
                    //     Console.WriteLine(value);
                    parent.right = new Node(toDelete.value);
                }
            }
        }
    }
}
