using KONTEHackaton.Data.Entities;
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
        public DeskDomainModel Add(Guid roomId)
        {
            Desk desk = new Desk();
            desk.Id = new Guid();
            desk.isAvailable = true;
            desk.RoomId = roomId;
            desk.Order = _desksRepository.GetNumOfTablesForRoom(roomId);

            Desk insertedDesk = _desksRepository.Post(desk);
            _desksRepository.Save();

            DeskDomainModel deskDomainModel = new DeskDomainModel();
            deskDomainModel.Id = insertedDesk.Id;
            deskDomainModel.RoomId = insertedDesk.RoomId;
            deskDomainModel.isAvailable = insertedDesk.isAvailable;
            deskDomainModel.Order = insertedDesk.Order;
            return deskDomainModel;
            
        }

        public DeskDomainModel Delete(Guid id)
        {
            var deletedDesk = _desksRepository.Delete(id);
            _desksRepository.Save();

            DeskDomainModel deletedDomainModel = new DeskDomainModel();
            deletedDomainModel.Id = deletedDesk.Id;
            deletedDomainModel.RoomId = deletedDesk.RoomId;
            deletedDomainModel.isAvailable= deletedDesk.isAvailable;
            deletedDomainModel.Order = deletedDesk.Order;  

            return deletedDomainModel;
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
                model.RoomId = item.RoomId;
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
            result.RoomId = data.RoomId;
            return result;
        }
    }
}
