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
        public async Task<string> GetApplicationCodeAsync(string courseCode, string semester)
        {
            string url = string.Empty;
            courseCode = courseCode.ToUpper();
            semester = semester.ToUpper();

            if (string.IsNullOrEmpty(courseCode) || string.IsNullOrEmpty(semester))
            {
                throw new ArgumentOutOfRangeException("Course code and semester should not be null or empty.");
            }

            url = $"http://localhost:3005/epok/api/registration-code/{courseCode}-{semester}";

            using (HttpResponseMessage response = await ApiHelper.httpClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    ApplicationCodeResponse info = await response.Content.ReadAsAsync<ApplicationCodeResponse>();
                    return info.ApplicationCode;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

    }
}
