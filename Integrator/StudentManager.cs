using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrator
{
    public class StudentManager
    {
        List<Student> students = StudentDAO.GetStudents();

        private void MatchNationalIdentificationNumberByIdeal(Student idealStudent)
        {
            foreach (Student integratorStudent in students)
            {
                if (integratorStudent.Ideal.Equals(idealStudent.Ideal))
                {
                    integratorStudent.NationalIdentificationNumber = idealStudent.NationalIdentificationNumber;
                }
            }
        }


        public async Task<List<Student>> LoadStudents(string applicationCode)
        {
            StudentProcessor studentProcessor = new StudentProcessor();

            List<Student> idealStudents = await studentProcessor.GetStudentsAsync(applicationCode);
            foreach (Student student in idealStudents)
            {
                MatchNationalIdentificationNumberByIdeal(student);
                
            }
            AddApplicationCode(applicationCode);
            return this.students;
        }

        private void AddApplicationCode(string applicationCode)
        {
            foreach (Student student in students)
            {
                if (!string.IsNullOrEmpty(student.NationalIdentificationNumber))
                {
                    student.ApplicationCode = applicationCode;
                }
            }
        }





    }
}
