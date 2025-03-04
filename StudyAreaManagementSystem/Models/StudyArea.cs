using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyAreaManagementSystem.Models
{
    public class StudyArea
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Capacity {  get; set; }
        public int AvailableSeats {  get; set; }
        private List<Student> ReservedStudents;

        public StudyArea(int id, string name, int capacity)
        {  ID = id; 
            Name = name;
            Capacity = capacity;
            AvailableSeats = capacity;
            ReservedStudents = new List<Student>();
        }
        public bool ReserveSeat(Student student)
        {
            if(AvailableSeats > 0)
            {
                
                ReservedStudents.Add(student);
                AvailableSeats--;
                return true;
            }
            return false;
        }
        public bool CancelReservation(Student student)
        {
            if (ReservedStudents.Contains(student))
            {
                ReservedStudents.Remove(student);
                AvailableSeats++;
                return true;
            }
            return false;
        }
        public void showReservedSeats()
        {
            Console.WriteLine($"Study Area: {Name}");
            Console.WriteLine($"Total Seats: {Capacity}, Available:{AvailableSeats}");
            Console.WriteLine($"Reserved Students:");
            if(ReservedStudents.Count==0)
            {
                Console.WriteLine("No resrvations yet");
            }
            else 
            {
                foreach(var student in ReservedStudents)
                {
                    Console.WriteLine($"Student Name:{student.Name} ID:{student.ID}");
                }
            }
        }
    }
}
