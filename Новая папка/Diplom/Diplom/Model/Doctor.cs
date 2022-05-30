using System;
using System.Collections.Generic;

namespace Diplom.Model
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public virtual Speciality Speciality { get; set; }
        public virtual Cabinet Cabinet { get; set; }
        public DateTime DateOfEmployment { get; set; }
        public DateTime WorkWith { get; set; }
        public DateTime WorkUntil { get; set; }

        // Ссылка на специальность
        public List<Speciality> Specialities { get; set; }
        // Ссылка на кабинет
        public List<Cabinet> Cabinets { get; set;}
        // Ссылка на мед. страницы
        public List<MedicalRecord> MedicalRecords { get; set; }
        // Ссылка на табол
        public List<Ticket> Ticket { get; set; }
    }
}
