using KONTEHackaton.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KONTEHackaton.Domain.Models
{
    public class RoomDomainModel
    {
        public Guid Id { get; set; } 
        public string Name { get; set; }
        
        public Guid FacultyID { get; set; }

        public ICollection<DeskDomainModel> DesksList { get; set; }

    }
}
