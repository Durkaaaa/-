using Diplom.Command;
using Diplom.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Diplom.ViewModel
{
    public class DataMainVM : ViewModelBase
    {
        public DataMainVM()
        {
            PatientPage patientPage = new PatientPage();
            Page = patientPage;
        }

        private Page _page;
        public Page Page
        {
            get => _page;
            set
            {
                _page = value;
                NotifyPropertyChanged(nameof(Page));
            }
        }

        public RelayCommand OpenDoctorPage
        {
            get
            {
                return null ?? new RelayCommand(obj =>
                {
                    DoctorPage doctorPage = new DoctorPage();
                    MainWindow.FramePage.Content = doctorPage;
                });
            }
        }

        public RelayCommand OpenPatientPage
        {
            get
            {
                return null ?? new RelayCommand(obj =>
                {
                    PatientPage patientPage = new PatientPage();
                    MainWindow.FramePage.Content = patientPage;
                });
            }
        }

        public RelayCommand OpenTicketPage
        {
            get
            {
                return null ?? new RelayCommand(obj =>
                {
                    TicketPage ticketPage = new TicketPage();
                    MainWindow.FramePage.Content = ticketPage;
                });
            }
        }
    }
}
