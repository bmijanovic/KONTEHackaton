using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KONTEHackaton.Data.Context;
using KONTEHackaton.Data.Entities;
using Microsoft.EntityFrameworkCore;


namespace KONTEHackaton.Repositories
{
    public interface IDesksRepository : IRepository<Desk>
    {
        Desk Delete(Guid id);
        Desk Post(Desk entity);
        void Save();

        Task<IEnumerable<Desk>> GetByRoomAsync(Guid roomId);

        int GetNumOfTablesForRoom(Guid roomId);
    }

    public class DeskRepository : IDesksRepository
    {
        private FacultyContext _facultyContext;

        public DeskRepository(FacultyContext facultyRepository)
        {
            _facultyContext = facultyRepository;
        }

        public Desk Delete(Guid id)
        {
            Desk desk = _facultyContext.Desks.Find(id);
            if (desk == null)
            {
                return null;
            }
            var result = _facultyContext.Desks.Remove(desk);
            var query = from deskQuery in _facultyContext.Desks where desk.Order < deskQuery.Order && deskQuery.RoomId == desk.RoomId select deskQuery;
            foreach (var d in query)
            {
                d.Order = d.Order - 1;
            }
            try
            {
                _facultyContext.SaveChanges();
            }
            catch (Exception e)
            {
                return null;
            }
            return result.Entity;
        }

        public async Task<IEnumerable<Desk>> GetAll()
        {
            return await _facultyContext.Desks.ToListAsync();
        }

        public async Task<Desk> GetById(Guid id)
        {
            var data = await _facultyContext.Desks.FindAsync(id);
            return data;
        }

        public Desk Post(Desk entity)
        {
            var result = _facultyContext.Desks.Add(entity);
            return result.Entity;
        }

        public void Save()
        {
            _facultyContext.SaveChanges();
        }

        public async Task<IEnumerable<Desk>> GetByRoomAsync(Guid roomId)
        {
            //IEnumerable<Desk> data = from desk in _facultyContext.Desks where desk.RoomId == roomId select desk;
            //IEnumerable<Desk> data = (IEnumerable<Desk>)_facultyContext.Desks.Where(x => x.RoomId.Equals(roomId)).ToList();
            IEnumerable<Desk> desks = _facultyContext.Desks.ToList();
            IEnumerable<Desk> data = new List<Desk>();
            foreach(Desk desk in desks)
            {
                if (desk.RoomId == roomId)
                {
                    data.Append(desk);
                }
            }
            return data;
        }

        public int GetNumOfTablesForRoom(Guid roomId)
        {
            var data = _facultyContext.Desks.Where(x => x.RoomId.Equals(roomId)).ToList().Count;
            return data;
        }
    }
}