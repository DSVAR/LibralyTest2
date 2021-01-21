using System;
using System.Collections.Generic;
using System.Text;

namespace Libraly.Logic.Models.BookDTO
{
    class BookViewModel
    {
     
        public int YearOfBook { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string description { get; set; }
        public int count { get; set; }
        public string PhotoPath { get; set; }
        public string Genres { get; set; }
    }
}
