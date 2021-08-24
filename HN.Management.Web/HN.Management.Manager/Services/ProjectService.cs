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
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;
        public ProjectService(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<IQueryable<ProjectDTO>> GetAllAsync()
        {
            var query = await _projectRepository.GetAllAsync();

            return _mapper.Map<List<ProjectDTO>>(query).AsQueryable();
        }

        public async Task<ProjectDTO> GetByConditionAsync(int projectId)
        {
            var query = _projectRepository.GetByConditionAsync(x => x.Id == projectId).Result.ToList();

            return await Task.FromResult(_mapper.Map<ProjectDTO>(query.FirstOrDefault()));
        }

        public async Task<ProjectDTO> AddAsync(ProjectDTO project)
        {
            var entity = _mapper.Map<Project>(project);
            var dto = await _projectRepository.AddAsync(entity);

            return _mapper.Map<ProjectDTO>(dto);
        }

        public async Task<ProjectDTO> UpdateAsync(ProjectDTO project)
        {
            var entity = _mapper.Map<Project>(project);
            var dto = await _projectRepository.UpdateAsync(entity);

            return _mapper.Map<ProjectDTO>(dto);
        }

        public async Task<ProjectDTO> DeleteAsync(ProjectDTO project)
        {
            var entity = _mapper.Map<Project>(project);
            var dto = await _projectRepository.DeleteAsync(entity);

            return _mapper.Map<ProjectDTO>(dto);
        }


    }
}
