using KONTEHackaton.Domain.Interfaces;
using KONTEHackaton.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace KONTEHackaton_API.Controllers
{
    [ApiController]
    [Route("api/room")]
    public class RoomControler : ControllerBase
    {
        private readonly IRoomService _roomService;
        public RoomControler(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomDomainModel>>> Get()
        {
            IEnumerable<RoomDomainModel> list = await _roomService.GetAll();
            return Ok(list);
        }

        [HttpGet]
        [Route("byId/{id}")]
        public async Task<ActionResult<RoomDomainModel>> GetRoomById(Guid id)
        {
            RoomDomainModel room = await _roomService.GetById(id);
            return Ok(room);
        }
    }
}
