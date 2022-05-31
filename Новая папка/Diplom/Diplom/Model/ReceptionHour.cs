using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diplom.Model
{
    public class ReceptionHour
    {
        public int Id { get; set; }
        public DateTime StartOfReception { get; set; }
        public DateTime EndOfReception { get; set; }

        // Ссылка на табол
        [NotMapped]
        public List<Ticket> Ticket { get; set; }
    }
}
