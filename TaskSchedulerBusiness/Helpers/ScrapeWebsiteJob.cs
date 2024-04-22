using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSchedulerBusinessRW.Helpers
{
    public class ScrapeWebsiteJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            string url = context.JobDetail.JobDataMap.GetString("Url");

            using (HttpClient client = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Head, url);
                HttpResponseMessage response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Ping exitoso al sitio web: " + url);
                }
                else
                {
                    Console.WriteLine($"Error al realizar el ping al sitio web: {response.StatusCode}");
                }
            }
        }
    }
}
