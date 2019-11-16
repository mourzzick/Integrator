using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrator
{
    public class StudentGradeObject
    {
        [JsonProperty("student")]
        public string Student { get; set; }

        [JsonProperty("grade")]
        public string Grade { get; set; }
    }
}
