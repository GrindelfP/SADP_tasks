using System;

namespace taskSix
{
    public partial class Tree
    {
        public class Node<T>
        {
            private Node<T> _left;
            private Node<T> _right;
            public Node<T> Left 
            { 
                get { return _left; } 
                set { _left = value; ChangeType(); } 
            }

            public Node<T> Right
            {
                get { return _right; }
                set { _right = value; ChangeType(); }
            }

            public T Data { get; }
            public NodeType Type { get; private set; }

            public Node(T data)
            {
                Data = data;
                Type = NodeType.LEAF;
            }

            public Node(T data, Node<T> sidedValue, bool forLeft)
            {
                switch (forLeft)
                {
                    case true:
                        _left = sidedValue;
                        _right = null;
                        break;
                    default:
                        _left = null;
                        _right = sidedValue;
                        break;
                }
                Data = data;
                Type = NodeType.UNARY_INODE;
            }

            public Node(T data, Node<T> left, Node<T> right)
            {
                _left = left;
                _right = right;
                Data = data;
                Type = NodeType.BINARY_INODE;
            }
            private void ChangeType()
            {
                if (_left != null || _right != null) Type = NodeType.UNARY_INODE;
                if (_left != null && _right != null) Type = NodeType.BINARY_INODE;
                if (_left == null && _right == null) Type = NodeType.LEAF;
            }

            public Node<T> Next()
            {
                if (Type == NodeType.BINARY_INODE) throw new Exception("Call of Next() method for a double inode!");
                if (Type == NodeType.LEAF) return null;
                switch (_left)
                {
                    case null:
                        return _right;
                    default:
                        return _left;
                }
            }
        }

        public enum NodeType
        {
            LEAF,
            UNARY_INODE,
            BINARY_INODE
        }
    }
}