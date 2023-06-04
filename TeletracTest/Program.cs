using System.Net.NetworkInformation;

namespace TeletracTest
{
    internal class Program
    {
        string apikey = "41323cfb5c15295e4d3af099070d312a";
        string gps = "true";
        string pruning = "APP";
        static void Main(string[] args)
        {

            GetHTTP();
            //await Task<string> reply =  s.PingAsync().ConfigureAwait(false);
            Console.Read();
        }



        async static void GetHTTP()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Send the GET request
                    HttpResponseMessage response = await client.GetAsync("https://api-au.telematics.com/v1/vehicles/stats?gps=true&pruning=APP&key=41323cfb5c15295e4d3af099070d312a");

                    // Check the response status
                    if (response.IsSuccessStatusCode)
                    {
                        // Read the response content
                        string responseContent = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Request successful. Response:");
                        Console.WriteLine(responseContent);
                    }
                    else
                    {
                        Console.WriteLine("Request failed. Status code: " + response.StatusCode);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
        }


        void PostHTTP()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Prepare the data to be sent in the request body
                    var data = new { Name = "John", Age = 30 };

                    // Convert the data to JSON
                    string json = "";// Newtonsoft.Json.JsonConvert.SerializeObject(data);

                    // Create the request content
                    var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    // Send the POST request
                    HttpResponseMessage response;//= await client.PostAsync("http://example.com/api/endpoint", content);

                    // Check the response status
                    //            if (response.IsSuccessStatusCode)
                    //            {
                    // Read the response content
                    //                 string responseContent = await response.Content.ReadAsStringAsync();
                    //                  Console.WriteLine("Request successful. Response:");
                    //                 Console.WriteLine(responseContent);
                    //               }
                    //               else
                    //               {
                    //                   Console.WriteLine("Request failed. Status code: " + response.StatusCode);
                    //               }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
        }
    }

}