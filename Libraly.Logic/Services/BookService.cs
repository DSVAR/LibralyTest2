using AutoMapper;
using AutoMapper.QueryableExtensions;
using Libraly.Data.Entities;
using Libraly.Data.Interfaces;
using Libraly.Data.Repositories;
using Libraly.Logic.Interfaces;
using Libraly.Logic.Models.BookDTO;
using System;
using System.Collections.Generic;
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
    }
}
