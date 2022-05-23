using Diploma.Command;
using Diploma.Model;
using System.Collections.Generic;
using System.Windows;

namespace Diploma.ViewModel
{
    public class DataAddNewMedicalСardVM : ViewModelBase
    {
        public static Patient SelectedPatient { get; set; }

        private List<Patient> _allPatient = DataWorker.GetAllPatient();
        public List<Patient> AllPatient
        {
            get { return _allPatient; }
            set
            {
                _allPatient = value;
                NotifyPropertyChanged("AllPatient");
            }
        }

        public RelayCommand AddNewMedicalСard
        {
            get
            {
                return null ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    if (SelectedPatient == null)
                    {
                        ShowMessageToUser("Не выбран пациент");
                    }
                    else
                    {
                        var count = DataWorker.GetMedicalСardByPatientId(SelectedPatient).Count;
                        if (count >= 1)
                        {
                            ShowMessageToUser("У этого пациента уже есть Мед. карта");
                        }
                        else
                        {
                            var result = DataWorker.AddNewMedicalСard(SelectedPatient);
                            ShowMessageToUser(result);
                            window.Close();
                        }
                        SelectedPatient = null;
                    }
                });
            }
        }
    }
}
