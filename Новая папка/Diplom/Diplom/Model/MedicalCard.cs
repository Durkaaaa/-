using System.Collections.Generic;

namespace Diplom.Model
{
    public class MedicalCard
    {
        public int Id { get; set; }
        public virtual Patient Patient { get; set; }

        // Ссылка на пациентов
        public List<Patient> Patients { get; set; }
        // Ссылка на мед. страницы
        public List<MedicalRecord> MedicalRecords { get; set; }
    }
}
