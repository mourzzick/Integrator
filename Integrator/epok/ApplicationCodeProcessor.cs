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
        private string FormatCourseCode(string courseCode)
        {
            if (string.IsNullOrEmpty(courseCode))
            {
                return string.Empty;
            }
            courseCode = courseCode.Trim().ToLower();
            return courseCode;
        }

        private string FormatPeriod(string period)
        {
            if (string.IsNullOrEmpty(period))
            {
                return string.Empty;
            }
            period = period.Trim().ToLower();
            return period;
        }

        public async Task<string> GetApplicationCodeAsync(string courseCode, string period)
        {
            string url = string.Empty;
            courseCode = FormatCourseCode(courseCode);
            period = FormatPeriod(period);

            if (string.IsNullOrEmpty(courseCode) || string.IsNullOrEmpty(period))
            {
                throw new ArgumentOutOfRangeException("Course code and semester should not be null or empty.");
            }

            url = $"http://localhost:3005/epok/v1/registrationcode?coursecode={courseCode}&semestercode={period}";

            using (HttpResponseMessage response = await ApiHelper.httpClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    EpokDataTransferObject info = await response.Content.ReadAsAsync<EpokDataTransferObject>();
                    return info.ApplicationCode;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

    }
}
