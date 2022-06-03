using Diplom.Command;
using Diplom.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Diplom.ViewModel
{
    public class DataAddNewTicketOneVM : ViewModelBase
    {
        private DateTime _date;
        private ReceptionHour _receptionHour;
        private Speciality _speciality;
        private List<ReceptionHour> _allReceptionHour;
        private List<Speciality> _allSpeciality;

        public DataAddNewTicketOneVM()
        {
            Date = DateTime.Now;
            AllSpeciality = DataWorker.GetSpecialitiesForTicket();
            AllReceptionHour = DataWorker.GetAllReceptionHour();
        }

        public DateTime Date
        {
            get => _date;
            set
            {
                _date = value;
                NotifyPropertyChanged(nameof(Date));
            }
        }
        
        public ReceptionHour ReceptionHour
        {
            get => _receptionHour;
            set
            {
                _receptionHour = value;
                NotifyPropertyChanged(nameof(ReceptionHour));
            }
        }
        
        public Speciality Speciality
        {
            get => _speciality;
            set
            {
                _speciality = value;
                NotifyPropertyChanged(nameof(Speciality));
            }
        }

        public List<ReceptionHour> AllReceptionHour
        {
            get => _allReceptionHour;
            set
            {
                _allReceptionHour = value;
                NotifyPropertyChanged(nameof(AllReceptionHour));
            }
        }
        
        public List<Speciality> AllSpeciality
        {
            get => _allSpeciality;
            set
            {
                _allSpeciality = value;
                NotifyPropertyChanged(nameof(AllSpeciality));
            }
        }

        public RelayCommand AddNewTicket
        {
            get
            {
                return null ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    DateTime dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).AddDays(-1);
                    DateTime dateTime1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).AddDays(7);
                    if (Date <= dateTime ||
                        Date >= dateTime1 ||
                        Speciality == null ||
                        ReceptionHour == null)
                    {
                        if (Date <= dateTime || Date > dateTime1)
                            ShowMessageToUser("Не правильная дата");

                        if (ReceptionHour == null)
                            ShowMessageToUser("Не выбрано время");

                        if (Speciality == null)
                            ShowMessageToUser("Не выбрана специальность");
                    }
                    else
                    {
                        var patient = DataWorker.GetPatientsForTicket(Date, ReceptionHour);
                        var doctor = DataWorker.GetDoctorsForTicket(Date, ReceptionHour, Speciality);
                        if (doctor.Count == 0)
                        {
                            ShowMessageToUser("На эту дату и время свободных врачей нет");
                        }
                        else
                        {
                            //AddNewTicketPatientDoctorWindow addNewTicketPatientDoctorWindow = new AddNewTicketPatientDoctorWindow(patient, doctor, Date, SelectedReceptionHour, window);
                            //SetCenterPositionAndOpen(addNewTicketPatientDoctorWindow);
                            Speciality = null;
                            ReceptionHour = null;
                        }
                    }
                });
            }
        }
    }
}
