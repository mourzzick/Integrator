using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrator
{
    public static class StudentDAO
    {
        public static List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();
            students.Add(new Student { Ideal = "rusgoe-7", FirstName = "Ruslan", LastName = "Georgiev", NationalIdentificationNumber = "8301281234" });
            students.Add(new Student { Ideal = "cargra-7", FirstName = "Carl", LastName = "Granström", NationalIdentificationNumber = "8606251234" });
            students.Add(new Student { Ideal = "josgus-8", FirstName = "Josefine", LastName = "Gustafsson", NationalIdentificationNumber = "9007091234" });
            students.Add(new Student { Ideal = "frehar-7", FirstName = "Fredrik", LastName = "Harnevik", NationalIdentificationNumber = "8701151234" });
            students.Add(new Student { Ideal = "sebhay-7", FirstName = "Sebastian", LastName = "Häyry", NationalIdentificationNumber = "8506241234" });
            students.Add(new Student { Ideal = "sebhel-7", FirstName = "Sebastian", LastName = "Hellström", NationalIdentificationNumber = "7906211234" });
            students.Add(new Student { Ideal = "filhuh-7", FirstName = "Filip", LastName = "Huhta", NationalIdentificationNumber = "8809151234" });
            students[0].Assignment = new Assignment { AssignmentId = "003", AssignmentGrade = "VG" };
            students[1].Assignment = new Assignment { AssignmentId = "003", AssignmentGrade = "G" };
            students[2].Assignment = new Assignment { AssignmentId = "003", AssignmentGrade = "G" };
            students[3].Assignment = new Assignment { AssignmentId = "003", AssignmentGrade = "G" };
            students[4].Assignment = new Assignment { AssignmentId = "003", AssignmentGrade = "G" };
            students[5].Assignment = new Assignment { AssignmentId = "003", AssignmentGrade = "G" };
            students[6].Assignment = new Assignment { AssignmentId = "003", AssignmentGrade = "G" };
            return students;
        }
    }
}
