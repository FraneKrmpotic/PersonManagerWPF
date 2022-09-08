using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManager.Models
{
    public class Subject
    {
        public int IDSubject { get; set; }
        public string SubjectName { get; set; }
        public int ECTS { get; set; }

        public override string ToString()
            => $"{SubjectName}";
    }
}
