using System.Collections;
using System.Reflection.Metadata.Ecma335;

namespace Graph
{
    public class Tree<T> : IEnumerable
    {
        internal Node root = null;

        protected int lastNodeIndex;

        public int Length = 0;

        public void Add(T data)
        {
            AddTo(lastNodeIndex, data);
        }

        public void AddTo(int nodeIndex, T data)
        {
            if (nodeIndex > Length || nodeIndex < 0) throw new IndexOutOfRangeException();

            if (root == null)
            {
                root = new Node(data, Length);
                return;
            }

            GetNode(nodeIndex, root).nextNodes.Add(new Node(data, ++Length));

            lastNodeIndex = Length;
            
        }

        private Node GetNode(int nodeIndex, Node? currentNode = null)
        {
            if (root is null) throw new Exception("there is no root");

            Node currNode = currentNode is null ? root : currentNode;

            if (nodeIndex == currNode.number) return currNode;

            foreach (var node in currentNode.nextNodes)
            {
                var foundNode = GetNode(nodeIndex, node);

                if (foundNode != null) return foundNode;
            }

            return null;
        }

        public IEnumerator<Node> GetEnumerator()
        {
            return new TreeEnumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public class Node
        {
            internal readonly int number;
            internal T data { get; set; }

            internal List<Node> nextNodes = new List<Node>();
            internal List<Node> prevNodes = new List<Node>();

            public Node(T val, int num)
            {
                data = val;
                number = num;
            }
        }
    }

    public class TreeEnumerator<T> : IEnumerator<Tree<T>.Node>
    {
        private Tree<T> _tree;

        private Queue<Tree<T>.Node> queue = new Queue<Tree<T>.Node>();

        private Tree<T>.Node current = null!;

        public TreeEnumerator(Tree<T> tree)
        {
            _tree = tree;
            Reset();
        }

        public Tree<T>.Node Current => current;

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            
        }

        public bool MoveNext()
        {
            if (queue.Count == 0) return false;

            current = queue.Dequeue();
                                                        // тут основная логика перебора узлов
            foreach (var node in current.nextNodes)
            {
                queue.Enqueue(node);
            }

            return true;
        }

        public void Reset()
        {
            queue = new Queue<Tree<T>.Node>();

            if (_tree.root != null)
            {
                queue.Enqueue(_tree.root);
            }

            current = null;
        }
    }

    public class Program
    {
        public static void Main()
        {
            var tree = new Tree<string>();

            tree.Add("Корень");

            tree.AddTo(0, "Первый лист корня");

            tree.AddTo(0, "Второй лист корня");

            tree.Add("Лист второго листа корня");

            tree.AddTo(2, "Eще один лист второго листа корня");

            int counter = 0;

            foreach (var node in tree)
            {
                Console.WriteLine(node.number);
                Console.WriteLine(node.data);
                counter++;
            }

            Console.WriteLine($"В дереве содержиться {counter} узлов");
        }
    }
}