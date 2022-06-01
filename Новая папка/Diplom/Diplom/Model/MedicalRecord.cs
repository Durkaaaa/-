using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diplom.Model
{
    public class MedicalRecord
    {
        public int Id { get; set; }
        public int MedicalСardId { get; set; }
        public virtual MedicalCard MedicalСard { get; set; }
        public string DoctorSurname { get; set; }
        public string DoctorName { get; set; }
        public string DoctorLastname { get; set; }
        public string Diagnosis { get; set; }
        public DateTime StartOfTreatment { get; set; }
        public DateTime? EndOfTreatment { get; set; }

        // Ссылка на мед. карту
        [NotMapped]
        public List<MedicalCard> MedicalCards { get; set; }
        // Ссылка на врачей
        [NotMapped]
        public List<Doctor> Doctors { get; set; }
        // Ссылка на лекарства
        [NotMapped]
        public List<Medicine> Medicines { get; set; }
    }
}
