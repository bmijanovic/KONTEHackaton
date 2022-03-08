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
    }
}