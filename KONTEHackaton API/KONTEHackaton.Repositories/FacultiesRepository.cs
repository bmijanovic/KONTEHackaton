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
    public interface IFacultyRepository : IRepository<Faculty>
    {

    }

    public class FacultiesRepository : IFacultyRepository
{
        private FacultyContext _facultyContext;

        public FacultiesRepository(FacultyContext facultyRepository)
        {
            _facultyContext = facultyRepository;
        }

        public async Task<IEnumerable<Faculty>> GetAll()
        {
            return await _facultyContext.Faculties.Include(x => x.WorkingHours).Include(x => x.Rooms).ThenInclude(x => x.Desks).ToListAsync();
        }

        public async Task<Faculty> GetById(Guid id)
        {
            var data = await _facultyContext.Faculties.Include(x => x.Rooms).ThenInclude(x => x.Desks).Include(x => x.WorkingHours).SingleOrDefaultAsync(x => x.Id == id);
            return data;
        }

    }
}
