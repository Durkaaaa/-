using Diploma.Command;
using Diploma.Model;
using System.Collections.Generic;
using System.Windows;

namespace Diploma.ViewModel
{
    public class DataEditMedicalСardVM : ViewModelBase
    {
        public static Patient SelectedPatient { get; set; }
        public static int IndexPatient { get; set; }
        public static MedicalCard SelectedMedicalСard { get; set; }

        public DataEditMedicalСardVM(MedicalCard selectedMedicalСard)
        {
            SelectedMedicalСard = selectedMedicalСard;
            SelectedPatient = SelectedMedicalСard.Patient;
            IndexPatient = DataWorker.GetIndexPatient(SelectedMedicalСard.PatientId);
        }

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

        public RelayCommand EditMedicalСard
        {
            get
            {
                return null ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    if (SelectedMedicalСard != null)
                    {
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
                                var result = DataWorker.EditMedicalСard(SelectedMedicalСard, SelectedPatient);
                                ShowMessageToUser(result);
                                SelectedMedicalСard = null;
                                SelectedPatient = null;
                                IndexPatient = 0;
                                window.Close();
                            }
                        }
                    }
                });
            }
        }
    }
}
