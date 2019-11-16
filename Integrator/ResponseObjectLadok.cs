using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrator
{
    public class ResponsObjectLadok
    {
        [JsonProperty("courseCode")]
        public string CourseCode { get; set; }

        [JsonProperty("examination")]
        public string Examination { get; set; }

        [JsonProperty("date")]
        public String Date { get; set; }

        [JsonProperty("listOfGrades")]
        public List<ListOfGrade> ListOfGrades { get; set; }

        public ResponsObjectLadok()
        {
            Examination = String.Empty;
            ListOfGrades = new List<ListOfGrade>();
        }
    }
    

}
