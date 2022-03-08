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
    public class RoomService : IRoomService
    {
        private readonly IRoomsRepository _roomsRepository;

        public RoomService(IRoomsRepository roomsRepository)
        {
            _roomsRepository = roomsRepository;
        }
        public async Task<IEnumerable<RoomDomainModel>> GetAll()
        {
            var data = await _roomsRepository.GetAll();
            if (data == null)
                return null;
            List<RoomDomainModel> result = new List<RoomDomainModel>();
            RoomDomainModel model;
            foreach (var item in data)
            {
                model = new RoomDomainModel();
                model.Id = item.Id;
                model.Name = item.Name;
                result.Add(model);
            }
            return result;
        }

        public async Task<RoomDomainModel> GetById(Guid id)
        {
            var data = await _roomsRepository.GetById(id);
            if (data == null)
                return null;
            RoomDomainModel result = new RoomDomainModel();
            result.Id = data.Id;
            result.Name = data.Name;
            return result;
        }
    }
}
