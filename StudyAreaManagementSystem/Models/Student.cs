using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyAreaManagementSystem.Models
{
    public class Student : User 
    {
        public Student(int id,string name):base(id,name)
            { }
        public override void DisplayInfo()
        {
            Console.WriteLine($"student:{Name},ID:{ID}");
        }
    }
}
