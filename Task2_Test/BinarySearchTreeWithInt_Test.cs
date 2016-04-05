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
        public void InitializeTreeWithType_Test()
        {     
            var tree = new BinarySearchTree<int>();
            var list = intTC.GetList(random).ToList();
            foreach (var item in list)
                tree.Add(item);
            foreach (var item in list)
                Assert.IsTrue(tree.IsExist(item));

            var tree1 = new BinarySearchTree<Book>();
            var list1 = bookTC.GetList(random).ToList();
            foreach (var item in list1)
                tree1.Add(item);
            foreach (var item in list1)
                Assert.IsTrue(tree1.IsExist(item));

            var tree2 = new BinarySearchTree<Point>(pointTC.Comparison());
            var list2 = pointTC.GetList(random).ToList();
            foreach (var item in list2)
                tree2.Add(item);
            foreach (var item in list2)
                Assert.IsTrue(tree2.IsExist(item));

            var tree3 = new BinarySearchTree<string>();
            var list3 = stringTC.GetList(random).ToList();
            foreach (var item in list3)
                tree3.Add(item);
            foreach (var item in list3)
                Assert.IsTrue(tree3.IsExist(item));
        }

        [Test]
        public void PreorderTreeWitnIntType_Test()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            List<int> list = intTC.GetList(random).ToList();
            foreach (var item in list)
                tree.Add(item);
            list.Sort();
            var result = tree.PreorderPass().ToList();
            Assert.AreEqual(result, list);
        }

        [Test]
        public void OrderTreeWitnIntType_Test()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            List<int> list = intTC.GetList(random).ToList();
            foreach (var item in list)
                tree.Add(item);
            var result = tree.OrderPass().ToList();
            Assert.AreEqual(result.Count, list.Count);
        }

        [Test]
        public void PostorderTreeWitnIntType_Test()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            List<int> list = intTC.GetList(random).ToList();
            foreach (var item in list)
                tree.Add(item);
            list.Sort((x, y) => -x.CompareTo(y));
            var result = tree.PostorderPass().ToList();
            Assert.AreEqual(result.Count, list.Count);
        }

        [Test]
        public void FindWithIntType_Test()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            List<int> list = intTC.GetList(random).ToList();
            foreach (var item in list)
                tree.Add(item);
            foreach (var item in list)
                Assert.AreEqual(tree.Find(item), item);
        }

        [Test]
        public void MaxWithIntType_Test()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            List<int> list = intTC.GetList(random).ToList();
            foreach (var item in list)
                tree.Add(item);
            Assert.AreEqual(tree.Max(), list.Max());
        }

        [Test]
        public void MinWithIntType_Test()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            List<int> list = intTC.GetList(random).ToList();
            foreach (var item in list)
                tree.Add(item);
            Assert.AreEqual(tree.Min(), list.Min());
        }

        [Test]
        public void RemoveWithIntType_Test()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            List<int> list = intTC.GetList(random).ToList();
            foreach (var item in list)
                tree.Add(item);
            int itemIndex = random.Next(list.Count);
            tree.Remove(list[itemIndex]);
            Assert.IsFalse(tree.IsExist(list[itemIndex]));
            var result = tree.PreorderPass().ToList();
            list.RemoveAt(itemIndex);
            list.Sort();
            Assert.AreEqual(result, list);
        }
    }
}
