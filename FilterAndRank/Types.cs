namespace FilterAndRank
{        
    public struct Person
    {
        public readonly long Id;
        public readonly string Name;

        public Person(long id, string name)
        {
            this.Id = id;
            this.Name = name;
        }       

        public override string ToString()
        {
            return $"{Id}:{Name}";
        }
    }
    
    public struct CountryRanking
    {
        public readonly long PersonId;
        public readonly string Country;
        public readonly int Rank;

        public CountryRanking(long personId, string country, int rank)
        {
            this.PersonId = personId;
            this.Country = country;
            this.Rank = rank;
        }       

        public override string ToString()
        {
            return $"{PersonId}:{Country}:{Rank}";
        }
    }
    
    public struct RankedResult
    {
        public readonly long PersonId;
        public readonly int Rank;

        public RankedResult(long personId, int rank)
        {
            this.PersonId = personId;
            this.Rank = rank;
        }       

        public override string ToString()
        {
            return $"{PersonId}:{Rank}";
        }
    }
}
