using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace MTGCollectionApp.Services
{
    public class CardService
    {
        private readonly HttpClient _httpClient;

        public CardService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<JObject> FetchCardDetailsAsync(string cardName, string searchType, List<string> validUsers)
        {
            var url = $"https://api.scryfall.com/cards/named?fuzzy={cardName}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to fetch card details");
            }


            var jsonResponse = await response.Content.ReadAsStringAsync();
            var cardJson = JObject.Parse(jsonResponse);

            if (searchType == "printing")
            {
                var printSearchUri = cardJson["prints_search_uri"].ToString();
                if (!string.IsNullOrEmpty(printSearchUri))
                {
                    var printSearchResponse = await _httpClient.GetAsync(printSearchUri);
                    if (printSearchResponse.IsSuccessStatusCode)
                    {
                        var printJsonResponse = await printSearchResponse.Content.ReadAsStringAsync();
                        var printJson = JObject.Parse(printJsonResponse);
                        cardJson["prints"] = printJson["data"];
                    }
                }
            }
            return cardJson;
        }
    }
}
