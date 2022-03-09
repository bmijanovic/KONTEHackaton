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
    public class RoomService : IRoomService
    {
        private readonly IRoomsRepository _roomsRepository;
        private readonly IDesksRepository _desksRepository;

        public RoomService(IRoomsRepository roomsRepository, IDesksRepository desksRepository)
        {
            _roomsRepository = roomsRepository;
            _desksRepository = desksRepository;
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
                model.FacultyID = item.FacultyId;
                model.DesksList = new List<DeskDomainModel>();
                foreach (Desk desk in item.Desks)
                {
                    DeskDomainModel modelDesk = new DeskDomainModel();
                    modelDesk.Id = desk.Id;
                    modelDesk.RoomId = desk.RoomId;
                    modelDesk.isAvailable = desk.isAvailable;
                    modelDesk.Order = desk.Order;
                    model.DesksList.Add(modelDesk);
                }
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
            List<DeskDomainModel> listOfDesks = new List<DeskDomainModel>();
            foreach (Desk desk in data.Desks)
            {
                DeskDomainModel modelDesk = new DeskDomainModel();
                modelDesk.Id = desk.Id;
                modelDesk.RoomId = desk.RoomId;
                modelDesk.isAvailable = desk.isAvailable;
                modelDesk.Order = desk.Order;
                listOfDesks.Add(modelDesk);
            }
            result.Id = data.Id;
            result.Name = data.Name;
            result.FacultyID = data.FacultyId;
            result.DesksList = listOfDesks;
           
            return result;
        }
    }
}
