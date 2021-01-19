using System;
using System.Collections.Generic;
using System.Text;

namespace Libraly.Data.Entities
{
    public class Book
    {
        public int ID { get; set; }
        public int Year { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string description { get; set; }
        public int count { get; set; }
        public float price { get; set; }
        public string PhotoPath { get; set; }
      //  public Genre? genres { get; set; }
    }
}
