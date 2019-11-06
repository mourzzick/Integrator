using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrator
{
    public class Student
    {
        public string Ideal { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalIdentificationNumber { get; set; }
        public string CourseRegistrationNumber { get; set; }
        public Assignment Assignment { get; set; }
    }
}
