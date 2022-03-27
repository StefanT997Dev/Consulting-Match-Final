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
            CreateMap<AppUser, AppUser>();
            CreateMap<AppUserSkill, MentorSearchDto>()
                .ForMember(msd => msd.DisplayName, o => o.MapFrom(aus => aus.Mentor.DisplayName));
            CreateMap<AppUser,UserDto>()
                .ForMember(ud => ud.Role, o => o.MapFrom(au => au.Role.Name));
            CreateMap<Skill,SkillDto>();
            CreateMap<SkillDto, Skill>();
            CreateMap<AppUserSkill,SkillDto>()
                .ForMember(s => s.Id, o => o.MapFrom(aus => aus.SkillId))
                .ForMember(s => s.Name, o => o.MapFrom(aus => aus.Skill.Name));
            CreateMap<Skill,CategorySkill>()
                .ForMember(cs=>cs.SkillId,o =>o.MapFrom(s => s.Id));
            CreateMap<AppUser, MentorDisplayDto>();
            CreateMap<Mentor, MentorDisplayDto>();
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
            CreateMap<Role, RoleDto>();
            CreateMap<Mentorship, ClientDashboardDisplayDto>()
                .ForMember(cddd => cddd.DisplayName, o => o.MapFrom(m => m.Client.DisplayName));
            CreateMap<PackageDto, Package>();
        }
    }
}