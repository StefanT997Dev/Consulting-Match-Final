using Application.DTOs;
using AutoMapper;
using Domain;

namespace Application.Core
{
	public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
            CreateMap<Review,ReviewDto>();
            CreateMap<AppUser,MentorSearchDto>();
            CreateMap<AppUserSkill, MentorSearchDto>()
                .ForMember(msd => msd.DisplayName, o => o.MapFrom(aus => aus.Mentor.DisplayName));
            CreateMap<AppUserCategory,MentorDisplayDto>()
                .ForMember(d => d.DisplayName, o => o.MapFrom(s => s.Mentor.DisplayName))
                .ForMember(d => d.Bio, o => o.MapFrom(s => s.Mentor.Bio));
            CreateMap<AppUser,UserDto>()
                .ForMember(ud => ud.Role, o => o.MapFrom(au => au.Role.Name));
            CreateMap<Skill,SkillDto>();
            CreateMap<SkillDto, Skill>();
            CreateMap<AppUserSkill,SkillDto>()
                .ForMember(s => s.Id, o => o.MapFrom(aus => aus.SkillId))
                .ForMember(s => s.Name, o => o.MapFrom(aus => aus.Skill.Name));
            CreateMap<Skill,CategorySkill>()
                .ForMember(cs=>cs.SkillId,o =>o.MapFrom(s => s.Id));
            CreateMap<AppUser, MentorDisplayDto>()
                .ForMember(mdd => mdd.Reviews, o=>o.MapFrom(au => au.ClientReviews))
                .ForMember(mdd => mdd.Role, o => o.MapFrom(au => au.Role.Name));
            CreateMap<AppUserCategory, CategoryDto>()
                .ForMember(cd => cd.Id, o => o.MapFrom(auc => auc.CategoryId))
                .ForMember(cd => cd.Name, o=> o.MapFrom(auc => auc.Category.Name));
            CreateMap<Category, CategoryWithSkillsDto>();
            CreateMap<CategorySkill, SkillDto>()
                .ForMember(s => s.Id, o => o.MapFrom(cs => cs.SkillId))
                .ForMember(s => s.Name, o => o.MapFrom(cs => cs.Skill.Name));
            CreateMap<Review, ReviewDto>();
            CreateMap<AppUser, ClientDto>();
            CreateMap<UpdateMentorDto, AppUser>();
            CreateMap<SkillDto, AppUserSkill>()
                .ForMember(aus => aus.SkillId, o => o.MapFrom(sd => sd.Id));
            CreateMap<JobApplicationDto, MentorJobApplication>();
            CreateMap<AppUserCategoryDto, AppUserCategory>();
            CreateMap<Role, RoleDto>();
            CreateMap<Mentorship, ClientDashboardDisplayDto>()
                .ForMember(cddd => cddd.DisplayName, o => o.MapFrom(m => m.Client.DisplayName));
        }
    }
}