using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrator
{
    public class LadokDataTransferObject
    {
        [JsonProperty("courseCode")]
        public string CourseCode { get; set; }

        [JsonProperty("examination")]
        public string Examination { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("listOfGrades")]
        public List<StudentGradeObject> StudentGradeObjectList { get; set; }

        public LadokDataTransferObject()
        {
            CourseCode = string.Empty;
            Examination = string.Empty;
            Date = string.Empty;
            StudentGradeObjectList = new List<StudentGradeObject>();
        }
    }
    

}
