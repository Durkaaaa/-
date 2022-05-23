using Diploma.Command;
using Diploma.Model;
using Diploma.View;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Diploma.ViewModel
{
    public class DataMedicalCardVM : ViewModelBase
    {
        public static Patient SelectedPatient { get; set; }
        public static MedicalCard SelectedMedicalCard { get; set; }
        public static MedicalRecord SelectedMedicalRecord { get; set; }
        public static Medicine SelectedMedicine { get; set; }
        public static string PatientSurname { get; set; }
        public static string PatientName { get; set; }
        public static string PatientLastname { get; set; }
        public static DateTime PatientDateOfBirth { get; set; }
        public static Gender SelectedGender { get; set; }
        public static string DoctorSurname { get; set; }
        public static string DoctorName { get; set; }
        public static string DoctorLastname { get; set; }

        public static string Medicine { get; set; }

        public DataMedicalCardVM(Patient selectedPatient)
        {
            SelectedPatient = selectedPatient;
            bool medicalCard = DataWorker.GetMedicalСardByPatientId(SelectedPatient);
            if (!medicalCard)
            {
                SelectedMedicalCard = DataWorker.AddNewMedicalСard(SelectedPatient);
                AddNewMedicalRecordWindow addNewMedicalRecordWindow = new AddNewMedicalRecordWindow(SelectedMedicalCard);
                SetCenterPositionAndOpen(addNewMedicalRecordWindow);
                SelectedMedicalRecord = DataWorker.GetMedicalRecordsByMedicalCardId(SelectedMedicalCard)[0];


            }
            else
            {
                SelectedMedicalCard = DataWorker.GetMedicalСardByPatient(SelectedPatient);
            }

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

        #region[Лекарства]
        public RelayCommand AddNewMedicine
        {
            get
            {
                return null ?? new RelayCommand(obj =>
                {
                    var result = DataWorker.AddNewMedicine(SelectedMedicalCard, Medicine);
                    ShowMessageToUser(result);
                    Medicine = null;
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
                        var result = DataWorker.EditMedicine(SelectedMedicine, SelectedMedicalCard, Medicine);
                        ShowMessageToUser(result);
                        SelectedMedicine = null;
                        Medicine = null;
                    }
                });
            }
        }

        public RelayCommand DeleteMedicine
        {
            get
            {
                return null ?? new RelayCommand(obj =>
                {
                    var result = DataWorker.DeleteMedicine(SelectedMedicine);
                    ShowMessageToUser(result);
                    SelectedMedicine = null;
                });
            }
        }
        #endregion

        public RelayCommand AddNewMedicalRecord
        {
            get
            {
                return null ?? new RelayCommand(obj =>
                {

                });
            }
        }

        #region MyRegion
        //public RelayCommand OpenNextMedicalCard
        //{
        //    get
        //    {
        //        return null ?? new RelayCommand(obj =>
        //        {
        //            int count = AllMedicalСard.Count();
        //            if (AllMedicalСard != null && count >= IndexMedicalСard + 1)
        //            {
        //                SelectedMedicalСard = AllMedicalСard[IndexMedicalСard + 1];
        //                IndexMedicalСard++;
        //            }
        //        });
        //    }
        //}

        //public RelayCommand OpenPreviousMedicalCard
        //{
        //    get
        //    {
        //        return null ?? new RelayCommand(obj =>
        //        {
        //            int count = AllMedicalСard.Count();
        //            if (AllMedicalСard != null && 0 <= IndexMedicalСard - 1)
        //            {
        //                SelectedMedicalСard = AllMedicalСard[IndexMedicalСard - 1];
        //                IndexMedicalСard--;
        //            }
        //        });
        //    }
        //}
        #endregion
    }
}
