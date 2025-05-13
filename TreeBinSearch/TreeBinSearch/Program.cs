namespace BinarySearchTree
{
    public class Node
    {
        public int Value { get; set; }
        public Node Right { get; set; }
        public Node Left { get; set; }

        public Node(int value)
        {
            Value = value;
            Right = null;
            Left = null;
        }
    }

    public class BST
    {
        public Node Root { get; private set; }

        public BST(Node root = null)
        {
            Root = root;
        }

        public bool Contains(int value)
        {
            return Contains(value, Root);
        }

        private bool Contains(int value, Node node)
        {
            if (node == null)
                return false;

            if (node.Value == value)
                return true;

            return value < node.Value
                ? Contains(value, node.Left)
                : Contains(value, node.Right);
        }

        public void Insert(int value)
        {
            Root = Insert(value, Root);
        }

        private Node Insert(int value, Node node)
        {
            if (node == null)
            {
                return new Node(value);
            }

            if (value < node.Value)
            {
                node.Left = Insert(value, node.Left);
            }
            else if (value > node.Value)
            {
                node.Right = Insert(value, node.Right);
            }

            return node;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var bst = new BST();
            bst.Insert(5);
            bst.Insert(3);
            bst.Insert(7);

            Console.WriteLine("Contains 3: " + bst.Contains(3));
            Console.WriteLine("Contains 10: " + bst.Contains(10));
        }
    }
}