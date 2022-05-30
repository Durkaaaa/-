using Diplom.Model;
using Diplom.Model.Data;
using Diplom.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                var allSpeciality = db.Speciality.ToList();
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
        public static string AddNewDoctor(string surname, string name, string lastname,
            int specialityId, int cabinetId, DateTime dateOfEmployment, DateTime workWith,
            DateTime addNewDoctor)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                bool examination = db.Doctors.Any(p => p.Surname == surname &&
                p.Name == name && p.Lastname == lastname && p.Speciality.Id == specialityId &&
                p.Cabinet == cabinetId;
            }
        }
        #endregion
    }
}