using Diploma.Command;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diploma.Model
{
    public class Ticket
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        public DateTime StartOfReception { get; set; }
        public DateTime EndOfReception { get; set; }

        [NotMapped]
        public Patient TicketPatient
        {
            get
            {
                return DataWorker.GetPatientById(PatientId);
            }
        }

        [NotMapped]
        public Doctor TicketDoctor
        {
            get
            {
                return DataWorker.GetDoctorById(DoctorId);
            }
        }
    }
}
