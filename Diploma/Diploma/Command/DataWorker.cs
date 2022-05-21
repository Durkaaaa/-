using Diploma.Model;
using Diploma.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Diploma.Command
{
    public class DataWorker
    {
        public static List<Patient> GetAllPatient()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Patients.ToList();
                return result;
            }
        }

        public static List<Doctor> GetAllDoctor()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Doctors.ToList();
                return result;
            }
        }

        public static List<Speciality> GetAllSpeciality()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Speciality.ToList();
                return result;
            }
        }

        public static List<Gender> GetAllGender()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Genders.ToList();
                return result;
            }
        }

        #region[Пациенты]
        //Добавление
        public static string AddNewPatient(string surname, string name, string lastname, Gender selectedGender,
            DateTime dateOfBirth, string policy, string snils, string passportSeries, string passportNumber, string address)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = "Данная запись уже существует";
                bool examination = db.Patients.Any(p => p.Surname == surname && p.Name == name &&
                    p.Lastname == lastname && p.GenderId == selectedGender.Id && p.Policy == policy &&
                    p.Snils == snils && p.PassportSeries == passportSeries && p.PassportNumber == passportNumber &&
                    p.Address == address && p.DateOfBirth == dateOfBirth);

                if (!examination)
                {
                    Patient patient = new Patient
                    {
                        Surname = surname,
                        Name = name,
                        Lastname = lastname,
                        GenderId = selectedGender.Id,
                        DateOfBirth = dateOfBirth,
                        Policy = policy,
                        Snils = snils,
                        PassportSeries = passportSeries,
                        PassportNumber = passportNumber,
                        Address = address
                    };
                    db.Patients.Add(patient);
                    db.SaveChanges();
                    result = "Запись добавлена";
                }
                return result;
            }
        }

        //Редактирование
        public static string EditPatient(Patient selectedPatient, string surname, string name, string lastname, Gender selectedGender,
            DateTime dateOfBirth, string policy, string snils, string passportSeries, string passportNumber, string address)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = "Данная запись уже существует";
                bool examination = db.Patients.Any(p => p.Surname == surname && p.Name == name &&
                    p.Lastname == lastname && p.GenderId == selectedGender.Id && p.Policy == policy &&
                    p.Snils == snils && p.PassportSeries == passportSeries && p.PassportNumber == passportNumber &&
                    p.Address == address && p.DateOfBirth == dateOfBirth && p.Id == selectedPatient.Id);

                if (!examination)
                {
                    var patient = db.Patients.FirstOrDefault(p => p.Id == selectedPatient.Id);
                    if (patient != null)
                    {
                        patient.Surname = surname;
                        patient.Name = name;
                        patient.Lastname = lastname;
                        patient.GenderId = selectedGender.Id;
                        patient.DateOfBirth = dateOfBirth;
                        patient.Policy = policy;
                        patient.Snils = snils;
                        patient.PassportSeries = passportSeries;
                        patient.PassportNumber = passportNumber;
                        patient.Address = address;
                        db.SaveChanges();
                        result = "Запись изменена";
                    }
                    else
                    {
                        result = "Ошибка";
                    }
                }
                return result;
            }
        }
        #endregion

        #region[Врачи]
        //Добавление
        public static string AddNewDoctor(string surname, string name, string lastname,
            Speciality selectedSpeciality, int workExperience, DateTime workWith, DateTime workUntil)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = "Данная запись уже существует";
                bool examination = db.Doctors.Any(p => p.Surname == surname && p.Name == name &&
                    p.Lastname == lastname && p.SpecialityId == selectedSpeciality.Id &&
                    p.WorkExperience == workExperience && p.WorkWith == workWith &&
                    p.WorkUntil == workUntil);

                if (!examination)
                {
                    Doctor doctor = new Doctor
                    {
                        Surname = surname,
                        Name = name,
                        Lastname = lastname,
                        SpecialityId = selectedSpeciality.Id,
                        WorkExperience = workExperience,
                        WorkWith = workWith,
                        WorkUntil = workUntil
                    };
                    db.Doctors.Add(doctor);
                    db.SaveChanges();
                    result = "Запись добавлена";
                }
                return result;
            }
        }

        //Редактирование
        public static string EditDoctor(Doctor selectedDoctor,string surname, string name, string lastname,
            Speciality selectedSpeciality, int workExperience, DateTime workWith, DateTime workUntil)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = "Данная запись уже существует";
                bool examination = db.Doctors.Any(p => p.Surname == surname && p.Name == name &&
                    p.Lastname == lastname && p.SpecialityId == selectedSpeciality.Id &&
                    p.WorkExperience == workExperience && p.WorkWith == workWith &&
                    p.WorkUntil == workUntil && p.Id == selectedDoctor.Id);

                if (!examination)
                {
                    var doctor = db.Doctors.FirstOrDefault(p => p.Id == selectedDoctor.Id);
                    if (doctor != null)
                    {
                        doctor.Surname = surname;
                        doctor.Name = name;
                        doctor.Lastname = lastname;
                        doctor.SpecialityId = selectedSpeciality.Id;
                        doctor.WorkExperience = workExperience;
                        doctor.WorkWith = workWith;
                        doctor.WorkUntil = workUntil;
                        db.SaveChanges();
                        result = "Запись изменена";
                    }
                    else
                    {
                        result = "Ошибка";
                    }
                }
                return result;
            }
        }
        #endregion

        #region[Медицинская карта]
        //Добавление
        public static string AddNewMedicalСard(Doctor selectedDoctor, 
            Patient selectedPatient, string diagnosis)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = "Данная запись уже существует";
                bool examination = db.MedicalСards.Any(p => p.DoctorId == selectedDoctor.Id && 
                    p.PatientId == selectedPatient.Id && p.Diagnosis == diagnosis);

                if (!examination)
                {
                    MedicalСard medicalСard = new MedicalСard
                    {
                        DoctorId = selectedDoctor.Id,
                        PatientId = selectedPatient.Id,
                        Diagnosis = diagnosis
                    };
                    db.MedicalСards.Add(medicalСard);
                    db.SaveChanges();
                    result = "Запись добавлена";
                }
                return result;
            }
        }

        //Редактирование
        public static string EditMedicalСard(MedicalСard selectedMedicalСard, 
            Doctor selectedDoctor, Patient selectedPatient, string diagnosis)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = "Данная запись уже существует";
                bool examination = db.MedicalСards.Any(p => p.DoctorId == selectedDoctor.Id &&
                    p.PatientId == selectedPatient.Id && p.Diagnosis == diagnosis &&
                    p.Id == selectedMedicalСard.Id);

                if (!examination)
                {
                    var medicalСard = db.MedicalСards.FirstOrDefault(p => p.Id == selectedMedicalСard.Id);
                    if (medicalСard != null)
                    {
                        medicalСard.DoctorId = selectedDoctor.Id;
                        medicalСard.PatientId = selectedPatient.Id;
                        medicalСard.Diagnosis = diagnosis;
                    }
                    else
                    {
                        result = "Ошибка";
                    }
                    db.SaveChanges();
                    result = "Запись изменена";
                }
                return result;
            }
        }
        #endregion

        public static int GetIndexSpeciality(int Id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                List<Speciality> speciality = db.Speciality.ToList();
                var row = db.Speciality.FirstOrDefault(p => p.Id == Id);
                int index = speciality.IndexOf(row);
                return index;
            }
        }

        public static int GetIndexGender(int Id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                List<Gender> genders = db.Genders.ToList();
                var row = db.Genders.FirstOrDefault(p => p.Id == Id);
                int index = genders.IndexOf(row);
                return index;
            }
        }
        
        public static int GetIndexDoctor(int Id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                List<Doctor> doctor = db.Doctors.ToList();
                var row = db.Doctors.FirstOrDefault(p => p.Id == Id);
                int index = doctor.IndexOf(row);
                return index;
            }
        }
        
        public static int GetIndexPatient(int Id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                List<Patient> patient = db.Patients.ToList();
                var row = db.Patients.FirstOrDefault(p => p.Id == Id);
                int index = patient.IndexOf(row);
                return index;
            }
        }
    }
}
