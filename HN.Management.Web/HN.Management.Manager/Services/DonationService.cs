using AutoMapper;
using HN.Management.Engine.Repositories.Interfaces;
using HN.Management.Manager.Services.Interfaces;
using HN.ManagementEngine.DTO;
using HN.ManagementEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HN.Management.Manager.Services
{
    public class DonationService : IDonationService
    {
        private readonly IMapper _mapper;
        private readonly IDonationRepository _donationsRepository;
        public DonationService(IMapper mapper, IDonationRepository donationsRepository)
        {
            _mapper = mapper;
            _donationsRepository = donationsRepository;
        }

        public async Task<IQueryable<DonationDTO>> GetAllAsync()
        {
            var query = await _donationsRepository.GetAllAsync();

            return _mapper.Map<List<DonationDTO>>(query).AsQueryable();
        }

        public async Task<DonationDTO> GetByConditionAsync(int donationId)
        {
            var query = _donationsRepository.GetByConditionAsync(x => x.Id == donationId).Result.ToList();

            return await Task.FromResult(_mapper.Map<DonationDTO>(query.FirstOrDefault()));
        }
        
        public async Task<IQueryable<DonationDTO>> GetByProjectAsync(int projectId)
        {
            var query = _donationsRepository.GetByConditionAsync(x => x.ProjectId == projectId).Result.ToList();

            return await Task.FromResult(_mapper.Map<List<DonationDTO>>(query).AsQueryable());
        }

        public async Task<IQueryable<DonationDTO>> GetByDonortAsync(int donorId)
        {
            var query = _donationsRepository.GetByConditionAsync(x => x.DonorId == donorId).Result.ToList();

            return await Task.FromResult(_mapper.Map<List<DonationDTO>>(query).AsQueryable());
        }

        public async Task<IQueryable<DonationDTO>> GetByRankAsync(DateTime startDate, DateTime endDate)
        {
            var query = _donationsRepository.GetByConditionAsync(x => x.Date.Value >= startDate && x.Date.Value <= endDate).Result.ToList();

            return await Task.FromResult(_mapper.Map<List<DonationDTO>>(query).AsQueryable());
        }

        public async Task<DonationDTO> AddAsync(DonationDTO donation)
        {
            var entity = _mapper.Map<Donation>(donation);
            var dto = await _donationsRepository.AddAsync(entity);

            return _mapper.Map<DonationDTO>(dto);
        }

        public async Task<DonationDTO> UpdateAsync(DonationDTO donation)
        {
            var entity = _mapper.Map<Donation>(donation);
            var dto = await _donationsRepository.UpdateAsync(entity);

            return _mapper.Map<DonationDTO>(dto);
        }

        public async Task<DonationDTO> DeleteAsync(DonationDTO donation)
        {
            var entity = _mapper.Map<Donation>(donation);
            var dto = await _donationsRepository.DeleteAsync(entity);

            return _mapper.Map<DonationDTO>(dto);
        }
    }
}
