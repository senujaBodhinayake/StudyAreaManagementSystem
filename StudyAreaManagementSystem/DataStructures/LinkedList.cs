using StudyAreaManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyAreaManagementSystem.DataStructures
{
    public class Node
    {
        public Student Data;
        public Node Next;

        public Node(Student data)
        {
            this.Data = data;
            this.Next = null;
        }
    }

    public class UserLinkedList
    {
        private Node head;

        public void Add(Student student)
        {
            Node newNode = new Node(student);
            if (head == null)
            { head = newNode; }
            else
            {
                Node temp = head;
                while (temp.Next != null)
                { temp = temp.Next; }
                temp.Next = newNode;
            }
        }

        public Student Find(int id)
        {
            Node temp = head;
            while (temp != null)
            {
                if (temp.Data.ID == id)
                { return temp.Data; }
                temp = temp.Next;
            }
            return null;
        }

        public void SortStudentsByID()
        {
            head = MergeSort(head);
        }

        private Node MergeSort(Node node)
        {
            if (node == null || node.Next == null) return node;
            Node middle = GetMiddle(node);
            Node nextToMiddle = middle.Next;
            middle.Next = null;
            Node left = MergeSort(node);
            Node right = MergeSort(nextToMiddle);
            return Merge(left, right);
        }

        private Node GetMiddle(Node node)
        {
            if (node == null) return node;
            Node slow = node, fast = node.Next;
            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }
            return slow;
        }

        private Node Merge(Node left, Node right)
        {
            if (left == null) return right;
            if (right == null) return left;
            if (left.Data.ID <= right.Data.ID)
            {
                left.Next = Merge(left.Next, right);
                return left;
            }
            else
            {
                right.Next = Merge(left, right.Next);
                return right;
            }
        }

        public void Display()
        {
            Node temp = head;
            while (temp != null)
            {
                Console.WriteLine($"Student ID: {temp.Data.ID}, Name: {temp.Data.Name}");
                temp = temp.Next;
            }
        }
    }
}

