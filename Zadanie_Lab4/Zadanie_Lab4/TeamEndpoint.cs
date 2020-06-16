using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using System.Threading.Tasks;

namespace Zadanie_Lab4
{
    public class TeamEndpoint
    {
        public static RestClient ApiClient { get; set; } = new RestClient("https://api.collegefootballdata.com");
        public static Task<IRestResponse> GetAllByYear()
        {
            var request = new RestRequest("/teams/fbs?year=2019", Method.GET);

            var response = ApiClient.ExecuteAsync(request);

            return response;
        }
    }
}
