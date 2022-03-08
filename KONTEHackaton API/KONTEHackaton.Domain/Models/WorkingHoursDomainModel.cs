using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KONTEHackaton.Domain.Models
{
    public class WorkingHoursDomainModel
    {
        public int id  { get; set; }
        public DateTime opens { get; set; }
        public DateTime closes { get; set; }   

    }
}
