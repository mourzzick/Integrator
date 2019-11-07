using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Integrator
{
    class ApplicationCodeProcessor
    {
        public async Task<string> LoadApplicationCode(string courseCode, string semester)
        {
            string url = string.Empty;
            if (!string.IsNullOrEmpty(courseCode) && !string.IsNullOrEmpty(semester))
            {
                url = $"http://localhost:3005/epok/api/registration-code/{courseCode}-{semester}";
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
            using (HttpResponseMessage response = await ApiHelper.httpClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    // TODO: finish this
                }
            }

            throw new NotImplementedException();
             
        }
        
        // "registration_code": "ltu-22008",
        // "course_code": "d0031n",
        // "semester": "ht16"
    }
}
