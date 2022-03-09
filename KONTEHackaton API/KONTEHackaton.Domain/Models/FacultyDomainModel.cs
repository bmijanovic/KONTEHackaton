using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KONTEHackaton.Domain.Models
{
    public class FacultyDomainModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        
        public WorkingHoursDomainModel WorkingHours { get; set; }

        public ICollection<RoomDomainModel> RoomsList { get; set; }

    }
}
