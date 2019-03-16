using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DS = Example.Leetcode.DataStructure;

namespace Example.Leetcode
{
    public class UnitTest
    {
        public class TestObj
        {
            public int Value { get; set; }
            public override string ToString()
            {
                return Value.ToString();
            }
        }
        public void TestArray()
        {
            var array = new DS.Array<int>(10);
            for (int i = 0; i < 11; i++)
            {
                array.Insert(i);
            }

            Console.WriteLine("插入");
            Console.WriteLine(array);
            Console.WriteLine($"删除index={0}");
            array.Delete(0);
            Console.WriteLine(array);
            Console.WriteLine($"删除index={5}");
            array.Delete(5);
            Console.WriteLine(array);
            Console.WriteLine($"删除index={7}");
            array.Delete(7);
            Console.WriteLine(array);
        }
        public void TestSingleLinkedList()
        {
            Console.WriteLine("singly linkedlist");
            var instance = new DS.SingleLinkedList<int>();
            for (int i = 0; i < 11; i++)
            {
                instance.Insert(i);
            }
            Console.WriteLine(instance);
            Console.WriteLine("insert before");
            var node = instance.FindNode(5);
            instance.InsertBefore(node, 44);
            Console.WriteLine(instance);
            Console.WriteLine("insert after");
            instance.InsertAfter(node, 999);
            Console.WriteLine(instance);
            Console.WriteLine("delete node");
            instance.Delete(999);
            Console.WriteLine(instance);
            Console.WriteLine("reverse");
            instance.Reverse();
            Console.WriteLine(instance.ToString());
        }
        public void TestLinkedList()
        {
            Console.WriteLine("test linkedlist");
            var instance = new DS.LinkedList<int>();
            for (int i = 0; i < 11; i++)
            {
                instance.InsertToHead(i);
            }
            Console.WriteLine(instance.ToString());
            Console.WriteLine("test find linkedlist");
            var node = instance.Find(5);
            Console.WriteLine($"find 5 equals {node.data}");
            Console.WriteLine("delete node value 4 and 7");
            instance.Delete(4);
            instance.Delete(7);
            Console.WriteLine(instance.ToString());

        }

        public void TestBinaryTree()
        {
            var tree = new DS.BinaryTree<string>("A");
            var root = tree.GetRoot();
            tree.InsertLeft(root, "B");
            tree.InsertRight(root, "C");
            var rleft = root.left;
            tree.InsertLeft(rleft, "D");
            tree.InsertRight(rleft, "E");
            var rRight = root.right;
            tree.InsertLeft(rRight, "End");
            Console.WriteLine("前序遍历");
            tree.PreOrder(root);
            Console.WriteLine("中序遍历");
            tree.MiOrder(root);
            Console.WriteLine("后序遍历");
            tree.PostOrder(root);
        }

        public void TestBinarySearchTree()
        {
            var btree = new DS.BinarySearchTree();
            btree.Insert(5);
            btree.Insert(8);
            btree.Insert(1);
            btree.Insert(3);
            btree.Insert(4);
            btree.Insert(6);
            btree.Insert(7);
            btree.MiOrder(btree.GetRoot());
            Console.WriteLine(btree.Find(5).Data);
            Console.WriteLine(btree.GetMax().Data);
            Console.WriteLine(btree.GetMin().Data);
            btree.Delete(7);
            btree.Delete(3);
            btree.Delete(1);
        }
    }
}
