using System;

namespace Diploma.Model
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int SpecialityId { get; set; }
        public virtual Speciality Speciality { get; set; }
        public int WorkExperience { get; set; }
        public DateTime WorkWith { get; set; }
        public DateTime WorkUntil { get; set; }
    }
}
