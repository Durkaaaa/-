using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diplom.Model
{
    public class MedicalCard
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }

        // Ссылка на пациентов
        [NotMapped]
        public List<Patient> Patients { get; set; }
        // Ссылка на мед. страницы
        [NotMapped]
        public List<MedicalRecord> MedicalRecords { get; set; }
    }
}
