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

            return people
                .Select(p => new RankedResult(p.Id, rankingData.First(r => r.PersonId == p.Id).Rank))
                .ToList();
        }
    }
}
