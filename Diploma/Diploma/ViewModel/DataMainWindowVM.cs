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
                    Page = doctorPage;
                });
            }
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

    }
}
