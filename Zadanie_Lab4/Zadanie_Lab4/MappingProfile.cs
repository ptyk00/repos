using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Zadanie_Lab4
{
    class MappingProfile
    {
        public IEnumerable<Team> Map(HashSet<List<CoacheDto>> coaches, List<TeamDto> teams)
        {
            var coachData = coaches.SelectMany(l => l.Select(c =>
                new Coache
                {
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Seasons = c.Seasons.Select(x => new Season
                    {
                        School = x.School,
                        Year = x.Year,
                        Games = x.Games,
                        Wins = x.Wins,
                        Losses = x.Losses,
                        Ties = x.Ties,
                        PreseasonRank = x.PreseasonRank,
                        PostseasonRank = x.PostseasonRank
                    }).ToList()
                }));

            var teamData = teams.Select(x => new Team
            {
                School = x.School,
                Mascot = x.Mascot,
                Abbreviation = x.Abbreviation,
                AltName1 = x.AltName1,
                AltName2 = x.AltName2,
                AltName3 = x.AltName3,
                Conference = x.Conference,
                Division = x.Division,
                Color = x.Color,
                AltColor = x.AltColor,
                Coaches = coachData.SelectMany(p => p.Seasons,
                             (c, s) => new { c, s })
                             .Where(p => p.s.School == x.School)
                             .Select(p => new Coache
                             {
                                 Seasons = p.c.Seasons,
                                 FirstName = p.c.FirstName,
                                 LastName = p.c.LastName
                             }).ToList()
            });

            return teamData;
        }
    }
}
