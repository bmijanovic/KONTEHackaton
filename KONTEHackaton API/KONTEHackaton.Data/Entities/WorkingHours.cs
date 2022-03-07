using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace KONTEHackaton.Data.Entities
{
    [Table("WorkingHours")]
    public class WorkingHours
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("opens")]
        public TimeOnly Opens { get; set; }

        [Column("closes")]
        public TimeOnly Closes { get; set; }

    }
}
