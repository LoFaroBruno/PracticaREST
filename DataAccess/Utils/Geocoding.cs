using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DataAccess.Utils
{
    public class Geocoding
    {
        private static string APIUrl = "https://forward-reverse-geocoding.p.rapidapi.com/v1/forward?domicilio={0}&city={1}&country=Argentina&accept-language=es-AR";
        
        static HttpClient client = new HttpClient();
        
        public static async Task<(double, double)> FowardGeocoding(string address, string city)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://forward-reverse-geocoding.p.rapidapi.com/v1/forward?street=Arenales%2020&city=Buenos%20Aires&state=Ciudad%20Autonoma%20de%20Buenos%20Aires&postalcode=10011&country=Argentina&accept-language=es-AR&polygon_threshold=0.0"),
            };
            request.Headers.Add("x-rapidapi-host", ConfigurationManager.AppSettings["x-rapidapi-host"]);
            request.Headers.Add("x-rapidapi-key", ConfigurationManager.AppSettings["x-rapidapi-key"]);
            double latitude;
            double longitude;
            using (var response = await client.SendAsync(request).ConfigureAwait(false))
            {
                response.EnsureSuccessStatusCode();
                string content = await response.Content.ReadAsStringAsync();
                dynamic location = JsonConvert.DeserializeObject(content);
                latitude = double.Parse(location[0]["lat"].ToString().Replace(".", ","));
                longitude = double.Parse(location[0]["lon"].ToString().Replace(".", ","));
            }
            return (latitude, longitude);
        }
    }
}