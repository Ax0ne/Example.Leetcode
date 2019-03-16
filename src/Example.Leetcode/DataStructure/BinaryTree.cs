using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Leetcode.DataStructure
{
    // 小试牛刀
    public class BinaryTree<T>
    {
        private Node root;

        public BinaryTree(T data)
        {
            root = new Node(data);
        }
        public bool IsEmpty => root == null;

        public Node GetRoot()
        {
            return root;
        }
        public void InsertLeft(Node node, T data)
        {
            var leftNode = new Node(data);
            leftNode.left = node.left;
            node.left = leftNode;
        }

        public void InsertRight(Node node, T data)
        {
            var rightNode = new Node(data);
            rightNode.right = node.right;
            node.right = rightNode;
        }

        public Node RemoveLeft(Node node)
        {
            if (node?.left == null)
                return null;
            var tempNode = node.left;
            node.left = null;
            return tempNode;
        }

        public Node RemoveRight(Node node)
        {
            if (node?.right == null)
                return null;
            var tempNode = node.right;
            node.right = null;
            return tempNode;
        }
        // node->left-right
        public void PreOrder(Node node)
        {
            if (node == null)
                return;
            Console.WriteLine(node.data);
            PreOrder(node.left);
            PreOrder(node.right);
        }
        // left->node->right
        public void MiOrder(Node node)
        {
            if (node == null)
                return;
            MiOrder(node.left);
            Console.WriteLine(node.data);
            MiOrder(node.right);
        }
        // left->right->node
        public void PostOrder(Node node)
        {
            if (node == null)
                return;
            PostOrder(node.left);
            PostOrder(node.right);
            Console.WriteLine(node.data);
        }

        public class Node
        {
            internal T data;
            internal Node left;
            internal Node right;

            public Node(T value)
            {
                data = value;
            }

            public Node(T value, Node left, Node right)
            {
                data = value;
                this.left = left;
                this.right = right;
            }
        }
    }
}
