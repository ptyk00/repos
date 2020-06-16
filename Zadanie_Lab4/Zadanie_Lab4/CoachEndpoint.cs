using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using System.Threading.Tasks;

namespace Zadanie_Lab4
{
    class CoachEndpoint
    {
        public static RestClient ApiClient { get; set; } = new RestClient("https://api.collegefootballdata.com");
        public static Task<IRestResponse> GetCoacheByTeam(string school)
        {
            var request = new RestRequest($"/coaches?team={school}&year=2019", Method.GET);

            var response = ApiClient.ExecuteAsync(request);

            return response;
        }
    }
}
