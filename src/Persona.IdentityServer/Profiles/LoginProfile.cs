using AutoMapper;
using Persona.IdentityServer.Models.ViewModels;

namespace Persona.IdentityServer.Profiles
{
    public class LoginProfile : Profile
    {
        public LoginProfile()
        {
            CreateMap<LoginInputViewModel, LoginViewModel>();
        }
    }
}
