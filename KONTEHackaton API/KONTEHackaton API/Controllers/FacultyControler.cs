using KONTEHackaton.Data.Entities;
using KONTEHackaton.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KONTEHackaton_API.Controllers
{
    [ApiController]
    [Route("api/faculty")]
    public class FacultyControler : ControllerBase
    {
        IFacultyRepository _iFacultyRepository;
        public FacultyControler(IFacultyRepository facultyRepository)
        {
            _iFacultyRepository = facultyRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Faculty>>> Get()
        {
            List<Faculty> list = (List<Faculty>) await _iFacultyRepository.GetAll();
            return Ok(list);
        }
    }
}
