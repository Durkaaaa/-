using Diploma.Model;
using Diploma.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Diploma.Command
{
    public class DataWorker
    {
        public static List<Gender> GetAllGender()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Genders.ToList();
                return result;
            }
        }

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
                    if (dateOfBirth <= DateTime.Now)
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
                    else
                    {
                        result = "Неверная дата рождения";
                    }
                }
                return result;
            }
        }

        public static string EditPatient(Patient selectedPatient, string surname, string name, string lastname, Gender selectedGender,
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
                    if (dateOfBirth <= DateTime.Now)
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
                    else
                    {
                        result = "Неверная дата рождения";
                    }
                }
                return result;
            }
        }
    }
}
