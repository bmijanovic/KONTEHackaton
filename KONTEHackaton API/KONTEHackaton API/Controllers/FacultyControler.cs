using KONTEHackaton.Domain.Interfaces;
using KONTEHackaton.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace KONTEHackaton_API.Controllers
{
    [ApiController]
    [Route("api/faculty")]
    public class FacultyControler : ControllerBase
    {
        private readonly IFacultyService _facultyService;
        public FacultyControler(IFacultyService facultyService)
        {
            _facultyService = facultyService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FacultyDomainModel>>> Get()
        {
            IEnumerable<FacultyDomainModel> list = await _facultyService.GetAll();
            return Ok(list);
        }

        [HttpGet]
        [Route("byId/{id}")]
        public async Task<ActionResult<FacultyDomainModel>> GetFacultyById(Guid id)
        {
            FacultyDomainModel faculty = await _facultyService.GetById(id);
            return Ok(faculty);
        }
    }
}
