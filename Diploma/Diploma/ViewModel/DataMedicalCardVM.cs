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
        #region[Свойства для мед карты]
        public static MedicalCard SelectedMedicalCard { get; set; }
        public static MedicalRecord SelectedMedicalRecord { get; set; }
        public static List<MedicalRecord> AllMedicalRecord { get; set; }

        public static DateTime StartOfTreatment { get; set; }
        public static DateTime? EndOfTreatment { get; set; }
        public static int IndexMedicalRecord { get; set; }
        #endregion

        #region[Свойства для пациента]
        public static Patient SelectedPatient { get; set; }
        public static string PatientSurname { get; set; }
        public static string PatientName { get; set; }
        public static string PatientLastname { get; set; }
        public static DateTime PatientDateOfBirth { get; set; }
        public static string PatientGender { get; set; }
        #endregion

        #region[Свойства для врача]
        public static string DoctorSurname { get; set; }
        public static string DoctorName { get; set; }
        public static string DoctorLastname { get; set; }
        public static string DoctorSpeciality { get; set; }
        #endregion

        #region[Свойства для лекарств]        
        public static Medicine SelectedMedicine { get; set; }
        public static string Medicine { get; set; }
        #endregion

        public DataMedicalCardVM(Patient selectedPatient)
        {
            SelectedPatient = selectedPatient;
            IndexMedicalRecord = 0;
            bool medicalCard = DataWorker.BoolGetMedicalСardByPatientId(SelectedPatient);
            if (!medicalCard)
            {
                SelectedMedicalCard = DataWorker.AddNewMedicalСard(SelectedPatient);
                BlankPage blankPage = new BlankPage();
                MainWindow.FramePage.Content = blankPage;
            }
            else
            {
                SelectedMedicalCard = DataWorker.GetMedicalСardByPatientId(SelectedPatient);

                bool medicalRecord = DataWorker.BoolGetMedicalRecordByMedicalСardId(SelectedMedicalCard);
                if (medicalRecord)
                {
                    MedicalRecordNumber();
                }
                else
                {
                    BlankPage blankPage = new BlankPage();
                    MainWindow.FramePage.Content = blankPage;
                }
            }
        }

        #region[Лекарства]
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
                    DataWorker.AddNewMedicine(SelectedMedicalRecord, Medicine);
                    UpdateAllMedicine();
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
                        DataWorker.EditMedicine(SelectedMedicine, SelectedMedicalRecord, Medicine);
                        UpdateAllMedicine();
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
                    if (SelectedMedicine != null)
                    {
                        DataWorker.DeleteMedicine(SelectedMedicine);
                        UpdateAllMedicine();
                        SelectedMedicine = null;
                    }
                });
            }
        }
        #endregion

        #region[Страницы в мед карте]
        public RelayCommand AddNewMedicalRecord
        {
            get
            {
                return null ?? new RelayCommand(obj =>
                {
                    AddNewMedicalRecordWindow addNewMedicalRecordWindow = new AddNewMedicalRecordWindow(SelectedMedicalCard);
                    SetCenterPositionAndOpen(addNewMedicalRecordWindow);
                    IndexMedicalRecord++;
                    MedicalRecordNumber();
                });
            }
        }

        public RelayCommand EditMedicalRecord
        {
            get
            {
                return null ?? new RelayCommand(obj =>
                {
                    if (SelectedMedicalRecord != null)
                    {
                        EditMedicalRecordWindow editMedicalRecordWindow = new EditMedicalRecordWindow(SelectedMedicalCard, SelectedMedicalRecord);
                        SetCenterPositionAndOpen(editMedicalRecordWindow);
                        MedicalRecordNumber();
                        SelectedMedicalRecord = null;
                    }
                });
            }
        }

        public RelayCommand DeleteMedicalRecord
        {
            get
            {
                return null ?? new RelayCommand(obj =>
                {
                    if (SelectedMedicalRecord != null)
                    {
                        DataWorker.DeleteAllMedicineByMedicalRecordId(SelectedMedicalRecord);
                        var result = DataWorker.DeleteMedicalRecord(SelectedMedicalCard, SelectedMedicalRecord);
                        ShowMessageToUser(result);
                        SelectedMedicalRecord = null;
                        AllMedicalRecord = DataWorker.GetMedicalRecordByMedicalСardId(SelectedMedicalCard);
                        if (AllMedicalRecord != null && 0 <= IndexMedicalRecord - 1)
                        {
                            IndexMedicalRecord--;
                            MedicalRecordNumber();
                        }
                        else
                        {
                            BlankPage blankPage = new BlankPage();
                            Page = blankPage;
                        }
                    }
                });
            }
        }
        #endregion

        #region[Листание страниц]
        public RelayCommand OpenNextMedicalCard
        {
            get
            {
                return null ?? new RelayCommand(obj =>
                {
                    AllMedicalRecord = DataWorker.GetMedicalRecordByMedicalСardId(SelectedMedicalCard);
                    int count = AllMedicalRecord.Count();
                    if (AllMedicalRecord != null && count > IndexMedicalRecord + 1)
                    {
                        IndexMedicalRecord++;
                        MedicalRecordNumber();
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
                    AllMedicalRecord = DataWorker.GetMedicalRecordByMedicalСardId(SelectedMedicalCard);
                    if (AllMedicalRecord != null && 0 <= IndexMedicalRecord - 1)
                    {
                        IndexMedicalRecord--;
                        MedicalRecordNumber();
                    }
                });
            }
        }
        #endregion

        private void MedicalRecordNumber()
        {
            AllMedicalRecord = DataWorker.GetMedicalRecordByMedicalСardId(SelectedMedicalCard);
            SelectedMedicalRecord = DataWorker.GetMedicalRecordsByMedicalCardId(SelectedMedicalCard)[IndexMedicalRecord];

            PatientSurname = SelectedMedicalRecord.MedicalСard.Patient.Surname;
            PatientName = SelectedMedicalRecord.MedicalСard.Patient.Name;
            PatientLastname = SelectedMedicalRecord.MedicalСard.Patient.Lastname;
            PatientDateOfBirth = SelectedMedicalRecord.MedicalСard.Patient.DateOfBirth;
            PatientGender = SelectedMedicalRecord.MedicalСard.Patient.Gender.Titl;

            DoctorSurname = SelectedMedicalRecord.Doctor.Surname;
            DoctorName = SelectedMedicalRecord.Doctor.Name;
            DoctorLastname = SelectedMedicalRecord.Doctor.Lastname;
            DoctorSpeciality = SelectedMedicalRecord.Doctor.Speciality.Titl;

            StartOfTreatment = SelectedMedicalRecord.StartOfTreatment;
            EndOfTreatment = SelectedMedicalRecord.EndOfTreatment;
        }

        private void UpdateAllMedicine()
        {
            AllMedicine = DataWorker.GetAllMedicinesByMedicalRecordId(SelectedMedicalRecord);
            MedicalCardPage.MedicineList.ItemsSource = null;
            MedicalCardPage.MedicineList.Items.Clear();
            MedicalCardPage.MedicineList.ItemsSource = AllMedicine;
            MedicalCardPage.MedicineList.Items.Refresh();
        }
    }
}
