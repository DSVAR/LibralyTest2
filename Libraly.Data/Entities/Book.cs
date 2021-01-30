using System;


namespace Libraly.Data.Entities
{
    public class Book
    {
        public long Id { get; set; }        
        public DateTime YearOfBook { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }
        public string PhotoPath { get; set; }
        public string Genres { get; set; }
        public DateTime LastOrdered { get; set; }
        public  string Url { get; set; }
        

    }
}
