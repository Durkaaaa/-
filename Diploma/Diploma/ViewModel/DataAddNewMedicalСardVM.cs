using Diploma.Command;
using Diploma.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Diploma.ViewModel
{
    public class DataAddNewMedicalСardVM : ViewModelBase
    {
        public static Patient SelectedPatient { get; set; }
        public static Doctor SelectedDoctor { get; set; }
        public string Diagnosis { get; set; }

        public DataAddNewMedicalСardVM() { }

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

        private List<Doctor> _allDoctor = DataWorker.GetAllDoctor();
        public List<Doctor> AllDoctor
        {
            get { return _allDoctor; }
            set
            {
                _allDoctor = value;
                NotifyPropertyChanged("AllDoctor");
            }
        }

        public RelayCommand AddNewMedicalСard
        {
            get
            {
                return null ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    if (SelectedDoctor == null ||
                        SelectedPatient == null ||
                        Diagnosis == null || Diagnosis.Replace(" ", "").Length == 0)
                    {
                        if (SelectedDoctor == null)
                            ShowMessageToUser("Не выбран доктор");

                        if (SelectedPatient == null)
                            ShowMessageToUser("Не выбран пациент");

                        if (Diagnosis == null || Diagnosis.Replace(" ", "").Length == 0)
                            SetRedBlockControll(window, "DiagnosisBlock");
                        else
                            SetBlackBlockControll(window, "DiagnosisBlock");
                    }
                    else
                    {
                        SetBlackBlockControll(window, "DiagnosisBlock");
                        var result = DataWorker.AddNewMedicalСard(SelectedDoctor, SelectedPatient, Diagnosis);
                        ShowMessageToUser(result);
                        Zeroing();
                        window.Close();
                    }
                });
            }
        }

        private void Zeroing()
        {
            SelectedDoctor = null;
            SelectedPatient = null;
            Diagnosis = null;
        }
    }
}
