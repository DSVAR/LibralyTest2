using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Libraly.Data.Entities
{
    public class Book
    {
        [Required(ErrorMessage = "Не указан год")]
        public int YearOfBook { get; set; }


        [Required(ErrorMessage = "Не указано название книги")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указан автор")]
        public string Author { get; set; }
        public string description { get; set; }

        [Required(ErrorMessage = "Не указано колличество")]
        public int count { get; set; }
        public string PhotoPath { get; set; }

        [Required(ErrorMessage = "Не указан жанр")]
        public string Genres { get; set; }

        public DateTime LastOrdered { get; set; }
        

    }
}
