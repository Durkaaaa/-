using Diplom.Model;
using Diplom.Command;
using System.Collections.Generic;
using Diplom.View;

namespace Diplom.ViewModel
{
    public class DataDoctorVM : ViewModelBase
    {
        private List<Doctor> _allDoctor;
        private Doctor _selectedDoctor;

        public DataDoctorVM()
        {
            AllDoctor = DataWorker.GetAllDoctor();
        }

        #region[Поля]
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
        #endregion

        public RelayCommand AddNewDoctor
        {
            get
            {
                return null ?? new RelayCommand(obj =>
                {
                    AddNewDoctorWindow addNewDoctorWindow = new AddNewDoctorWindow();
                    SetCenterPositionAndOpen(addNewDoctorWindow);
                    UpdateDoctorList();
                });
            }
        }

        public RelayCommand EditDoctor
        {
            get
            {
                return null ?? new RelayCommand(obj =>
                {
                    if (SelectedDoctor != null)
                    {
                        EditDoctorWindow editDoctorWindow = new EditDoctorWindow(SelectedDoctor);
                        SetCenterPositionAndOpen(editDoctorWindow);
                        SelectedDoctor = null;
                        UpdateDoctorList();
                    }
                });
            }
        }

        public RelayCommand DeleteDoctor
        {
            get
            {
                return null ?? new RelayCommand(obj =>
                {
                    if (SelectedDoctor != null)
                    {
                        var result = DataWorker.DeleteDoctor(SelectedDoctor);
                        ShowMessageToUser(result);
                        SelectedDoctor = null;
                        UpdateDoctorList();
                    }
                });
            }
        }

        private void UpdateDoctorList()
        {
            AllDoctor = DataWorker.GetAllDoctor();
            DoctorPage.DoctorList.ItemsSource = null;
            DoctorPage.DoctorList.Items.Clear();
            DoctorPage.DoctorList.ItemsSource = AllDoctor;
            DoctorPage.DoctorList.Items.Refresh();
        }
    }
}
