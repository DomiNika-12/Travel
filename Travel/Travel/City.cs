
using SQLite;

namespace Travel
{
    public class City
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Continent { get; set; }

    }
}
