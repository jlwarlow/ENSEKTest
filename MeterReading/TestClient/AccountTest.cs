using System.Configuration;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using TestClient.Properties;

namespace TestClient
{
    public class AccountTest : ITest
    {
        public async Task Run()
        {
            
            var url = ConfigurationManager.AppSettings["BaseUrl"] + "/Account";
            var csv = Resources.Test_Accounts_2;
            var csvStringContent = new StringContent(csv, Encoding.UTF8, "text/plain");

            using var client = new HttpClient();
            var result = await client.PostAsync(url, csvStringContent);
            Console.WriteLine(result.ToString());
        }
    }
}
