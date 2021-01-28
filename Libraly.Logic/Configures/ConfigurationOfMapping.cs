using AutoMapper;
using Libraly.Data.Entities;
using Libraly.Logic.Models.BookDTO;
using Libraly.Logic.Models.UserDTO;


namespace Libraly.Logic.Configures
{
    public class ConfigurationOfMapping:Profile
    {
        public ConfigurationOfMapping()
        {
            //var config = new MapperConfiguration(cfg =>{
            //    cfg.CreateMap<LoginViewModel, User>();
            ////    cfg.AddProfile<User>();
            //});
            //книги
            CreateMap<BookViewModel, Book>();
            CreateMap<Book,BookViewModel>();
            //пользователь

            CreateMap<LoginViewModel, UserModelView>();
            CreateMap<UserModelView, LoginViewModel>();

            CreateMap<RegisterViewModel, UserModelView>();
            CreateMap<UserModelView, RegisterViewModel>();

            CreateMap<ChangePasswordViewsModel, UserModelView>();
            CreateMap<UserModelView, ChangePasswordViewsModel>();

            CreateMap<User, UserModelView>();
            CreateMap<UserModelView, User>();

        }



    }
}
