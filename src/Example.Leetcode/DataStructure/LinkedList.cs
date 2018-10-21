using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Leetcode.DataStructure
{
    // 循环双向链表
    public class LinkedList<T>
    {
        private Node head;

        public void InsertToHead(T value)
        {
            var node = new Node(value);
            if (head == null)
            {
                node.prev = node;
                node.next = node;
                head = node;
            }
            else
            {
                node.next = head;
                node.prev = head.prev;
                // 这里需要先改变尾节点的next指向
                head.prev.next = node;
                head.prev = node;
                head = node; // 注释这行等于添加节点到尾部
            }
        }

        public Node Find(T value)
        {
            if (head == null) return null;
            var node = head;
            while (!node.data.Equals(value))
            {
                if (node.next == null)
                    return null;
                node = node.next;
                if (node == head)
                    return null;
            }
            return node;
        }

        public void Delete(T value)
        {
            var node = Find(value);
            node.prev.next = node.next;
            node.next.prev = node.prev;
        }

        public class Node
        {
            internal Node prev;
            internal Node next;
            internal T data;

            public Node(T value)
            {
                data = value;
            }
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            var node = head;
            while (node != null)
            {
                sb.Append($"{node.data}->");
                node = node.next;
                if (node == head)
                    break;
            }
            return sb.ToString();
        }
    }
}
