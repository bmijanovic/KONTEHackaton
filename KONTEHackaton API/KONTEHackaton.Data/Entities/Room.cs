using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace KONTEHackaton.Data.Entities
{
    [Table("Room")]
    public class Room
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        public virtual ICollection<Desk> Desks { get; set; }

        public Faculty Faculty { get; set; }

        [Column("facultyId")]
        public Guid FacultyId { get; set; }

    }
}

