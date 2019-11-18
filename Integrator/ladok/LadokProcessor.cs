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
        public async Task<Uri> PostGrades(LadokDataTransferObject dataTransferObject)
        {
            string url = $"http://ec2-3-134-97-177.us-east-2.compute.amazonaws.com:3000/ladok/v1/grades";

            using (HttpResponseMessage response = await ApiHelper.httpClient.PostAsJsonAsync(url, dataTransferObject))
            {
                if (response.IsSuccessStatusCode)
                {
                    string s = response.StatusCode.ToString();
                    Console.WriteLine(response.Content);
                    return response.Headers.Location;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
