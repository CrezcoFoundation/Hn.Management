using AutoMapper;
using HN.Management.Engine.ViewModels;
using HN.Management.Web.Resolvers;
using HN.ManagementEngine.Models;

namespace HN.Management.Web.Mapper
{
    public class ProfileMapping : Profile
    {
        public ProfileMapping()
        {
            CreateMap<UserRequest, User>()
                .ReverseMap();

            CreateMap<User, UserResponse>()
           .ForMember(dest => dest.ImageUrl, opt =>
           {
               opt.MapFrom<ImageUrlResolver>();
           })
           .ReverseMap();
        }
    }
}
