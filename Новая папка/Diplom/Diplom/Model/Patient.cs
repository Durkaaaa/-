using System;
using System.Collections.Generic;

namespace Diplom.Model
{
    public class Patient
    {
        public int Id { get; set; } 
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public virtual Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Policy { get; set; }
        public string Snils { get; set; }
        public string PassportSeries { get; set; }
        public string PassportNumber { get; set; }
        public string Address { get; set; }

        // Ссылка на пол
        public List<Gender> Genders { get; set; } 
        // Ссылка на мед. карту
        public List<MedicalCard> MedicalCards { get; set; }
        // Ссылка на табол
        public List<Ticket> Ticket { get; set; }
    }
}
