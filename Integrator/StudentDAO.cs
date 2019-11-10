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
            students.Add(new Student { Ideal = "rusgeo-7", FirstName = "Ruslan", LastName = "Georgiev", NationalIdentificationNumber = "" });
            students.Add(new Student { Ideal = "mihcob-7", FirstName = "Carl", LastName = "Granström", NationalIdentificationNumber = "" });
            students.Add(new Student { Ideal = "josgus-8", FirstName = "Josefine", LastName = "Gustafsson", NationalIdentificationNumber = "" });
            students.Add(new Student { Ideal = "klahar-7", FirstName = "Fredrik", LastName = "Harnevik", NationalIdentificationNumber = "" });
            students.Add(new Student { Ideal = "sebhay-7", FirstName = "Sebastian", LastName = "Häyry", NationalIdentificationNumber = "" });
            students.Add(new Student { Ideal = "malhar-3", FirstName = "Sebastian", LastName = "Hellström", NationalIdentificationNumber = "" });
            students.Add(new Student { Ideal = "filhuh-7", FirstName = "Filip", LastName = "Huhta", NationalIdentificationNumber = "" });
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
