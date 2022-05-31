using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diplom.Model
{
    public class Speciality
    {
        public int Id { get; set; }
        public string Titl { get; set; }

        // Ссылка на врачей
        [NotMapped]
        public List<Doctor> Doctors { get; set; }
    }
}
