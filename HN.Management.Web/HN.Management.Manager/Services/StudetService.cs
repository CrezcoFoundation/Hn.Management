using AutoMapper;
using HN.Management.Engine.Repositories.Interfaces;
using HN.Management.Manager.Services.Interfaces;
using HN.ManagementEngine.DTO;
using HN.ManagementEngine.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HN.Management.Manager.Services
{
    public class StudetService : IStudentService
    {
        private readonly IStudentRepository _studentsRepository;
        private readonly IMapper _mapper;
        public StudetService(IStudentRepository studentsRepository, IMapper mapper)
        {
            _studentsRepository = studentsRepository;
            _mapper = mapper;
        }

        public async Task<IQueryable<StudentDTO>> GetAllAsync()
        {
            var query = await _studentsRepository.GetAllAsync();

            return  _mapper.Map<List<StudentDTO>>(query).AsQueryable();
        }
        
        public async Task<StudentDTO> GetByConditionAsync(int studentId)
        {
            var query = _studentsRepository.GetByConditionAsync(x => x.Id == studentId).Result.ToList();

            return await Task.FromResult(_mapper.Map<StudentDTO>(query.FirstOrDefault()));
        }

        public async Task<IQueryable<StudentDTO>> GetByProjectAsync(int projectId)
        {
            var query = _studentsRepository.GetByConditionAsync(x => x.ProjectId == projectId).Result.ToList();

            return await Task.FromResult(_mapper.Map<List<StudentDTO>>(query).AsQueryable());
        }

        public async Task<StudentDTO> AddAsync(StudentDTO student)
        {
            var entity = _mapper.Map<Student>(student);
            var dto = await _studentsRepository.AddAsync(entity);

            return _mapper.Map<StudentDTO>(dto);
        }

        public async Task<StudentDTO> UpdateAsync(StudentDTO student)
        {
            var entity = _mapper.Map<Student>(student);
            var dto = await _studentsRepository.UpdateAsync(entity);

            return _mapper.Map<StudentDTO>(dto);
        }

        public async Task<StudentDTO> DeleteAsync(StudentDTO student)
        {
            var entity = _mapper.Map<Student>(student);
            var dto = await _studentsRepository.DeleteAsync(entity);

            return _mapper.Map<StudentDTO>(dto);
        }
    }
}
