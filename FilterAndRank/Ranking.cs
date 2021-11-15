using System;
using System.Collections.Generic;
using System.Linq;

namespace FilterAndRank
{
    public static class Ranking
    {        
        public static IList<RankedResult> FilterByCountryWithRank(
            IList<Person> people,
            IList<CountryRanking> rankingData,
            IList<string> countryFilter,
            int minRank, int maxRank,
            int maxCount)
        {
            // TODO: write your solution here.  Do not change the method signature in any way, or validation of your solution will fail.

            return people.Join(rankingData, p => p.Id, r => r.PersonId, (person, ranking) => new PeopleAndRankingView 
            { 
                Id = person.Id,
                Name = person.Name,
                Country = ranking.Country,
                Rank = ranking.Rank,
            })
                .Where(pr => countryFilter.Contains(pr.Country, StringComparer.OrdinalIgnoreCase))
                .Where(r => r.Rank >= minRank && r.Rank <= maxRank)
                .OrderBy(r => r, new RankingComparer(countryFilter)) 
                .Select(r => new RankedResult(r.Id, r.Rank))
                .Take(maxCount)
                .ToList();
        }
    }
}
