
using System;
using System.ComponentModel.DataAnnotations;

namespace Libraly.Logic.Models.BookDTO
{
    public class BookViewModel
    {
     
        public long Id { get; set; }
        public int YearOfBook { get; set; }

        [Required(ErrorMessage ="Пустое название книг")]
        public string Name { get; set; }
       [Required(ErrorMessage = "ФИО или псевдоним пустой")]
        public string Author { get; set; }
        [Required(ErrorMessage = "Описание пустое")]
        public string Description { get; set; }
        public int Count { get; set; }
        public string PhotoPath { get; set; }
        public string Url { get; set; }
       [Required(ErrorMessage = "Пустой жанр")]
        public string Genres { get; set; }
    }
}
