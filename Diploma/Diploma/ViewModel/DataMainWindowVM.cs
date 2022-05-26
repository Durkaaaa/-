using Diploma.Command;
using Diploma.View;
using System.Windows.Controls;

namespace Diploma.ViewModel
{
    public class DataMainWindowVM : ViewModelBase
    {
        public DataMainWindowVM() { }

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
    }
}
