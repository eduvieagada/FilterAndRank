using System.Collections.Generic;
using System.Linq;

namespace FilterAndRank
{
    public class RankingComparer : IComparer<PeopleAndRankingView>
    {
        private readonly IList<string> _countryList;
        public RankingComparer(IList<string> countryList)
        {
            _countryList = countryList;
        }
        public int Compare(PeopleAndRankingView x, PeopleAndRankingView y)
        {
            if (x.Rank == y.Rank)
            {
                var comparison = CompareBasedOnCountries(x.Country, y.Country);
                if (comparison != 0)
                    return comparison;

                return x.Name.CompareTo(y.Name);
            }
            return x.Rank.CompareTo(y.Rank);
        }

        private int CompareBasedOnCountries(string countryX, string countryY)
        {
            int countryXIndex = _countryList.IndexOf(countryX);
            int countryYIndex = _countryList.IndexOf(countryY);

            if (countryXIndex < countryYIndex)
                return -1;
            if (countryXIndex > countryYIndex)
                return 1;
            return 0;
        }
    }
}
