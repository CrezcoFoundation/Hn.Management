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
//        private readonly IDonorRepository donorRepository;
//        public DonorService(IDonorRepository donorRepository)
//        {
//            this.donorRepository = donorRepository;
//        }

//        public async Task<IQueryable<DonorDTO>> GetAllAsync()
//        {
//           return await donorRepository.GetAllAsync(); 
//        }

//        public async Task<DonorDTO> GetByConditionAsync(int donorId)
//        {
//            var query = donorRepository.GetByConditionAsync(x => x.Id == donorId).Result.ToList();

//            return await Task.FromResult(_mapper.Map<DonorDTO>(query.FirstOrDefault()));
//        }

//        public async Task<DonorDTO> AddAsync(DonorDTO donor)
//        {
//            var entity = _mapper.Map<Donor>(donor);
//            var dto = await donorRepository.AddAsync(entity);

//            return _mapper.Map<DonorDTO>(dto);
//        }

//        public async Task<DonorDTO> UpdateAsync(DonorDTO donor)
//        {
//            var dto = await donorRepository.UpdateAsync(entity);

//        }

//        public async Task<DonorDTO> DeleteAsync(DonorDTO donor)
//        {
//            var dto = await donorRepository.DeleteAsync(entity);

//        }
//    }
//}
