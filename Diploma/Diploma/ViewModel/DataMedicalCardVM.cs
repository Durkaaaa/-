using Diploma.Command;
using Diploma.Model;
using System.Collections.Generic;
using System.Linq;

namespace Diploma.ViewModel
{
    public class DataMedicalCardVM : ViewModelBase
    {
        public static Patient SelectedPatient { get; set; }
        public static MedicalСard SelectedMedicalСard { get; set; }
        public static List<MedicalСard> AllMedicalСard { get; set; }
        public static Medicine SelectedMedicine { get; set; }
        public static string Medicine { get; set; }
        public static int IndexMedicalСard { get; set; }

        public DataMedicalCardVM(Patient selectedPatient)
        {
            SelectedPatient = selectedPatient;
            AllMedicalСard = DataWorker.GetMedicalСardByPatientId(SelectedPatient);
            IndexMedicalСard = 0;
            SelectedMedicalСard = AllMedicalСard[IndexMedicalСard];
            _allMedicine = DataWorker.GetAllMedicinesByMedicalСardId(SelectedMedicalСard.Id);
        }

        private List<Medicine> _allMedicine;
        public List<Medicine> AllMedicine
        {
            get { return _allMedicine; }
            set
            {
                _allMedicine = value;
                NotifyPropertyChanged("AllMedicine");
            }
        }

        public RelayCommand AddNewMedicine
        {
            get
            {
                return null ?? new RelayCommand(obj =>
                {
                    var result = DataWorker.AddNewMedicine(SelectedMedicalСard, Medicine);
                    ShowMessageToUser(result);
                });
            }
        }
        
        public RelayCommand EditMedicine
        {
            get
            {
                return null ?? new RelayCommand(obj =>
                {
                    if (SelectedMedicine != null)
                    {
                        var result = DataWorker.EditMedicine(SelectedMedicine, SelectedMedicalСard, Medicine);
                        ShowMessageToUser(result);
                    }
                });
            }
        }


        public RelayCommand AddNewMedicalCard
        {
            get
            {
                return null ?? new RelayCommand(obj =>
                {

                });
            }
        }

        public RelayCommand EditMedicalCard
        {
            get
            {
                return null ?? new RelayCommand(obj =>
                {
                    if (SelectedMedicalСard != null)
                    {

                    }
                });
            }
        }

        public RelayCommand OpenNextMedicalCard
        {
            get
            {
                return null ?? new RelayCommand(obj =>
                {
                    int count = AllMedicalСard.Count();
                    if (AllMedicalСard != null && count >= IndexMedicalСard + 1)
                    {
                        SelectedMedicalСard = AllMedicalСard[IndexMedicalСard + 1];
                        IndexMedicalСard++;
                    }
                });
            }
        }

        public RelayCommand OpenPreviousMedicalCard
        {
            get
            {
                return null ?? new RelayCommand(obj =>
                {
                    int count = AllMedicalСard.Count();
                    if (AllMedicalСard != null && 0 <= IndexMedicalСard - 1)
                    {
                        SelectedMedicalСard = AllMedicalСard[IndexMedicalСard - 1];
                        IndexMedicalСard--;
                    }
                });
            }
        }

        public RelayCommand DeleteMedicines
        {
            get
            {
                return null ?? new RelayCommand(obj =>
                {
                    var result = DataWorker.DeleteMedicine(SelectedMedicine);
                    ShowMessageToUser(result);
                });
            }
        }

        public RelayCommand DeleteMedicalСard
        {
            get
            {
                return null ?? new RelayCommand(obj =>
                {
                    var result = DataWorker.DeleteMedicalСard(SelectedMedicalСard);
                    ShowMessageToUser(result);
                    AllMedicalСard = DataWorker.GetMedicalСardByPatientId(SelectedPatient);
                    int count = AllMedicalСard.Count();
                    if (AllMedicalСard != null)
                    {
                        if (IndexMedicalСard + 1 <= count)
                        {
                            SelectedMedicalСard = AllMedicalСard[IndexMedicalСard + 1];
                            IndexMedicalСard++;
                        }
                        else
                        {
                            if (IndexMedicalСard - 1 <= 0)
                            {
                                SelectedMedicalСard = AllMedicalСard[IndexMedicalСard - 1];
                                IndexMedicalСard--;
                            }
                        }
                    }
                });
            }
        }
    }
}
