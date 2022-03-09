using KONTEHackaton.Domain.Interfaces;
using KONTEHackaton.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KONTEHackaton_API.Controllers
{
    [ApiController]
    [Route("api/desk")]
    public class DeskController : ControllerBase
    {
        private readonly IDeskService _deskService;
        public DeskController(IDeskService deskService)
        {
            _deskService = deskService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeskDomainModel>>> Get()
        {
            IEnumerable<DeskDomainModel> list = await _deskService.GetAll();
            return Ok(list);
        }

        [HttpGet]
        [Route("byId/{id}")]
        public async Task<ActionResult<DeskDomainModel>> GetDeskById(Guid id)
        {
            DeskDomainModel desk = await _deskService.GetById(id);
            return Ok(desk);
        }

        [HttpPut]
        [Route("put/{roomId}")]
        public async Task<ActionResult<DeskDomainModel>> Put(Guid roomId)
        {
            DeskDomainModel desk = _deskService.Add(roomId);
            return Ok(desk);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<ActionResult<DeskDomainModel>> Delete(Guid id)
        {
            DeskDomainModel deletedDesk;
            try
            {
                deletedDesk = _deskService.Delete(id);
            }
            catch (DbUpdateException e)
            {

                return BadRequest();
            }
            catch (ArgumentNullException e)
            {
                return BadRequest();
            }
            return Ok(deletedDesk);
        }
    }
}
