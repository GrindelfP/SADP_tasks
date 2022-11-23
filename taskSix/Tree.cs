using System.Windows.Forms;

namespace taskSix
{
    public partial class Tree
    {
        private Node<Movie> _root;

        public Tree() { _root = null; }

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
                }
            }
            return false;
        }

        public Movie Find(int key)
        {
            if (_root == null) return null;
            Node<Movie> currentNode = _root;
            while (currentNode != null)
            {
                if (currentNode.Data.Duration == key) return currentNode.Data;
                if (currentNode.Data.Duration > key)
                {
                    if (currentNode.Left == null) return null;
                    currentNode = currentNode.Left;
                    continue;
                }
                if (currentNode.Data.Duration < key)
                {
                    if (currentNode.Right == null) return null;
                    currentNode = currentNode.Right;
                    continue;
                }
            }
            return null;
        }

        public bool Remove(int key)
        {
            if (_root == null) return false;
            Node<Movie> removable = null;
            Node<Movie> previous = null;
            
            // search for the removable element
            bool isLeft = false;
            bool rootPositioned = false;
            if (_root.Data.Duration == key) // root fits
            {
                removable = _root;
                rootPositioned = true;
            } 
            else // root does not fit
            {
                Node<Movie> currentNode = _root;
                while (currentNode.Left != null || currentNode.Right != null)
                {
                    if (currentNode.Left != null && currentNode.Left.Data.Duration == key) 
                    {
                        isLeft = true;
                        removable = currentNode.Left;
                        previous = currentNode;
                        break;
                    } 
                    if (currentNode.Right != null && currentNode.Right.Data.Duration == key) 
                    {
                        removable = currentNode.Right;
                        previous = currentNode;
                        break;
                    } 
                    if (currentNode.Data.Duration > key)
                    {
                        if (currentNode.Left == null) break;
                        currentNode = currentNode.Left;
                        continue;
                    }
                    if (currentNode.Data.Duration < key)
                    {
                        if (currentNode.Right == null) break;
                        currentNode = currentNode.Right;
                        continue;
                    }
                }
            }
            
            // processing the removable element
            if (removable == null) return false;           
            if (removable.Type == NodeType.LEAF) return LeafRemove(rootPositioned, previous, isLeft);
            if (removable.Type == NodeType.UNARY_INODE) return UnaryInodeRemove(rootPositioned, isLeft, previous, removable);
            return BinaryInodeRemove(rootPositioned, isLeft, previous, removable);
        }

        public void Visualize(ListBox listBox) // works
        {
            listBox.Items.Clear();
            Show(listBox, 1, _root, "");
        }
        

        private void Show(ListBox listBox, int numberOfLevel, Node<Movie> currentNode, string space) // works
        {
            if (_root == null) return;
            string visualization = space;
            visualization += numberOfLevel.ToString() + " " + currentNode.Data.ToString();
            listBox.Items.Add(visualization);
            if (currentNode.Left != null) Show(listBox, numberOfLevel + 1, currentNode.Left, " <-");
            if (currentNode.Right != null) Show(listBox, numberOfLevel + 1, currentNode.Right, " ->");
        }

        private bool LeafRemove(bool rootPositioned, Node<Movie> previous, bool isLeft) // works
        {
            if (rootPositioned) _root = null;
            else
            {
                if (isLeft) previous.Left = null;
                else previous.Right = null;
            }
            return true;
        }

        private bool UnaryInodeRemove(bool rootPositioned, bool isLeft, Node<Movie> previous, Node<Movie> removable) // works
        {
            if (rootPositioned)
            {
               _root = removable.Next();
            }
            else
            {
                if (isLeft) previous.Left = removable.Next();
                else previous.Right = removable.Next();
            }
            return true;
        }

        private bool BinaryInodeRemove(bool rootPositioned, bool isLeft, Node<Movie> previous, Node<Movie> removable)
        {
            Node<Movie> replaceable = removable.Left;
            while (replaceable.Right != null) { replaceable = replaceable.Right; }
            Node<Movie> tempor = replaceable;
            tempor.Right = removable.Right;
            Remove(replaceable.Data.Duration);
            if (rootPositioned)
            {
                _root = tempor;
            }
            else
            {
                
                if (isLeft) previous.Left = tempor;
                else previous.Right = tempor;
            }
            
            
            return true;
        }
    }
}