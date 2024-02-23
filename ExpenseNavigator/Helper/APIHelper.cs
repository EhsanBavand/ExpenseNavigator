using System.Net.Http.Headers;

namespace ExpenseNavigator.Helper
{
    public class APIHelper
    {
        public static async Task<string> GetData(string baseUrl, string url)
        {
            var resunt = "";
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                //JsonContent content = JsonContent.Create(data);
                HttpResponseMessage Res = await client.GetAsync(url);
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var res = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    return res;
                }
            }

            return resunt;
        }

        public static async Task<string> PostData(string baseUrl, string url, StringContent content)
        {
            var resunt = "";
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();

                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                //JsonContent content = JsonContent.Create(data);
                HttpResponseMessage Res = await client.PostAsync(url, content);

                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var res = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list
                    return res;
                }
            }
            return resunt;
        }
    }
}
