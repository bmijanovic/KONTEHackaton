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
            return result;
        }
    }
}
