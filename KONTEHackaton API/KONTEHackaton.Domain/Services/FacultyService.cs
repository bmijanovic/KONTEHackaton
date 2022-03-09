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
    public class FacultyService : IFacultyService
    {
        private readonly IFacultyRepository _faultyRepository;

        public FacultyService(IFacultyRepository facultyRepository)
        {
            _faultyRepository = facultyRepository;
        }
        public async Task<IEnumerable<FacultyDomainModel>> GetAll()
        {
            var data = await _faultyRepository.GetAll();
            if (data == null)
                return null;
            List<FacultyDomainModel> result = new List<FacultyDomainModel>();
            FacultyDomainModel model;
            foreach (var item in data)
            {
                model = new FacultyDomainModel();
                model.Id = item.Id;
                model.Name = item.Name;
                model.WorkingHours = new WorkingHoursDomainModel();
                model.WorkingHours.id = item.WorkingHours.Id;
                model.WorkingHours.opens = item.WorkingHours.Opens;
                model.WorkingHours.closes = item.WorkingHours.Closes; model.RoomsList = new List<RoomDomainModel>();
                foreach (Room room in item.Rooms)
                {
                    RoomDomainModel roomModel = new RoomDomainModel();
                    roomModel.Id = room.Id;
                    roomModel.Name = room.Name;
                    roomModel.FacultyID = room.FacultyId;
                    roomModel.DesksList = new List<DeskDomainModel>();
                    foreach (Desk desk in room.Desks)
                    {
                        DeskDomainModel modelDesk = new DeskDomainModel();
                        modelDesk.Id = desk.Id;
                        modelDesk.RoomId = desk.RoomId;
                        modelDesk.isAvailable = desk.isAvailable;
                        modelDesk.Order = desk.Order;
                        roomModel.DesksList.Add(modelDesk);
                    }
                    model.RoomsList.Add(roomModel);
                }
                result.Add(model);
            }
            return result;
        }

        public async Task<FacultyDomainModel> GetById(Guid id)
        {
            var data = await _faultyRepository.GetById(id);
            if (data == null)
                return null;
            FacultyDomainModel result = new FacultyDomainModel();
            result.Id = data.Id;
            result.Name = data.Name;
            result.WorkingHours = new WorkingHoursDomainModel();
            result.WorkingHours.id = data.WorkingHours.Id;
            result.WorkingHours.opens = data.WorkingHours.Opens;
            result.WorkingHours.closes = data.WorkingHours.Closes;
            result.RoomsList = new List<RoomDomainModel>();
            foreach (Room room in data.Rooms)
            {
                RoomDomainModel roomModel = new RoomDomainModel();
                roomModel.Id = room.Id;
                roomModel.Name = room.Name;
                roomModel.FacultyID = room.FacultyId;
                List<DeskDomainModel> listOfDesks = new List<DeskDomainModel>();
                foreach (Desk desk in room.Desks)
                {
                    DeskDomainModel modelDesk = new DeskDomainModel();
                    modelDesk.Id = desk.Id;
                    modelDesk.RoomId = desk.RoomId;
                    modelDesk.isAvailable = desk.isAvailable;
                    modelDesk.Order = desk.Order;
                    listOfDesks.Add(modelDesk);
                }
                roomModel.DesksList = listOfDesks;
                result.RoomsList.Add(roomModel);
            }
            return result;
        }
    }
}
