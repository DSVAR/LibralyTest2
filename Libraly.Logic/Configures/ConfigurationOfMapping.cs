using AutoMapper;
using Libraly.Data.Entities;
using Libraly.Logic.Models.BookDTO;
using Libraly_test2_.Models;

namespace Libraly.Logic.Configures
{
    class ConfigurationOfMapping:Profile
    {
        public ConfigurationOfMapping()
        {
            //книги
            CreateMap<Book, BookViewModel>();
            //пользователь
            CreateMap<User, LoginViewModel>();
            CreateMap<User, RegisterViewModel>();
            CreateMap<User, ChangePasswordViewsModel>();
        }
    }
}
