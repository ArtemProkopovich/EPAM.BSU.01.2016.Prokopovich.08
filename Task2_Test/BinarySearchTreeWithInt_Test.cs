using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit;
using Task2_Tree;
using Task2_Test.TestCase;

namespace Task2_Test
{
    [TestFixture]
    public class BinarySearchTreeWithInt_Test
    {
        private Random random = new Random();
        private static IntTestCase intTC = new IntTestCase();
        private static StringTestCase stringTC = new StringTestCase();
        private static PointTestCase pointTC = new PointTestCase();
        private static BookTestCase bookTC = new BookTestCase();


        [Test]
        [TestCase(typeof(int))]
        [TestCase(typeof(string))]
        [TestCase(typeof(Book))]
        [TestCase(typeof(Point))]
        public void InitializeTreeWithType_Test<T>(Type type)
        {     
            var tree = new BinarySearchTree<int>();
            var list = tc.GetList(random).ToList();
            foreach (var item in list)
                tree.Add(item);
            foreach (var item in list)
                Assert.IsTrue(tree.IsExist(item));
        }

        [Test]
        public void PreorderTreeWitnIntType_Test()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            List<int> list = GetIntList().ToList();
            foreach (var item in list)
                tree.Add(item);
            list.Sort();
            var result = tree.PreorderPass().Select(e => e.Value).ToList();
            Assert.AreEqual(result, list);
        }

        [Test]
        public void OrderTreeWitnIntType_Test()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            List<int> list = GetIntList().ToList();
            foreach (var item in list)
                tree.Add(item);
            var result = tree.OrderPass().Select(e => e.Value).ToList();
            Assert.AreEqual(result.Count, list.Count);
        }

        [Test]
        public void PostorderTreeWitnIntType_Test()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            List<int> list = GetIntList().ToList();
            foreach (var item in list)
                tree.Add(item);
            list.Sort((x, y) => -x.CompareTo(y));
            var result = tree.PostorderPass().Select(e => e.Value).ToList();
            Assert.AreEqual(result.Count, list.Count);
        }

        [Test]
        public void FindWithIntType_Test()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            List<int> list = GetIntList().ToList();
            foreach (var item in list)
                tree.Add(item);
            foreach (var item in list)
                Assert.AreEqual(tree.Find(item).Value, item);
        }

        [Test]
        public void MaxWithIntType_Test()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            List<int> list = GetIntList().ToList();
            foreach (var item in list)
                tree.Add(item);
            Assert.AreEqual(tree.Max(), list.Max());
        }

        [Test]
        public void MinWithIntType_Test()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            List<int> list = GetIntList().ToList();
            foreach (var item in list)
                tree.Add(item);
            Assert.AreEqual(tree.Min(), list.Min());
        }

        [Test]
        public void RemoveWithIntType_Test()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            List<int> list = GetIntList().ToList();
            foreach (var item in list)
                tree.Add(item);
            int itemIndex = random.Next(list.Count);
            tree.Remove(list[itemIndex]);
            Assert.IsFalse(tree.IsExist(list[itemIndex]));
            var result = tree.PreorderPass().Select(e => e.Value).ToList();
            list.RemoveAt(itemIndex);
            list.Sort();
            Assert.AreEqual(result, list);
        }
    }
}
