using Diploma.Command;
using Diploma.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.ViewModel
{
    public class DataAddNewTicketVM : ViewModelBase
    {
        public static Patient SelectedPatient { get; set; }
        public static Doctor SelectedDoctor { get; set; }
        public static DateTime StartOfReception { get; set; }

        private int _startOfReceptionHour;
        public int StartOfReceptionHour
        {
            get { return _startOfReceptionHour; }
            set
            {
                _startOfReceptionHour = value;
                NotifyPropertyChanged("StartOfReceptionHour");
            }
        }

        private int _startOfReceptionMinute;
        public int StartOfReceptionMinute
        {
            get { return _startOfReceptionMinute; }
            set
            {
                _startOfReceptionMinute= value; ;
                NotifyPropertyChanged("StartOfReceptionMinute");
            }
        }

        public DataAddNewTicketVM()
        {
            StartOfReception = DateTime.Now;
        }

        private List<Patient> _allPatient;
        public List<Patient> AllPatient
        {
            get { return _allPatient; }
            set
            {
                _allPatient = value;
                NotifyPropertyChanged("Allpatient");
            }
        }

        private List<Doctor> _allDoctor;
        public List<Doctor> AllDoctor
        {
            get { return _allDoctor; }
            set
            {
                _allDoctor = value;
                NotifyPropertyChanged("AllDoctor");
            }
        }

        public RelayCommand AddNewTicket
        {
            get
            {
                return null ?? new RelayCommand(obj =>
                {
                    DateTime startOfReception = new DateTime(1, 1, 1, StartOfReceptionHour, StartOfReceptionMinute, 00);
                    var boolPatient = DataWorker.BoolPatient(SelectedPatient, startOfReception);
                });
            }
        }
    }
}
