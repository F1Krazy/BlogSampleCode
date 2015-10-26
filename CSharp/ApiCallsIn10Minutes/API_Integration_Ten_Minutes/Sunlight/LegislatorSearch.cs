using API_Integration_Ten_Minutes.Sunlight.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace API_Integration_Ten_Minutes.Sunlight
{
    public class LegislatorSearch
    {
        public static async Task<List<Legislator>> GetLegislator(string name)
        {
            string apiUrl = "http://congress.api.sunlightfoundation.com/legislators?first_name=";
            string apiKey = "[insert your API key here]";

            using (var client = new HttpClient())
            {
                string repUrl = apiUrl + name + "&apikey=" + apiKey;
                HttpResponseMessage response = await client.GetAsync(repUrl);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    var rootResult = JsonConvert.DeserializeObject<RootObject>(result);
                    return rootResult.results;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
