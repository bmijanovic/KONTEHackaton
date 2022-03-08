using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace KONTEHackaton.Data.Entities
{
    [Table("Desk")]
    public class Desk
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("order")]
        public int Order { get; set; }

        [Column("available")]
        public int Available { get; set; }

        public Room Room { get; set; }

        public Guid RoomId { get; set; }
    }
}
