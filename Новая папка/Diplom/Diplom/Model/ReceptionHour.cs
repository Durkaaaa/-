using System;
using System.Collections.Generic;

namespace Diplom.Model
{
    public class ReceptionHour
    {
        public int Id { get; set; }
        public DateTime StartOfReception { get; set; }
        public DateTime EndOfReception { get; set; }

        // Ссылка на табол
        public List<Ticket> Ticket { get; set; }
    }
}
