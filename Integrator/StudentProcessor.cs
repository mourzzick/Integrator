using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Integrator
{
    class StudentProcessor
    {
        public async Task<List<Student>> GetStudentsAsync(string applicationCode)
        {
            string url = string.Empty;

            if (string.IsNullOrEmpty(applicationCode))
            {
                throw new ArgumentOutOfRangeException("Application code should not be null or empty.");
            }

            url = $" http://localhost:3010/ideal/v1/course/{applicationCode}/students";

            using (HttpResponseMessage response = await ApiHelper.httpClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<Student> students = await response.Content.ReadAsAsync<List<Student>>();
                    return students;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
