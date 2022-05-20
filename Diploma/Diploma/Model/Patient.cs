using System;

namespace Diploma.Model
{
    public class Patient
    {
        public int Id { get; set; } 
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int GenderId { get; set; }
        public virtual Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ulong Policy { get; set; }
        public ulong Snils { get; set; }
        public long PassportSeries { get; set; }
        public long PassportNumber { get; set; }
        public string Address { get; set; }
    }
}
