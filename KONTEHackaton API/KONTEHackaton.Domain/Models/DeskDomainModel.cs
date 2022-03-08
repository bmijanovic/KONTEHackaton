using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KONTEHackaton.Domain.Models
{
    public class DeskDomainModel
    {
        public Guid Id { get; set; }
        
        public int Available { get; set; }
        public Guid RoomId { get; set; }

        public int Order { get; set; }
    }
}
