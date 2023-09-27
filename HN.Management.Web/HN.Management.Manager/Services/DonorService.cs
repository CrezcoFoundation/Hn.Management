//using AutoMapper;
//using HN.Management.Engine.Repositories.Interfaces;
//using HN.Management.Manager.Services.Interfaces;
//using HN.ManagementEngine.DTO;
//using HN.ManagementEngine.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace HN.Management.Manager.Services
//{
//    public class DonorService : IDonorService
//    {
//        //private readonly IDonorRepository _donorRepository;
//        private readonly IMapper _mapper;
//        public DonorService(IDonorRepository donorRepository, IMapper mapper)
//        {
//            _mapper = mapper;
//            _donorRepository = donorRepository;
//        }

//        public async Task<IQueryable<DonorDTO>> GetAllAsync()
//        {
//            var query = await _donorRepository.GetAllAsync();

//            return _mapper.Map<List<DonorDTO>>(query).AsQueryable();
//        }

//        public async Task<DonorDTO> GetByConditionAsync(int donorId)
//        {
//            var query = _donorRepository.GetByConditionAsync(x => x.Id == donorId).Result.ToList();

//            return await Task.FromResult(_mapper.Map<DonorDTO>(query.FirstOrDefault()));
//        }

//        public async Task<DonorDTO> AddAsync(DonorDTO donor)
//        {
//            var entity = _mapper.Map<Donor>(donor);
//            var dto = await _donorRepository.AddAsync(entity);

//            return _mapper.Map<DonorDTO>(dto);
//        }

//        public async Task<DonorDTO> UpdateAsync(DonorDTO donor)
//        {
//            var entity = _mapper.Map<Donor>(donor);
//            var dto = await _donorRepository.UpdateAsync(entity);

//            return _mapper.Map<DonorDTO>(dto);
//        }

//        public async Task<DonorDTO> DeleteAsync(DonorDTO donor)
//        {
//            var entity = _mapper.Map<Donor>(donor);
//            var dto = await _donorRepository.DeleteAsync(entity);

//            return _mapper.Map<DonorDTO>(dto);
//        }
//    }
//}
