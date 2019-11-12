using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrator
{
    public class Student
    {
        [JsonProperty("ideal")]
        public string Ideal { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [JsonProperty("student")]
        public string NationalIdentificationNumber { get; set; }
        public string ApplicationCode { get; set; }
        public Assignment Assignment { get; set; }

        public Student()
        {
            Assignment = new Assignment();
        }
    }
}
