using System;
using System.Collections.Generic;

namespace Diplom.Model
{
    public class MedicalRecord
    {
        public int Id { get; set; }
        public virtual MedicalCard MedicalСard { get; set; }
        public virtual Doctor Doctor { get; set; }
        public string Diagnosis { get; set; }
        public DateTime StartOfTreatment { get; set; }
        public DateTime? EndOfTreatment { get; set; }

        // Ссылка на мед. карту
        public List<MedicalCard> MedicalCards { get; set; }
        // Ссылка на врачей
        public List<Doctor> Doctors { get; set; }
        // Ссылка на лекарства
        public List<Medicine> Medicines { get; set; }
    }
}
