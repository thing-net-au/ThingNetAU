namespace TeletracNavman
{
    public class Connection
    {
        Uri _Endpoint;
        Dictionary<Channel, string> _Endpoints;
        string _APIKey;
        enum Channel { vehicles }
        enum Pruning { ALL, B2B,LIST, IDS, DEVICES, APP, IAP, WEB, RELATIONS }
        public Connection(Uri Endpoint, string apikey)
        {
            _Endpoint = Endpoint;
            _APIKey = apikey;

            _Endpoints = new Dictionary<Channel, string>();
            _Endpoints.Add(Channel.vehicles, "vehicles");

        }

        async static Task<string> GetHTTP(Channel channel, object[] filters)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Send the GET request

                    

                    HttpResponseMessage response = await client.GetAsync("vehicles/stats?gps=true&pruning=APP&key=41323cfb5c15295e4d3af099070d312a");

                    // Check the response status
                    if (response.IsSuccessStatusCode)
                    {
                        // Read the response content
                        string responseContent = await response.Content.ReadAsStringAsync();
                        return responseContent;
                    }
                    else
                    {
                        return ("Request failed. Status code: " + response.StatusCode);
                    }
                }
                catch (Exception ex)
                {
                    return ("An error occurred: " + ex.Message);
                }
            }
        }


    }
}