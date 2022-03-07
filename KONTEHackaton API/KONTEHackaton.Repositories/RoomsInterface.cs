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
    public interface IRoomsRepository : IRepository<Room>
    {

    }

    public class RoomsRepository : IRoomsRepository
    {
        private FacultyContext _facultyContext;

        public RoomsRepository(FacultyContext facultyRepository)
        {
            _facultyContext = facultyRepository;
        }

        public async Task<IEnumerable<Room>> GetAll()
        {
            return await _facultyContext.Rooms.ToListAsync();
        }

        public async Task<Room> GetById(Guid id)
        {
            var data = await _facultyContext.Rooms.FindAsync(id);
            return data;
        }

   
    }
}
