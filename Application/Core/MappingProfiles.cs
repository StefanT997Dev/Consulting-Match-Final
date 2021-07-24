using System.Linq;
using Application.Categories;
using Application.Comments;
using Application.DTOs;
using AutoMapper;
using Domain;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Post,Post>();
            CreateMap<Category,CategoryDto>();
            CreateMap<Review,ReviewDto>();
            CreateMap<AppUser,ConsultantSearchDto>();
            CreateMap<AppUserCategory,Profiles.Profile>()
                .ForMember(d => d.DisplayName, o => o.MapFrom(s => s.AppUser.DisplayName))
                .ForMember(d => d.Bio, o => o.MapFrom(s => s.AppUser.Bio));
            CreateMap<AppUser,DashboardUserDto>();
            CreateMap<Comment,CommentDto>()
                .ForMember(d => d.DisplayName, o => o.MapFrom(s => s.Author.DisplayName))
                .ForMember(d => d.Username, o => o.MapFrom(s => s.Author.UserName))
                .ForMember(d => d.Image, o => o.MapFrom(s => s.Author.ProfilePicture));
            CreateMap<AppUser,UserDto>();
            CreateMap<Skill,SkillDto>();
            CreateMap<AppUserSkill,SkillDto>();
            CreateMap<Skill,CategorySkill>()
                .ForMember(cs=>cs.SkillId,o =>o.MapFrom(s => s.Id));
        }
    }
}