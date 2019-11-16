using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrator
{
    public class EpokDataTransferObject
    {
        [JsonProperty("registration_code")]
        public string ApplicationCode { get; set; }

        [JsonProperty("course_code")]
        public string CourseCode { get; set; }

        [JsonProperty("semester")]
        public string Period { get; set; }
    }
}
