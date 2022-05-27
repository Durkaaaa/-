using Diploma.Model;
using Diploma.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Diploma.Command
{
    public class DataWorker
    {

        public static bool BoolGetAllMedicineByMedicanRecordId(MedicalRecord medicalRecord)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var medicine = db.Medicines.Any(p => p.MedicalRecordId == medicalRecord.Id);
                return medicine;
            }
        }





        public static Patient GetPatientByMedicalRecord(MedicalRecord selectedMedicalRecord)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var medicalRecord = db.MedicalRecords.FirstOrDefault(p => p.Id == selectedMedicalRecord.Id);
                var medicalСard = medicalRecord.MedicalСardId;
                var patient = db.Patients.FirstOrDefault(p => p.Id == medicalСard);
                return patient;
            }
        }
        
        public static Doctor GetDoctorByMedicalRecord(MedicalRecord selectedMedicalRecord)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var medicalRecord = db.MedicalRecords.FirstOrDefault(p => p.Id == selectedMedicalRecord.Id);
                var doctorId = medicalRecord.DoctorId;
                var doctor = db.Doctors.FirstOrDefault(p => p.Id == doctorId);
                return doctor;
            }
        }


        //Удаление мед карты
        public static void DeleteMedicalCard(MedicalCard medicalCard)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                bool boolMedicalRecord = db.MedicalRecords.Any(p => p.MedicalСardId == medicalCard.Id);
                if (boolMedicalRecord)
                {
                    int allRecord = db.MedicalRecords.Where(p => p.MedicalСardId == medicalCard.Id).Count();
                    for (int i = 0; i <= allRecord; i++)
                    {
                        var record = db.MedicalRecords.FirstOrDefault(p => p.MedicalСardId == medicalCard.Id);
                        if (record != null)
                        {
                            bool boolMedicine = db.Medicines.Any(p => p.MedicalRecordId == record.Id);
                            if (boolMedicine)
                            {
                                int allMedicine = db.Medicines.Where(p => p.MedicalRecordId == record.Id).Count();
                                for (int j = 0; j <= allMedicine; j++)
                                {
                                    var medicine = db.Medicines.FirstOrDefault(p => p.MedicalRecordId == record.Id);
                                    if (medicine != null)
                                    {
                                        db.Medicines.Remove(medicine);
                                    }
                                }
                            }
                            db.MedicalRecords.Remove(record);
                        }
                    }
                }
                db.MedicalСards.Remove(medicalCard);
                db.SaveChanges();
            }
        }


        //Удаление всех лекарств по Id записи в мед карте
        public static void DeleteAllMedicineByMedicalRecordId(MedicalRecord selectedMedicalRecord)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var allMedicine = db.Medicines.Where(p => p.MedicalRecordId == selectedMedicalRecord.Id);
                db.Medicines.RemoveRange(allMedicine);
                db.SaveChanges();
            }
        }



        public static List<MedicalRecord> GetMedicalRecordByMedicalСardId(MedicalCard selectedMedicalCard)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.MedicalRecords.Where(p => p.MedicalСardId == selectedMedicalCard.Id).ToList();
                return result;
            }
        }

        public static string DeleteMedicalRecord(MedicalCard selectedMedicalCard, MedicalRecord selectedMedicalRecord)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var medicalRecord = db.MedicalRecords.FirstOrDefault(p => p.MedicalСardId == selectedMedicalCard.Id &&
                    p.Id == selectedMedicalRecord.Id);
                db.MedicalRecords.Remove(medicalRecord);

                var medicine = db.Medicines.Where(p => p.MedicalRecordId == selectedMedicalRecord.Id);
                db.Medicines.RemoveRange(medicine);
                db.SaveChanges();

                var result = "Страница удалена";
                return result;
            }
        }


        public static bool BoolGetMedicalRecordByMedicalСardId(MedicalCard selectedMedicalCard)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.MedicalRecords.Any(p => p.MedicalСardId == selectedMedicalCard.Id);
                return result;
            }
        }

        public static void AddNewMedicalRecord(MedicalCard selectedMedicalCard,
            Doctor selectedDoctor, string diagnosis, DateTime startOfTreatment,
            DateTime? endOfTreatment)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                MedicalRecord medicalRecord = new MedicalRecord
                {
                    MedicalСardId = selectedMedicalCard.Id,
                    DoctorId = selectedDoctor.Id,
                    Diagnosis = diagnosis,
                    StartOfTreatment = startOfTreatment,
                    EndOfTreatment = endOfTreatment
                };
                db.MedicalRecords.Add(medicalRecord);
                db.SaveChanges();
            }
        }

        public static void EditMedicalRecord(MedicalRecord selectedMedicalRecord, MedicalCard selectedMedicalCard,
            Doctor selectedDoctor, string diagnosis, DateTime startOfTreatment,
            DateTime? endOfTreatment)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                MedicalRecord medicalRecord = db.MedicalRecords.FirstOrDefault(p => p.Id == selectedMedicalRecord.Id);
                medicalRecord.MedicalСardId = selectedMedicalCard.Id;
                medicalRecord.DoctorId = selectedDoctor.Id;
                medicalRecord.Diagnosis = diagnosis;
                medicalRecord.StartOfTreatment = startOfTreatment;
                medicalRecord.EndOfTreatment = endOfTreatment;
                db.SaveChanges();
            }
        }



        #region[Инфо по Id]
        //Медицинская карта по Id
        public static MedicalCard GetMedicalСardById(int Id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.MedicalСards.FirstOrDefault(p => p.Id == Id);
                return result;
            }
        }

        //Пациент по Id
        public static Patient GetPatientById(int Id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Patients.FirstOrDefault(p => p.Id == Id);
                return result;
            }
        }

        //Доктор по Id
        public static Doctor GetDoctorById(int Id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Doctors.FirstOrDefault(p => p.Id == Id);
                return result;
            }
        }

        //Специальность по Id
        public static Speciality GetSpecialityById(int Id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Speciality.FirstOrDefault(p => p.Id == Id);
                return result;
            }
        }

        //Пол по Id
        public static Gender GetGenderById(int Id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Genders.FirstOrDefault(p => p.Id == Id);
                return result;
            }
        }
        #endregion

        #region[Список по Id]
        //Лекарства по Id мед карты
        public static List<Medicine> GetAllMedicinesByMedicalRecordId(MedicalRecord medicalRecord)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Medicines.Where(p => p.MedicalRecordId == medicalRecord.Id).ToList();
                return result;
            }
        }





        //Мед карты по Id пациента
        public static bool BoolGetMedicalСardByPatientId(Patient selectedPatient)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var medicalСard = db.MedicalСards.Any(p => p.PatientId == selectedPatient.Id);
                return medicalСard;
            }
        }

        public static MedicalCard GetMedicalСardByPatientId(Patient selectedPatient)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var medicalСard = db.MedicalСards.FirstOrDefault(p => p.PatientId == selectedPatient.Id);
                return medicalСard;
            }
        }
        #endregion
        public static List<MedicalRecord> GetMedicalRecordsByMedicalCardId(MedicalCard selectedMedicalCard)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.MedicalRecords.Where(p => p.MedicalСardId == selectedMedicalCard.Id).ToList();
                return result;
            }
        }

        #region[Получение полных таблиц]
        //Все пациенты
        public static List<Patient> GetAllPatient()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Patients.ToList();
                return result;
            }
        }

        //Все доктора
        public static List<Doctor> GetAllDoctor()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Doctors.ToList();
                return result;
            }
        }

        //Все специальности
        public static List<Speciality> GetAllSpeciality()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Speciality.ToList();
                return result;
            }
        }

        //Все пола
        public static List<Gender> GetAllGender()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Genders.ToList();
                return result;
            }
        }
        #endregion

        #region[Пациенты]
        //Добавление
        public static string AddNewPatient(string surname, string name, string lastname,
            Gender selectedGender, DateTime dateOfBirth, string policy, string snils,
            string passportSeries, string passportNumber, string address)
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
        public static string EditPatient(Patient selectedPatient, string surname, string name,
            string lastname, Gender selectedGender, DateTime dateOfBirth, string policy,
            string snils, string passportSeries, string passportNumber, string address)
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

        public static string DeletePatient(Patient selectedPatient)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = "Ошибка";
                if (selectedPatient != null)
                {
                    var patient = db.Patients.FirstOrDefault(p => p.Id == selectedPatient.Id);
                    db.Patients.Remove(patient);
                    db.SaveChanges();
                    result = "Запись удалена";
                }
                return result;
            }
        }
        #endregion

        #region[Врачи]
        //Добавление
        public static string AddNewDoctor(string surname, string name, string lastname,
            Speciality selectedSpeciality, DateTime dateOfEmployment, DateTime workWith,
            DateTime workUntil)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = "Данная запись уже существует";
                bool examination = db.Doctors.Any(p => p.Surname == surname && p.Name == name &&
                    p.Lastname == lastname && p.SpecialityId == selectedSpeciality.Id &&
                    p.DateOfEmployment == dateOfEmployment && p.WorkWith == workWith &&
                    p.WorkUntil == workUntil);

                if (!examination)
                {
                    Doctor doctor = new Doctor
                    {
                        Surname = surname,
                        Name = name,
                        Lastname = lastname,
                        SpecialityId = selectedSpeciality.Id,
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

        //Редактирование
        public static string EditDoctor(Doctor selectedDoctor, string surname, string name, string lastname,
            Speciality selectedSpeciality, DateTime dateOfEmployment, DateTime workWith, DateTime workUntil)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = "Данная запись уже существует";
                bool examination = db.Doctors.Any(p => p.Surname == surname && p.Name == name &&
                    p.Lastname == lastname && p.SpecialityId == selectedSpeciality.Id &&
                    p.DateOfEmployment == dateOfEmployment && p.WorkWith == workWith &&
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
                        doctor.DateOfEmployment = dateOfEmployment;
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

        //Удаление
        public static string DeleteDoctor(Doctor selectedDoctor)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = "Ошибка";
                if (selectedDoctor != null)
                {
                    var doctor = db.Doctors.FirstOrDefault(p => p.Id == selectedDoctor.Id);
                    db.Doctors.Remove(doctor);
                    db.SaveChanges();
                    result = "Запись удалена";
                }
                return result;
            }
        }
        #endregion

        #region[Медицинская карта]
        //Добавление
        public static MedicalCard AddNewMedicalСard(Patient selectedPatient)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                MedicalCard medicalCard = new MedicalCard
                {
                    PatientId = selectedPatient.Id
                };
                db.MedicalСards.Add(medicalCard);
                db.SaveChanges();
                return medicalCard;
            }
        }

        //Редактирование
        public static string EditMedicalСard(MedicalCard selectedMedicalСard,
            Patient selectedPatient)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = "У этого пациента уже есть Мед. карта";
                bool examination = db.MedicalСards.Any(p => p.PatientId == selectedPatient.Id &&
                    p.Id == selectedMedicalСard.Id);

                if (!examination)
                {
                    var medicalСard = db.MedicalСards.FirstOrDefault(p => p.Id == selectedMedicalСard.Id);
                    if (medicalСard != null)
                    {
                        medicalСard.PatientId = selectedPatient.Id;
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

        //Удаление
        public static string DeleteMedicalСard(MedicalCard selectedMedicalСard)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var medicalCard = db.MedicalСards.FirstOrDefault(p => p.Id == selectedMedicalСard.Id);
                db.MedicalСards.Remove(medicalCard);
                db.SaveChanges();
                var result = "Запись удалена";
                return result;
            }
        }
        #endregion

        #region[Лекарства]
        //Добавление
        public static void AddNewMedicine(MedicalRecord selectedMedicalRecord, string titl)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                bool examination = db.Medicines.Any(p => p.MedicalRecordId == selectedMedicalRecord.Id && p.Titl == titl);
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

        //Редактирование
        public static void EditMedicine(Medicine selectedMedicine, MedicalRecord selectedMedicalRecord, string titl)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                bool examination = db.Medicines.Any(p => p.MedicalRecordId == selectedMedicalRecord.Id &&
                    p.Titl == titl && p.Id == selectedMedicine.Id);

                if (!examination)
                {
                    var medicine = db.Medicines.FirstOrDefault(p => p.Id == selectedMedicine.Id);
                    if (medicine != null)
                    {
                        medicine.MedicalRecordId = selectedMedicalRecord.Id;
                        medicine.Titl = titl;
                        db.SaveChanges();
                    }
                }
            }
        }

        //Удаление
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

        #region[Получение Index по Id]
        //Получение Index по Id специальности
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

        //Получение Index по Id пола
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

        //Получение Index по Id доктора
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

        //Получение Index по Id пациента
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
        #endregion
    }
}