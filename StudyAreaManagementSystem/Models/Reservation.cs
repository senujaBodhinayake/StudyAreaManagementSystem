using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyAreaManagementSystem.Models
{
    public class Reservation
    {
        public Student student {  get; set; }
        public StudyArea studyArea { get; set; }
    }
}
