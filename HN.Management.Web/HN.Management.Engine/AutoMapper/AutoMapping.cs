using AutoMapper;
using HN.Management.Engine.DTO;
using HN.Management.Engine.Models;
using HN.ManagementEngine.DTO;
using HN.ManagementEngine.Models;

namespace HN.Management.Engine.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {

            //Entity to DTO
            CreateMap<Expense, ExpenseDTO>();
            CreateMap<Donation, DonationDTO>();
            CreateMap<Donor, DonorDTO>();
            CreateMap<Evidence, EvidenceDTO>();
            CreateMap<Project, ProjectDTO>();
            CreateMap<Student, StudentDTO>();
            CreateMap<UserDetail, UserDetailDto>();
            CreateMap<User, UserDTO>();

            //DTO to Entity
            CreateMap<ExpenseDTO, Expense>();
            CreateMap<DonationDTO, Donation>();
            CreateMap<DonorDTO, Donor>();
            CreateMap<EvidenceDTO, Evidence>();
            CreateMap<ProjectDTO, Project>();
            CreateMap<StudentDTO, Student>();
            CreateMap<UserDetail, UserDetailDto>();
            CreateMap<UserDTO, User>();

        }
    }
}
