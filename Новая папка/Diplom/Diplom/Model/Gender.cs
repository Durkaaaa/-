using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diplom.Model
{
    public class Gender
    {
        public int Id { get; set; }
        public string Titl { get; set; }

        // Ссылка на пацинетов
        [NotMapped]
        public List<Patient> Patients { get; set; }
    }
}
