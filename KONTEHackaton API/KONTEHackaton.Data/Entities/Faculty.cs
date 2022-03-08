using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace KONTEHackaton.Data.Entities
{
    [Table("Faculty")]
    public class Faculty
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        public WorkingHours WorkingHours { get; set; }

        [Column("working-hours")]
        public int WorkingHoursId { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }

    }
}
