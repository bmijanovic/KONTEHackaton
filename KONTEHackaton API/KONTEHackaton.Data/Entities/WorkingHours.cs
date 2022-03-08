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
        public int Id { get; set; }

        [Column("opens")]
        public DateTime Opens { get; set; }

        [Column("closes")]
        public DateTime Closes { get; set; }

        public ICollection<Faculty> Faculties { get; set; }

    }
}
