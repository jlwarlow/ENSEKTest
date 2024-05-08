using System.Configuration;
using System.Text;
using TestClient.Properties;

namespace TestClient
{
    public class ReadingTest : ITest
    {
        public async Task Run()
        {
            var url = ConfigurationManager.AppSettings["BaseUrl"] + "/meter-reading-uploads";
            var csv = Resources.Meter_Reading_2;
            var csvStringContent = new StringContent(csv, Encoding.UTF8, "text/plain");

            using var client = new HttpClient();
            var result = await client.PostAsync(url, csvStringContent);
            Console.WriteLine(result.ToString());
        }
    }
}
