using Diplom.Model;
using Diplom.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Diplom.Command
{
    public class DataWorker
    {
        #region[Вся таблица]
        // Вся таблица врачи
        public static List<Doctor> GetAllDoctor()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var allDoctor = db.Doctors.ToList();
                return allDoctor;
            }
        }

        //Вся таблица пациенты
        public static List<Patient> GetAllPatient()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var allPatient = db.Patients.ToList();
                return allPatient;
            }
        }

        // Вся таблица кабинеты
        public static List<Cabinet> GetAllCabinet()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var allCabinet = db.Cabinets.ToList();
                return allCabinet;
            }
        }

        // Вся таблица пол
        public static List<Gender> GetAllGender()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var allGender = db.Genders.ToList();
                return allGender;
            }
        }

        // Вся таблица медицинские карты
        public static List<MedicalCard> GetAllMedicalCard()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var allMedicalCard = db.MedicalСards.ToList();
                return allMedicalCard;
            }
        }

        // Вся таблица медицинские страницы
        public static List<MedicalRecord> GetAllMedicalRecord()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var allMedicalRecord = db.MedicalRecords.ToList();
                return allMedicalRecord;
            }
        }

        // Вся таблица лекарства
        public static List<Medicine> GetAllMedicine()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var allMedicine = db.Medicines.ToList();
                return allMedicine;
            }
        }

        // Вся таблица рабочие часы
        public static List<ReceptionHour> GetAllReceptionHour()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var allReceptionHour = db.ReceptionHours.ToList();
                return allReceptionHour;
            }
        }

        // Вся таблица специальность
        public static List<Speciality> GetAllSpeciality()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var allSpeciality = db.Specialities.ToList();
                return allSpeciality;
            }
        }

        // Вся таблица талоны
        public static List<Ticket> GetAllTicket()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var allTicket = db.Ticket.ToList();
                return allTicket;
            }
        }
        #endregion

        #region[Доктор]
        // Добавление
        public static string AddNewDoctor(string surname, string name, string lastname,
            Speciality speciality, Cabinet cabinet, DateTime dateOfEmployment, DateTime workWith,
            DateTime workUntil)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = "Данная запись уже существует";
                bool examination = db.Doctors.Any(p => p.Surname == surname &&
                p.Name == name && p.Lastname == lastname && p.SpecialityId == speciality.Id &&
                p.CabinetId == cabinet.Id && p.DateOfEmployment == dateOfEmployment &&
                p.WorkWith == workWith && p.WorkUntil == workUntil);

                if (!examination)
                {
                    Doctor doctor = new Doctor
                    {
                        Surname = surname,
                        Name = name,
                        Lastname = lastname,
                        SpecialityId = speciality.Id,
                        CabinetId = cabinet.Id,
                        DateOfEmployment = dateOfEmployment,
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

        // Редактирвоание
        public static string EditDoctor(Doctor selectedDoctor, string surname, string name, string lastname,
            Speciality speciality, Cabinet cabinet, DateTime dateOfEmployment, DateTime workWith,
            DateTime workUntil)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = "Данная запись уже существует";
                bool examination = db.Doctors.Any(p => p.Surname == surname &&
                p.Name == name && p.Lastname == lastname && p.SpecialityId == speciality.Id &&
                p.CabinetId == cabinet.Id && p.DateOfEmployment == dateOfEmployment &&
                p.WorkWith == workWith && p.WorkUntil == workUntil);

                if (!examination)
                {
                    result = "Вы не можете изменить время работы";
                    bool exemaitionTicket = db.Ticket.Any(p => p.ReceptionHour.StartOfReception.Hour <= workWith.Hour ||
                        p.ReceptionHour.EndOfReception.Hour >= workUntil.Hour);
                    if (!exemaitionTicket)
                    {
                        var doctor = db.Doctors.FirstOrDefault(p => p.Id == selectedDoctor.Id);
                        doctor.Surname = surname;
                        doctor.Name = name;
                        doctor.Lastname = lastname;
                        doctor.SpecialityId = speciality.Id;
                        doctor.CabinetId = cabinet.Id;
                        doctor.DateOfEmployment = dateOfEmployment;
                        doctor.WorkWith = workWith;
                        doctor.WorkUntil = workUntil;
                        db.SaveChanges();
                        result = "Запись изменена";
                    }
                }
                return result;
            }
        }

        // Удаление 
        public static string DeleteDoctor(Doctor selectedDoctor)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var ticket = db.Ticket.Where(p => p.DoctorId == selectedDoctor.Id).FirstOrDefault();
                var medicalRecord = db.MedicalRecords.Where(p => p.DoctorId == selectedDoctor.Id).FirstOrDefault();
                var medicine = db.Medicines.Where(p => p.MedicalRecordId == medicalRecord.Id).FirstOrDefault();
                var doctor = db.Doctors.FirstOrDefault(p => p.Id == selectedDoctor.Id);

                db.Medicines.Remove(medicine);
                db.MedicalRecords.Remove(medicalRecord);
                db.Ticket.Remove(ticket);
                db.Doctors.Remove(doctor);
                db.SaveChanges();
                return "Врач удален";
            }
        }
        #endregion

        #region[Пациент]
        // Добавление
        public static string AddNewPatient(string surname, string name, string lastname,
            Gender gender, DateTime dateOfBirth, string policy, string snils,
            string passportSeries, string passportNumber, string address)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = "Данная запись уже существует";
                bool examination = db.Patients.Any(p => p.Surname == surname && p.Name == name &&
                    p.Lastname == lastname && p.GenderId == gender.Id && p.Policy == policy &&
                    p.Snils == snils && p.PassportSeries == passportSeries && p.PassportNumber == passportNumber &&
                    p.Address == address && p.DateOfBirth == dateOfBirth);

                if (!examination)
                {
                    Patient patient = new Patient
                    {
                        Surname = surname,
                        Name = name,
                        Lastname = lastname,
                        GenderId = gender.Id,
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

        // Редактирование
        public static string EditPatient(Patient selectedPatient, string surname, string name,
            string lastname, Gender gender, DateTime dateOfBirth, string policy,
            string snils, string passportSeries, string passportNumber, string address)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = "Данная запись уже существует";
                bool examination = db.Patients.Any(p => p.Surname == surname && p.Name == name &&
                    p.Lastname == lastname && p.GenderId == gender.Id && p.Policy == policy &&
                    p.Snils == snils && p.PassportSeries == passportSeries && p.PassportNumber == passportNumber &&
                    p.Address == address && p.DateOfBirth == dateOfBirth);

                if (!examination)
                {
                    var patient = db.Patients.FirstOrDefault(p => p.Id == selectedPatient.Id);
                    patient.Surname = surname;
                    patient.Name = name;
                    patient.Lastname = lastname;
                    patient.GenderId = gender.Id;
                    patient.DateOfBirth = dateOfBirth;
                    patient.Policy = policy;
                    patient.Snils = snils;
                    patient.PassportSeries = passportSeries;
                    patient.PassportNumber = passportNumber;
                    patient.Address = address;
                    db.SaveChanges();
                    result = "Запись изменена";
                }
                return result;
            }
        }

        // Удаление
        public static string DeletePatient(Patient selectedPatient)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var ticket = db.Ticket.Where(p => p.PatientId == selectedPatient.Id).FirstOrDefault();
                var medicalCard = db.MedicalСards.FirstOrDefault(p => p.PatientId == selectedPatient.Id);
                var medicalRecord = db.MedicalRecords.Where(p => p.MedicalСardId == medicalCard.Id).FirstOrDefault();
                var medicine = db.Medicines.Where(p => p.MedicalRecordId == medicalRecord.Id).FirstOrDefault();
                var patient = db.Patients.FirstOrDefault(p => p.Id == selectedPatient.Id);

                db.Ticket.Remove(ticket);
                db.Medicines.Remove(medicine);
                db.MedicalRecords.Remove(medicalRecord);
                db.MedicalСards.Remove(medicalCard);
                db.Patients.Remove(patient);
                db.SaveChanges();
                return "Пациент удален";
            }
        }
        #endregion

        #region[Index в списке]
        // Index специальности
        public static int GetSpecialityIndex(List<Speciality> specialitiesList,
            int selectedSpeciality)
        {
            var row = specialitiesList.FirstOrDefault(p => p.Id == selectedSpeciality);
            int index = specialitiesList.IndexOf(row);
            return index;
        }

        // Index кабинета
        public static int GetCabinetIndex(List<Cabinet> cabinetsList,
            int selectedCabinet)
        {
            var row = cabinetsList.FirstOrDefault(p => p.Id == selectedCabinet);
            int index = cabinetsList.IndexOf(row);
            return index;
        }

        // Index пола
        public static int GetGenderIndex(List<Gender> gendersList, 
            int selectedGender)
        {
            var row = gendersList.FirstOrDefault(p => p.Id == selectedGender);
            int index = gendersList.IndexOf(row);
            return index;
        }
        #endregion
    }
}