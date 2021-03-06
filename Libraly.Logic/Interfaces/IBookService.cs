﻿using Libraly.Data.Entities;
using Libraly.Logic.Models.BookDTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraly.Logic.Interfaces
{
    public interface IBookService
    {
        IQueryable<BookViewModel> GetBooks();
        void Creat(BookViewModel model);
        void Delete(BookViewModel model);
        void Update(BookViewModel model);
        Task<string> UploadPhoto(string path, IFormFile formFile);

    }
}
