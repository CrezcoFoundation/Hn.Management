using AutoMapper;
using HN.ManagementEngine.DTO;
using HN.ManagementEngine.Models;

namespace HN.Management.Engine.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {

            //Entity to DTO
            CreateMap<Activity, ActivityDTO>();
            CreateMap<Donation, DonationDTO>();
            CreateMap<Donor, DonorDTO>();
            CreateMap<Evidence, EvidenceDTO>();
            CreateMap<Project, ProjectDTO>();
            CreateMap<Student, StudentDTO>();
            CreateMap<UserPermit, UserPermitDTO>();
            CreateMap<User, UserDTO>();

            //DTO to Entity
            CreateMap<ActivityDTO, Activity>();
            CreateMap<DonationDTO, Donation>();
            CreateMap<DonorDTO, Donor>();
            CreateMap<EvidenceDTO, Evidence>();
            CreateMap<ProjectDTO, Project>();
            CreateMap<StudentDTO, Student>();
            CreateMap<UserPermitDTO, UserPermit>();
            CreateMap<UserDTO, User>();

        }
    }
}
