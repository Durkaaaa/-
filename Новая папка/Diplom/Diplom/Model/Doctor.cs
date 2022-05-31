using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diplom.Model
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int SpecialityId { get; set; }
        public virtual Speciality Speciality { get; set; }
        public int CabinetId { get; set; }
        public virtual Cabinet Cabinet { get; set; }
        public DateTime DateOfEmployment { get; set; }
        public DateTime WorkWith { get; set; }
        public DateTime WorkUntil { get; set; }

        // Ссылка на специальность
        [NotMapped]
        public List<Speciality> Specialities { get; set; }
        // Ссылка на кабинет
        [NotMapped]
        public List<Cabinet> Cabinets { get; set;}
        // Ссылка на мед. страницы
        [NotMapped]
        public List<MedicalRecord> MedicalRecords { get; set; }
        // Ссылка на табол
        [NotMapped]
        public List<Ticket> Tickets { get; set; }
    }
}
