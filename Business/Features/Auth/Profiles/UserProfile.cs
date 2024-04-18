using AutoMapper;
using Business.Features.Auth.Commands.Register;
using Core.Entities;

namespace Business.Features.Auth.Profiles
{
	public class UserProfile : Profile
	{
        public UserProfile()
        {
            CreateMap<User, RegisterResponse>().ReverseMap();
            CreateMap<User, RegisterCommand>().ReverseMap();
        }
    }
}
