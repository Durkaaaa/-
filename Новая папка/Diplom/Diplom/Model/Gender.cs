using System.Collections.Generic;

namespace Diplom.Model
{
    public class Gender
    {
        public int Id { get; set; }
        public string Titl { get; set; }

        // Ссылка на пацинетов
        public List<Patient> Patients { get; set; }
    }
}
