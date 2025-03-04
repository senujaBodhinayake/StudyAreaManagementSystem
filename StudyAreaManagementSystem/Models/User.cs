using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyAreaManagementSystem.Models
{
    public abstract class User
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public User(int id, string name)
        {  ID = id; Name = name; }
        public abstract void DisplayInfo();
    }
}
