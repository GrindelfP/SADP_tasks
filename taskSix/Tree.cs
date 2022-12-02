using System.Windows.Forms;

namespace taskSix
{
    public partial class Tree
    {
        private Node<Movie> _root;

        public Tree() { _root = null; }

        /// <summary>
        /// <para>This method adds an elenent to an ordered binary tree without breaking its order.
        /// Especially this implementation of the method is working with elements of the tree of type Movie
        /// and adds it to the tree sorting it by duration, and if duration is simmilar, by name.
        /// If you try to add movie of a simmilar name and duration it won't do anything, because
        /// there is no more comparable information in a Movie type and the tree does accept only unique element.</para>
        /// </summary>
        public bool Add(Movie data)
        {
            bool isAdded = false;
            Node<Movie> newNode = new Node<Movie>(data);
            if (_root == null)
            {
                _root = newNode;
                isAdded = true;
            }
            else
            {
                Node<Movie> currentNode = _root;
                while (currentNode != null && currentNode.Data != newNode.Data)
                {
                    if (currentNode.Data > newNode.Data)
                    {
                        var processingNode = currentNode.Left;
                        isAdded = AddToSubtree(ref processingNode, newNode);
                        if (isAdded) { currentNode.Left = processingNode; break; }
                        else currentNode = currentNode.Left; continue;
                    }
                    else
                    {
                        var processingNode = currentNode.Right;
                        isAdded = AddToSubtree(ref processingNode, newNode);
                        if (isAdded) { currentNode.Right = processingNode; break; }
                        else currentNode = currentNode.Right; continue;
                    }
                }
            }

            return isAdded;
        }

        /// <summary>
        /// <para>This method finds occurances of a movie with duration equal to the key passed as a parameter,
        /// and returns found occurance or null if there is no such movie in the tree.</para>
        /// </summary>
        public Movie Find(int key)
        {
            Movie foudData = null;
            if (_root != null)
            {
                Node<Movie> currentNode = _root;
                while (currentNode != null && currentNode.Data.Duration == key)
                {
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
                if (currentNode.Data.Duration == key) foudData = currentNode.Data;
            }

            return foudData;
        }

        /// <summary>
        /// <para>This method removes an occurance of a movie from the tree with duration equal to the key passed
        /// as a parameter, and returns true if the deletion was succesful and false if not.</para>
        /// </summary>
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

        private bool AddToSubtree(ref Node<Movie> subtreeTop, Node<Movie> newNode)
        {
            bool added = false;
            if (subtreeTop == null)
            {
                subtreeTop = newNode;
                added = true;
            }
            return added;
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