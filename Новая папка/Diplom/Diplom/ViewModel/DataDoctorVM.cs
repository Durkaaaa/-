using System;
using Diplom.Model;
using Diplom.Command;
using Diplom.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diplom.View;

namespace Diplom.ViewModel
{
    public class DataDoctorVM : ViewModelBase
    {
        private List<Doctor> _allDoctor;
        private Doctor _selectedDoctor;
        private RelayCommand _addNewDoctor;

        public DataDoctorVM()
        {
            AllDoctor = DataWorker.GetAllDoctor();
        }

        public List<Doctor> AllDoctor
        {
            get => _allDoctor;
            set 
            { 
                _allDoctor = value;
                NotifyPropertyChanged(nameof(AllDoctor));
            }
        }

        public Doctor SelectedDoctor
        {
            get => _selectedDoctor;
            set
            {
                _selectedDoctor = value;
                NotifyPropertyChanged(nameof(SelectedDoctor));
            }
        }

        public RelayCommand AddNewDoctor
        {
            get
            {
                return _addNewDoctor ?? new RelayCommand(obj =>
                {
                    AddNewDoctorWindow addNewDoctorWindow = new AddNewDoctorWindow();
                    SetCenterPositionAndOpen(addNewDoctorWindow);
                });
            }
        }
    }
}
