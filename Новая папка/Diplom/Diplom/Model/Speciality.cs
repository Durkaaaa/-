using System.Collections.Generic;

namespace Diplom.Model
{
    public class Speciality
    {
        public int Id { get; set; }
        public string Titl { get; set; }

        // Ссылка на врачей
        public List<Doctor> Doctors { get; set; }
    }
}
