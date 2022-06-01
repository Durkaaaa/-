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
                var doctor = db.Doctors.FirstOrDefault(p => p.Id == selectedDoctor.Id);

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

        #region[Медицинская карта]
        // Создание медицинской карты
        public static void AddNewMedicalCard(Patient selectedPatient)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                bool examination = db.MedicalСards.Any(p => p.PatientId == selectedPatient.Id);
                if (!examination)
                {
                    MedicalCard medicalCard = new MedicalCard
                    {
                        PatientId = selectedPatient.Id
                    };
                    db.MedicalСards.Add(medicalCard);
                    db.SaveChanges();
                }
            }
        }

        // Проверка на наличие у пациента медицинской карты
        public static bool ExaminationMedicalCardByPatient(Patient selectedPatient)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var examination = db.MedicalСards.Any(p => p.PatientId == selectedPatient.Id);
                return examination;
            }
        }

        // Проверка на наличие в медицинской карте страниц
        public static bool ExaminationMedicalRecordByMedicalCard(MedicalCard selectedMedicalCard)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var examination = db.MedicalRecords.Any(p => p.MedicalСardId == selectedMedicalCard.Id);
                return examination;
            }
        }

        // Добавление страницы
        public static string AddNewMedicalRecord(MedicalCard selectedMedicalCard,
            Doctor selectedDoctor, string diagnosis, DateTime startOfTreatment,
            DateTime? endOfTreatment)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                MedicalRecord medicalRecord = new MedicalRecord
                {
                    MedicalСardId = selectedMedicalCard.Id,
                    DoctorSurname = selectedDoctor.Surname,
                    DoctorName = selectedDoctor.Name,
                    DoctorLastname = selectedDoctor.Lastname,
                    Diagnosis = diagnosis,
                    StartOfTreatment = startOfTreatment,
                    EndOfTreatment = endOfTreatment
                };
                db.MedicalRecords.Add(medicalRecord);
                db.SaveChanges();
                return "Страница добавлена";
            }
        }

        // Редактирование страницы
        public static string EditMedicalRecord(MedicalRecord selectedMedicalRecord,
            Doctor selectedDoctor, string diagnosis, DateTime? endOfTreatment)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var medicalRecord = db.MedicalRecords.FirstOrDefault(p => p.Id == selectedMedicalRecord.Id);
                medicalRecord.DoctorSurname = selectedDoctor.Surname;
                medicalRecord.DoctorName = selectedDoctor.Name;
                medicalRecord.DoctorLastname = selectedDoctor.Lastname;
                medicalRecord.Diagnosis = diagnosis;
                medicalRecord.EndOfTreatment = endOfTreatment;
                db.SaveChanges();
                return "Страница изменена";
            }
        }

        // Удаление страницы
        public static string DeleteMedicalRecord(MedicalRecord selectedMedicalRecord)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var medicine = db.Medicines.Where(p => p.MedicalRecordId == selectedMedicalRecord.Id).FirstOrDefault();
                var medicalRecord = db.MedicalRecords.FirstOrDefault(p => p.Id == selectedMedicalRecord.Id);

                db.Medicines.Remove(medicine);
                db.MedicalRecords.Remove(medicalRecord);
                db.SaveChanges();
                return "Страница удалена";
            }
        }
        #endregion

        #region[Лекарство]
        // Добавление
        public static void AddNewMedicine(MedicalRecord selectedMedicalRecord,
            string titl)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                bool examination = db.Medicines.Any(p => p.MedicalRecordId == selectedMedicalRecord.Id &&
                    p.Titl == titl);
                if (!examination)
                {
                    Medicine medicine = new Medicine
                    {
                        MedicalRecordId = selectedMedicalRecord.Id,
                        Titl = titl
                    };
                    db.Medicines.Add(medicine);
                    db.SaveChanges();
                }
            }
        }

        // Удаление
        public static void DeleteMedicine(Medicine selectedMedicine)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var medicine = db.Medicines.FirstOrDefault(p => p.Id == selectedMedicine.Id);
                db.Medicines.Remove(medicine);
                db.SaveChanges();
            }
        }
        #endregion

        #region[Талон]
        // Добавление
        public static string AddNewTicket(Patient patient, Doctor doctor,
            DateTime date, ReceptionHour receptionHour)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = "Такая запись уже существует";
                bool examination = db.Ticket.Any(p => p.PatientId == patient.Id &&
                    p.DoctorId == doctor.Id && p.Date == date && p.ReceptionHourId == receptionHour.Id);
                if (!examination)
                {
                    Ticket ticket = new Ticket
                    {
                        PatientId = patient.Id,
                        DoctorId = doctor.Id,
                        CabinetId = doctor.CabinetId,
                        Date = date,
                        ReceptionHourId = receptionHour.Id
                    };
                    db.Ticket.Add(ticket);
                    db.SaveChanges();
                    result = "Талон добавлен";
                }
                return result;
            }
        }

        // Удаление
        public static string DeleteTicket(Ticket selectedTicket)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var ticket = db.Ticket.FirstOrDefault(p => p.Id == selectedTicket.Id);
                db.Ticket.Remove(ticket);
                db.SaveChanges();
                return "Талон удален";
            }
        }
        #endregion

        #region[Добавление талона]
        // Список специальностей
        public static List<Speciality> GetSpecialitiesForTicket()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Specialities.ToList();
                var speciality = db.Specialities.ToList().FirstOrDefault();
                if (!db.Doctors.Any(p => p.SpecialityId == speciality.Id))
                {
                    var selectedSpeciality = result.FirstOrDefault(p => p.Id == speciality.Id);
                    result.Remove(selectedSpeciality);
                }
                return result;
            }
        }

        // Список пациентов
        public static List<Patient> GetPatientsForTicket(DateTime date,
            ReceptionHour receptionHour)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Patients.ToList();
                var patient = db.Patients.ToList().FirstOrDefault();
                if (db.Ticket.Any(p => p.PatientId == patient.Id &&
                    p.Date == date && p.ReceptionHourId == receptionHour.Id))
                {
                    var selectedPatient = result.FirstOrDefault(p => p.Id == patient.Id);
                    result.Remove(selectedPatient);
                }
                return result;
            }
        }

        // Список докторов
        public static List<Doctor> GetDoctorsForTicket(DateTime date,
            ReceptionHour receptionHour, Speciality speciality)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Doctors.ToList();
                var doctor = db.Doctors.ToList().FirstOrDefault();
                if (db.Ticket.Any(p => (p.DoctorId == doctor.Id &&
                    p.Date == date && p.ReceptionHourId == receptionHour.Id) ||
                    (p.CabinetId == doctor.CabinetId && p.Date == date &&
                    p.ReceptionHourId == receptionHour.Id)))
                {
                    var selectedDoctor = result.FirstOrDefault(p => p.Id == doctor.Id);
                    result.Remove(selectedDoctor);
                }

                var start = db.ReceptionHours.FirstOrDefault(p => p.Id == receptionHour.Id).StartOfReception.Hour;
                var end = db.ReceptionHours.FirstOrDefault(p => p.Id == receptionHour.Id).EndOfReception.Hour;
                result.Where(p => p.WorkWith.Hour <= start && p.WorkUntil.Hour >= end && p.SpecialityId == speciality.Id);
                return result;
            }
        }
        #endregion

        #region[Index в списке]
        // Index специальности
        public static int GetSpecialityIndex(List<Speciality> specialitiesList,
            int selectedSpeciality)
        {
            int index = specialitiesList.FindLastIndex(p => p.Id == selectedSpeciality);
            return index;
        }

        // Index кабинета
        public static int GetCabinetIndex(List<Cabinet> cabinetsList,
            int selectedCabinet)
        {
            int index = cabinetsList.FindLastIndex(p => p.Id == selectedCabinet);
            return index;
        }

        // Index пола
        public static int GetGenderIndex(List<Gender> gendersList,
            int selectedGender)
        {
            int index = gendersList.FindLastIndex(p => p.Id == selectedGender);
            return index;
        }
        #endregion
    }
}