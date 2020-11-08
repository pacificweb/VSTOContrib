using System.IO;
using System.Net;
using System.Web;
using Newtonsoft.Json;

namespace WikipediaWordAddin.Services
{
    public class WikipediaService : IWikipediaService
    {
        public SearchResults Search(string search)
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls | System.Net.SecurityProtocolType.Tls11 | System.Net.SecurityProtocolType.Tls12 | System.Net.SecurityProtocolType.Ssl3;

            var request = WebRequest.Create("https://en.wikipedia.org/w/api.php?format=json&action=query&list=search&srsearch=" + HttpUtility.UrlEncode(search.Trim()));

            WebResponse response;
            try
            {
                response = request.GetResponse();

            }
            catch (System.Exception ex)
            {
                return null;
            }

            string json;

            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                json = streamReader.ReadToEnd();
            }

            var textReader = new StringReader(json);

            var jsonReader = new JsonTextReader(textReader);

            var serializer = new JsonSerializer();
            return serializer.Deserialize<SearchResults>(jsonReader);
        }
    }
}