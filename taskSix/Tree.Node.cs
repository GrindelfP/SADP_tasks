using System;

namespace taskSix
{
    public partial class Tree
    {
        public class Node<T>
        {
            public Node<T> Left { get; set; }
            public Node<T> Right { get; set; }
            public T Data { get; }
            public NodeType Type { get; }

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
                        Left = sidedValue;
                        Right = null;
                        break;
                    default:
                        Left = null;
                        Right = sidedValue;
                        break;
                }
                Data = data;
                Type = NodeType.UNARY_INODE;
            }

            public Node(T data, Node<T> left, Node<T> right)
            {
                Left = left;
                Right = right;
                Data = data;
                Type = NodeType.BINARY_INODE;
            }

            public Node<T> Next()
            {
                if (Type == NodeType.BINARY_INODE) throw new Exception("Call of Next() method for a double inode!");
                if (Type == NodeType.LEAF) return null;
                switch (Left)
                {
                    case null:
                        return Right;
                    default:
                        return Left;
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