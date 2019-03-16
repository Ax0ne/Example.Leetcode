using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Leetcode.DataStructure
{
    public class BinarySearchTree
    {
        private Node _root;

        public Node GetRoot()
        {
            return _root;
        }
        public void Insert(int value)
        {
            if (_root == null)
            {
                _root = new Node(value);
                return;
            }

            var tree = _root;
            while (tree != null)
            {
                if (value < tree.Data)
                {
                    if (tree.Left == null)
                    {
                        tree.Left = new Node(value);
                        return;
                    }
                    tree = tree.Left;
                }
                else
                {
                    if (tree.Right == null)
                    {
                        tree.Right = new Node(value);
                        return;
                    }
                    tree = tree.Right;
                }
            }
        }

        public Node Find(int value)
        {
            if (_root == null)
                return null;
            var node = _root;
            while (node != null)
            {
                if (value < node.Data) node = node.Left;
                else if (value > node.Data) node = node.Right;
                else return node;
            }

            return null;
        }

        public void Delete(int value)
        {
            // 几种情况：1.删除的节点有左右子节点 2.删除的节点是叶子节点或有单个子节点 3.删除的是根节点
            // 找到节点和它的父节点
            Node target = null;
            Node parentNode = null;
            Node node = _root;
            while (node != null)
            {
                parentNode = node;
                if (value < node.Data) node = node.Left;
                else if (value > node.Data) node = node.Right;
                if (value == node.Data)
                {
                    target = node;
                    break;
                }
            }

            if (target == null)
                return;
            // 情况 1
            if (target.Left != null && target.Right != null)
            {
                var rn = target.Right; // 查找右子树
                var pn = target;
                while (rn.Left != null) // 查找右子树最小的节点
                {
                    pn = rn;
                    rn = rn.Left;
                }
                // 替换目标节点
                target.Data = rn.Data;
                target = rn;
                parentNode = pn;
            }
            // 情况 2
            Node child = null;
            if (target.Left != null) child = target.Left;
            else if (target.Right != null) child = target.Right;
            if (parentNode == null) _root = child;
            else if (parentNode.Left == target) parentNode.Left = child;
            else parentNode.Right = child;
        }

        public void MiOrder(Node node)
        {
            if (node == null)
                return;
            MiOrder(node.Left);
            Console.WriteLine(node.Data);
            MiOrder(node.Right);
        }

        public Node GetMin()
        {
            var node = _root;
            while (node.Left != null)
            {
                node = _root.Left;
            }

            return node;
        }
        public Node GetMax()
        {
            var node = _root;
            while (node.Right != null)
            {
                node = _root.Right;
            }

            return node;
        }
        public class Node
        {
            public int Data;
            public Node Left;
            public Node Right;

            public Node(int value)
            {
                Data = value;
            }
        }
    }
}
