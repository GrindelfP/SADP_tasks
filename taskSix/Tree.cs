using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace taskSix
{
    public partial class Tree
    {
        private Node<Movie> _root;

        public Tree()
        {
            _root = null;
        }

        public bool Add(Movie data) // works
        {
            Node<Movie> newNode = new Node<Movie>(data);
            if (_root == null)
            {
                _root = newNode;
                return true;
            }
            Node<Movie> currentNode = _root;
            while (currentNode != null)
            {
                if (currentNode.Data.Duration == newNode.Data.Duration) break;
                if (currentNode.Data.Duration > newNode.Data.Duration)
                {
                    if (currentNode.Left == null)
                    {
                        currentNode.Left = newNode;
                        return true;
                    }
                    if (currentNode.Left != null)
                    {
                        currentNode = currentNode.Left;
                        continue;
                    }
                    return true; // do we need it?
                }
                else
                {
                    if (currentNode.Right == null)
                    {
                        currentNode.Right = newNode;
                        return true;
                    }
                    if (currentNode.Right != null)
                    {
                        currentNode = currentNode.Right;
                        continue;
                    }
                    return true; // do we need it?
                }
            }
            return false;
        }

        public Movie Find(int key)
        {
            List<object> found = InternalSearch(key);
            if (found == null) return null;
            Node<Movie> data = found[0] as Node<Movie>;
            return data.Data;
        }
        public bool Remove(int key)
        {
            bool rootPositioned = false;
            List<object> removableAndPrevious = InternalSearch(key);
            Node<Movie> removable = removableAndPrevious[0] as Node<Movie>;
            List<object> previousAndInfo = removableAndPrevious[1] as List<object>;
            Node<Movie> previous = previousAndInfo[0] as Node<Movie>;
            bool isLeft = previousAndInfo[1] as string == "yes";
            if (removable == null) return false;
            if (removable == _root) rootPositioned = true;
            // for leaf type of the node
            if (removable.Type == NodeType.LEAF) return LeafRemove(rootPositioned, isLeft, previous); ;
            // for unary inode type of the node
            if (removable.Type == NodeType.UNARY_INODE) return UnaryInodeRemove(isLeft, previous, removable);
            // for binary inode type of the node
            return BinaryInodeRemove(isLeft, previous, removable);
        }

        public void Visualize(ListBox listBox)  // works
        {
            listBox.Items.Clear();
            Show(listBox, 1, _root, "");
        }
        
        private List<object> InternalSearch(int key)
        {
            if (_root == null) return null;
            Node<Movie> currentNode = _root;
            List<object> previous = null;
            while (currentNode != null)
            {
                if (currentNode.Data.Duration == key) return new List<object>() { currentNode, previous };
                if (currentNode.Data.Duration < key)
                {
                    if (currentNode.Left == null) return null;
                    if (currentNode.Left.Data.Duration == key) previous = new List<object>() { currentNode, "yes" };
                    currentNode = currentNode.Left;
                    continue;
                }
                if (currentNode.Data.Duration > key)
                {
                    if (currentNode.Right == null) return null;
                    if (currentNode.Right.Data.Duration == key) previous = new List<object>() { currentNode, null };
                    currentNode = currentNode.Right;
                    continue;
                }
            }
            return null;
        }

        private void Show(ListBox listBox, int numberOfLevel, Node<Movie> currentNode, string space) // works
        {
            if (_root == null) return;
            string visualization = space;
            visualization += numberOfLevel.ToString() + " " + currentNode.Data.ToString();
            listBox.Items.Add(visualization);
            //bool noLeft = false;
            //if (currentNode.Left == null) noLeft = true;
            if (currentNode.Left != null) Show(listBox, numberOfLevel + 1, currentNode.Left, " <-");
            //if (currentNode.Right == null) return;
            if (currentNode.Right != null) Show(listBox, numberOfLevel + 1, currentNode.Right, " ->");
        }

        private bool LeafRemove(bool rootPositioned, bool isLeft, Node<Movie> previous)
        {
            if (rootPositioned) _root = null;
            if (isLeft) previous.Left = null;
            previous.Right = null;
            return true;
        }

        private bool UnaryInodeRemove(bool isLeft, Node<Movie> previous, Node<Movie> removable)
        {
            if (isLeft) previous.Left = removable.Next();
            previous.Right = removable.Next();
            return true;
        }

        private bool BinaryInodeRemove(bool isLeft, Node<Movie> previous, Node<Movie> removable)
        {
            throw new NotImplementedException();
        }
    }
}