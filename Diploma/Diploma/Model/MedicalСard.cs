using Diploma.Command;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diploma.Model
{
    public class MedicalСard
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        public string Diagnosis { get; set; }

        [NotMapped]
        public Patient MedicalСardPatient
        {
            get
            {
                return DataWorker.GetPatientById(PatientId);
            }
        }
        
        [NotMapped]
        public Doctor MedicalСardDoctor
        {
            get
            {
                return DataWorker.GetDoctorById(DoctorId);
            }
        }
    }
}
