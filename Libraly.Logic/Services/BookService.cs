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

namespace Libraly.Logic.Services
{
    public class BookService : IData<BookViewModel>
    {
        IBasedata<Book> _repository;
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        BookViewModel sw = new BookViewModel();
       
        public BookService(IBasedata<Book> repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Creat(BookViewModel obj)
        {
            _repository.Create(_mapper.Map<Book>(obj));
            _unitOfWork.Save();
        }

        public void Delete(BookViewModel obj)
        {
            _repository.Delete(_mapper.Map<Book>(obj));
            _unitOfWork.Save();
        }

        public IQueryable<BookViewModel> Read()
        {
            var item = _mapper.Map<List<BookViewModel>>(_repository.Read().ProjectTo<BookViewModel>(_mapper.ConfigurationProvider)).AsQueryable();
            var items = _repository.Read().AsQueryable();
            return item;
        }

        public void Update(BookViewModel obj)
        {
            _repository.Update(_mapper.Map<Book>(obj));
            _unitOfWork.Save();
        }
    }
}
