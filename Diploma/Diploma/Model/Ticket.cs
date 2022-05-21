using System;

namespace Diploma.Model
{
    public class Ticket
    {
        public int Id { get; set; }
        public int MedicalСardId { get; set; }
        public virtual MedicalСard MedicalСard { get; set; }
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        public DateTime DateOfReceipt { get; set; }
        public int CabinetId { get; set; }
        public virtual Cabinet Cabinet { get; set; }
    }
}
