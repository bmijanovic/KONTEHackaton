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
        public TimeSpan opens { get; set; }
        public TimeSpan closes { get; set; }   

    }
}
