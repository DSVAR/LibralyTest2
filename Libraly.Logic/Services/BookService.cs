using AutoMapper;
using AutoMapper.QueryableExtensions;
using Libraly.Data.Entities;
using Libraly.Data.Interfaces;
using Libraly.Data.Repositories;
using Libraly.Logic.Interfaces;
using Libraly.Logic.Models.BookDTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraly.Logic.Services
{
    public class BookService : IBookService
    {
        IBasedata<Book> _repository;
        IUnitOfWork _unitOfWork;
        IMapper _mapper;



        public BookService(IBasedata<Book> repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        public void Creat(BookViewModel model)
        {
            var book = _mapper.Map<Book>(model);
            _repository.Create(book);
            _unitOfWork.Save();
        }

        public void Delete(BookViewModel model)
        {
            var book = _mapper.Map<Book>(model);
            _repository.Delete(book);
            _unitOfWork.Save();
        }

        public IQueryable GetBook()
        {
            return _repository.Read();
        }

        public void Update(BookViewModel model)
        {
            var book = _mapper.Map<Book>(model);
            _repository.Update(book);
            _unitOfWork.Save();
        }

        public async Task<string> UploadPhoto(string path, IFormFile formFile)
        {
            var uniqName = Guid.NewGuid().ToString() + "__" + formFile.FileName;
            var filePath = Path.Combine(path, uniqName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await formFile.CopyToAsync(fileStream);
            }
            return uniqName;

        }
    }
}
