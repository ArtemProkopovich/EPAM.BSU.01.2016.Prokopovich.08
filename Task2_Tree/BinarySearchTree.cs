using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_Tree
{


    public class BinarySearchTree<T>
    {

        private class Node<T>
        {
            public Node(T value)
            {
                this.Value = value;
            }

            public T Value { get; set; }
            public Node<T> LeftNode { get; set; }
            public Node<T> RightNode { get; set; }
        }

        private Node<T> root = null;
        private readonly Comparison<T> comparison;

        public BinarySearchTree(IComparer<T> comparer)
        {
            comparison = comparer.Compare;
        }

        public BinarySearchTree(Comparison<T> comparison)
        {
            this.comparison = comparison;
        }

        public BinarySearchTree()
        {
            if (typeof (T).GetInterface("IComparable`1") != null)
            {
                comparison = (x, y) => (x as IComparable<T>).CompareTo(y);
            }
            else
                throw new ArgumentException("");
        }

        public void Add(T item)
        {
            if (item == null)
                throw new ArgumentNullException();
            if (root == null)
            {
                root = new Node<T>(item);
                return;
            }
            Node<T> temp = root;
            Node<T> prev = temp;
            while (temp != null)
            {
                prev = temp;
                temp = comparison(item, temp.Value) < 0 ? temp.LeftNode : temp.RightNode;
            }
            if (comparison(item, prev.Value) < 0)
                prev.LeftNode = new Node<T>(item);
            else
                prev.RightNode = new Node<T>(item);
        }

        public T Find(T item)
        {
            return OrderPass().ToList().Find(node => comparison(node, item) == 0);
        }

        public bool IsExist(T item)
        {
            return OrderPass().Any(node => comparison(node, item) == 0);
        }

        public T Max()
        {
            if (root == null)
                return default(T);
            Node<T> temp = root;
            while (temp.RightNode != null)
                temp = temp.RightNode;
            return temp.Value;

        }

        public T Min()
        {
            if (root == null)
                return default(T);
            Node<T> temp = root;
            while (temp.LeftNode != null)
                temp = temp.LeftNode;
            return temp.Value;
        }

        public void Remove(T item)
        {
            root = Remove(root, item);
        }

        private Node<T> Remove(Node<T> tempRoot, T item)
        {
            if (tempRoot == null)
                return tempRoot;
            if (comparison(item, tempRoot.Value) < 0)
                tempRoot.LeftNode = Remove(tempRoot.LeftNode, item);
            else if (comparison(item, tempRoot.Value) > 0)
                tempRoot.RightNode = Remove(tempRoot.RightNode, item);
            else if (tempRoot.LeftNode != null && tempRoot.RightNode != null)
            {
                Node<T> min = tempRoot.RightNode;
                while (min.LeftNode != null)
                    min = min.LeftNode;
                tempRoot.Value = min.Value;
                tempRoot.RightNode = Remove(tempRoot.RightNode, tempRoot.RightNode.Value);
            }
            else if (tempRoot.LeftNode != null)
                tempRoot = tempRoot.LeftNode;
            else
                tempRoot = tempRoot.RightNode;
            return tempRoot;
        }

        public IEnumerable<T> PreorderPass()
        {
            if (root != null)
                return PreorderPass(root).Select(e => e.Value);
            return new T[0];
        }

        public IEnumerable<T> OrderPass()
        {
            if (root != null)
                return OrderPass(root).Select(e => e.Value);
            return new T[0];
        }

        public IEnumerable<T> PostorderPass()
        {
            if (root != null)
                return PostorderPass(root).Select(e => e.Value);
            return new T[0];
        }

        private IEnumerable<Node<T>> PreorderPass(Node<T> item)
        {
            if (item != null)
            {
                foreach (var t in PreorderPass(item.LeftNode))
                    yield return t;
                yield return item;
                foreach (var t in PreorderPass(item.RightNode))
                    yield return t;
            }
        }

        private IEnumerable<Node<T>> OrderPass(Node<T> item)
        {
            if (item != null)
            {
                yield return item;
                foreach (var t in OrderPass(item.LeftNode))
                    yield return t;
                foreach (var t in OrderPass(item.RightNode))
                    yield return t;
            }
        }

        private IEnumerable<Node<T>> PostorderPass(Node<T> item)
        {
            if (item != null)
            {
                foreach (var t in PostorderPass(item.LeftNode))
                    yield return t;
                foreach (var t in PostorderPass(item.RightNode))
                    yield return t;
                yield return item;
            }
        }
    }
}
