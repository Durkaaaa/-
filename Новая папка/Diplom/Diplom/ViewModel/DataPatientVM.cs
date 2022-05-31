using Diplom.Command;
using Diplom.Model;
using Diplom.View;
using System.Collections.Generic;

namespace Diplom.ViewModel
{
    public class DataPatientVM : ViewModelBase
    {
        private List<Patient> _allPatient;
        private Patient _selectedPatient;

        public DataPatientVM()
        {
            AllPatient = DataWorker.GetAllPatient();
        }

        #region[Поля]
        public List<Patient> AllPatient
        {
            get => _allPatient;
            set
            {
                _allPatient = value;
                NotifyPropertyChanged(nameof(AllPatient));
            }
        }

        public Patient SelectedPatient
        {
            get => _selectedPatient;
            set
            {
                _selectedPatient = value;
                NotifyPropertyChanged(nameof(SelectedPatient));
            }
        }
        #endregion

        public RelayCommand AddNewPatient
        {
            get
            {
                return null ?? new RelayCommand(obj =>
                {
                    AddNewPatientWindow addNewPatientWindow = new AddNewPatientWindow();
                    SetCenterPositionAndOpen(addNewPatientWindow);
                    UpdatePatientList();
                });
            }
        }

        public RelayCommand EditPatient
        {
            get
            {
                return null ?? new RelayCommand(obj =>
                {
                    if (SelectedPatient != null)
                    {
                        EditPatientWindow editPatientWindow = new EditPatientWindow(SelectedPatient);
                        SetCenterPositionAndOpen(editPatientWindow);
                        SelectedPatient = null;
                        UpdatePatientList();
                    }
                });
            }
        }

        public RelayCommand DeletePatient
        {
            get
            {
                return null ?? new RelayCommand(obj =>
                {
                    if (SelectedPatient != null)
                    {
                        var result = DataWorker.DeletePatient(SelectedPatient);
                        ShowMessageToUser(result);
                        SelectedPatient = null;
                        UpdatePatientList();
                    }
                });
            }
        }

        private void UpdatePatientList()
        {
            AllPatient = DataWorker.GetAllPatient();
            PatientPage.PatientList.ItemsSource = null;
            PatientPage.PatientList.Items.Clear();
            PatientPage.PatientList.ItemsSource = AllPatient;
            PatientPage.PatientList.Items.Refresh();
        }
    }
}
