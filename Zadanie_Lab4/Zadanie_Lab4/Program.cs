
using RestSharp;
using RestSharp.Serialization.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zadanie_Lab4;

namespace Zadanie_Lav4
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var coachesList = new HashSet<List<CoacheDto>>();
            var tasks = new List<Task<IRestResponse>>();

            var restResponse = await Task.WhenAny(TeamEndpoint.GetAllByYear()).Result;
            var teamsList = new JsonDeserializer().Deserialize<List<TeamDto>>(restResponse);

            foreach (var team in teamsList)
            {
                tasks.Add(CoachEndpoint.GetCoacheByTeam($"{team.School}"));
            }

            var coachResponse = await Task.WhenAll(tasks);

            foreach (var response in coachResponse)
            {
                var coache = new JsonDeserializer().Deserialize<List<CoacheDto>>(response);
                coachesList.Add(coache);
            }

            var mapping = new MappingProfile();
            var result = mapping.Map(coachesList, teamsList);

            var repo = new Repository();
            await repo.AddAsync(result);
        }
    }
}