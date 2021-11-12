using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace FilterAndRank.Tests
{
    public class RankingTests
    {
        // TODO: add additional test cases here of other patterns that concern you, all test cases you add must pass        

        [Test]
        public void TestBasicQueryForOneCountry()
        {
            var expected = new List<RankedResult>
            {
                new RankedResult(32, 1),  // Jennifer
                new RankedResult(62, 2),  // Stacey
                new RankedResult(766, 3), // Michael
                new RankedResult(393, 4), // Farfy
                new RankedResult(12, 5)   // Lonnie
            };
            var actual = Ranking.FilterByCountryWithRank(
                testPeople,
                testCountryRanks,
                new List<string>() {"Canada"},
                1, 10,
                5
            );

            Assert.AreEqual(expected, actual);
        }

        internal struct TestPerson
        {
            internal readonly long Id;
            internal readonly string Name;
            internal readonly int Rank;
            internal readonly string Country;

            internal TestPerson(long id, string name, int rank, string country)
            {
                this.Id = id;
                this.Name = name;
                this.Rank = rank;
                this.Country = country;
            }
        }

        private static IList<TestPerson> allTestPeople = new List<TestPerson>
        {
            new TestPerson(11, "Frank", 1, "USA"),
            new TestPerson(22, "David", 2, "USA"),
            new TestPerson(99, "Amy", 3, "USA"),
            new TestPerson(244, "Dana", 3, "USA"),
            new TestPerson(333, "Jeff", 4, "USA"),
            new TestPerson(77, "Zinsky", 4, "USA"),
            new TestPerson(55, "Pila", 5, "USA"),
            new TestPerson(88, "Nord", 6, "USA"),
            new TestPerson(66, "Frances", 7, "USA"),
            new TestPerson(211, "Lulu", 8, "USA"),
            new TestPerson(533, "Zila", 8, "USA"),
            new TestPerson(388, "Derik", 8, "USA"),
            new TestPerson(977, "Kevin", 9, "USA"),
            new TestPerson(744, "Laurie", 10, "USA"),
            new TestPerson(655, "Maria", 11, "USA"),

            new TestPerson(32, "Jennifer", 1, "Canada"),
            new TestPerson(62, "Stacey", 2, "Canada"),
            new TestPerson(766, "Michael", 3, "Canada"),
            new TestPerson(393, "Faerfy", 4, "Canada"),
            new TestPerson(12, "Lonnie", 5, "Canada"),
            new TestPerson(14, "Zerk", 6, "Canada"),
            new TestPerson(981, "George", 7, "Canada"),
            new TestPerson(741, "Lindsly", 8, "Canada"),
            new TestPerson(692, "Deborah", 9, "Canada"),
            new TestPerson(49, "Tammy", 10, "Canada"),
            new TestPerson(51, "Tamarak", 11, "Canada"),
            new TestPerson(404, "Leah", 12, "Canada"),

            new TestPerson(3, "Amelia", 1, "Mexico"),
            new TestPerson(1000, "Pamela", 2, "Mexico"),
            new TestPerson(72, "Ana Sofia", 2, "Mexico"),
            new TestPerson(85, "Maria Fernanda", 3, "Mexico"),
            new TestPerson(1002, "Jorge", 4, "Mexico"),
            new TestPerson(40, "Luis", 5, "Mexico"),
            new TestPerson(60, "Pancho", 5, "Mexico"),
            new TestPerson(50, "Francisco", 5, "Mexico"),
            new TestPerson(36, "Denaldo", 5, "Mexico"),
            new TestPerson(1010, "Ala", 5, "Mexico"),
            new TestPerson(2020, "Paula", 5, "Mexico"),
            new TestPerson(1092, "Kimberlia", 5, "Mexico"),
            new TestPerson(27, "Carlos", 5, "Mexico"),
            new TestPerson(58, "Mimi", 6, "Mexico")
        };

        private static IList<Person> testPeople = allTestPeople.Select(p => new Person(p.Id, p.Name)).ToList();
        
        private static IList<CountryRanking> testCountryRanks = allTestPeople.Select(p => new CountryRanking(p.Id, p.Country, p.Rank)).ToList();
    }
}