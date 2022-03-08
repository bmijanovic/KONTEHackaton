using KONTEHackaton.Domain.Interfaces;
using KONTEHackaton.Domain.Models;
using KONTEHackaton.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KONTEHackaton.Domain.Services
{
    public class DeskService : IDeskService
    {
        private readonly IDesksRepository _desksRepository;

        public DeskService(IDesksRepository desksRepository)
        {
            _desksRepository = desksRepository;
        }
        public DeskDomainModel Add(DeskDomainModel model)
        {
            throw new NotImplementedException();
        }

        public DeskDomainModel Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<DeskDomainModel>> GetAll()
        {
            var data = await _desksRepository.GetAll();
            if (data == null)
                return null;
            List<DeskDomainModel> result = new List<DeskDomainModel>();
            DeskDomainModel model;
            foreach (var item in data)
            {
                model = new DeskDomainModel();
                model.Id = item.Id;
                model.Order = item.Order;
                model.isAvailable = item.isAvailable;
                result.Add(model);
            }
            return result;
        }

        public async Task<DeskDomainModel> GetById(Guid id)
        {
            var data = await _desksRepository.GetById(id);
            if (data == null)
                return null;
            DeskDomainModel result = new DeskDomainModel();
            result.Id = data.Id;
            result.Order = data.Order;
            result.isAvailable = data.isAvailable;
            return result;
        }
    }
}
