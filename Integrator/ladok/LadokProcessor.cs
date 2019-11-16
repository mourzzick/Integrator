using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Integrator.ladok
{
    class LadokProcessor
    {
        public async Task<string> PostGrades(LadokDataTransferObject responsObject)
        {
            string url = string.Empty;

            url = $"http://ec2-3-134-97-177.us-east-2.compute.amazonaws.com:3000/ladok/v1/grades";

            using (HttpResponseMessage response = await ApiHelper.httpClient.PostAsJsonAsync(url, responsObject))
            {
                if (response.IsSuccessStatusCode)
                {
                    string x = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(x);
                    return x;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
