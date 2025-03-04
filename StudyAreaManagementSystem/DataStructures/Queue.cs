using StudyAreaManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyAreaManagementSystem.DataStructures
{
    public class QueueNode
    {
        public Student? Data;
        public QueueNode? Next;

        public QueueNode(Student data) 
        {
            this.Data = data;
            this.Next = null;
        }

    }
    public class waitingListQueue
    {
        private QueueNode front, rear;
        public int count;

        public waitingListQueue()
        {
            front = rear = null;
            count = 0;
        }
        public void Enqueue(Student student)
        {
            QueueNode newNode = new QueueNode(student);
            if (rear == null)
            { front = rear = newNode; }
            else
            {
                rear.Next = newNode;
                rear = newNode;
            }
            count++;
        }
        public Student Dequeue()
        {
            if (front == null)
                return null;
            Student student=front.Data;
            front = front.Next;
            if (front == null)
            { rear = null; }
            count--;
            return student;
        }
        public bool HasNext()
        { return front != null; }
    }
}
