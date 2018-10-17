using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Leetcode.DataStructure
{
    public class SingleLinkedList<T>
    {
        private Node head;

        public void Insert(T value)
        {
            var node = new Node(value, null);
            if (head == null)
                head = node;
            else
            {
                node.next = head;
                head = node;
            }
        }
        public void InsertBefore(Node node, T value)
        {
            if (node == head)
                Insert(value);
            else
            {
                var n = new Node(value, node);
                var h = head;
                while (h != null && h.next != node)
                {
                    h = h.next;
                }
                if (h == null) return;
                h.next = n;
            }
        }
        public void InsertAfter(Node node, T value)
        {
            var n = new Node(value, node.next);
            node.next = n;
        }

        public void Delete(T value)
        {
            var node = new Node(value, null);
            var n = head;
            // 实际不能用简单的equals
            while (n.next != null && !n.next.value.Equals(value))
            {
                n = n.next;
            }

            n.next = n.next.next;
        }

        public Node FindNode(T value)
        {
            if (head == null)
                return null;
            if (head.value.Equals(value))
                return head;
            var h = head;
            while (h != null)
            {
                if (h.value.Equals(value))
                    return h;
                h = h.next;
            }

            return null;
        }


        public class Node
        {
            internal T value;
            internal Node next;

            public Node(T value, Node next)
            {
                this.value = value;
                this.next = next;
            }

            //public Node Next => next;
        }

        public override string ToString()
        {
            if (head == null)
                return null;
            var sb = new StringBuilder();
            sb.Append(head.value + "-");
            var node = head.next;
            while (node != null)
            {
                sb.Append(node.value + "-");
                //head = head.next;
                node = node.next;
            }

            return sb.ToString();
        }
    }
}
