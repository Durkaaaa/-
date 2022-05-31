using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diplom.Model
{
    public class Cabinet
    {
        public int Id { get; set; }
        public string Titl { get; set; }

        // Ссылка на кабинеты
        [NotMapped]
        public List<Cabinet> Cabinets { get; set; }
    }
}
