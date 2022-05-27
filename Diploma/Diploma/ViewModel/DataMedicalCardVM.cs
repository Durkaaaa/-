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
        public static List<Medicine> AllMedicine { get; set; }
        public static MedicalCard SelectedMedicalCard { get; set; }
        public static MedicalRecord SelectedMedicalRecord { get; set; }
        public static List<MedicalRecord> AllMedicalRecord { get; set; }

        public static string Diagnosis { get; set; }
        public static string StartOfTreatment { get; set; }
        public static string EndOfTreatment { get; set; }
        public static int IndexMedicalRecord { get; set; }
        #endregion

        #region[Свойства для пациента]
        public static Patient SelectedPatient { get; set; }
        public static string PatientSurname { get; set; }
        public static string PatientName { get; set; }
        public static string PatientLastname { get; set; }
        public static string PatientDateOfBirth { get; set; }
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
            PatientSurname = null;
            PatientName = null;
            PatientLastname = null;
            PatientDateOfBirth = null;
            PatientGender = null;
            DoctorSurname = null;
            DoctorName = null;
            DoctorLastname = null;
            DoctorSpeciality = null;
            StartOfTreatment = null;
            EndOfTreatment = null;
            Diagnosis = null;
            bool medicalCard = DataWorker.BoolGetMedicalСardByPatientId(SelectedPatient);
            if (!medicalCard)
            {
                SelectedMedicalCard = DataWorker.AddNewMedicalСard(SelectedPatient);
            }
            else
            {
                SelectedMedicalCard = DataWorker.GetMedicalСardByPatientId(SelectedPatient);

                bool medicalRecord = DataWorker.BoolGetMedicalRecordByMedicalСardId(SelectedMedicalCard);
                if (medicalRecord)
                {
                    AllMedicalRecord = DataWorker.GetMedicalRecordByMedicalСardId(SelectedMedicalCard);
                    SelectedMedicalRecord = DataWorker.GetMedicalRecordsByMedicalCardId(SelectedMedicalCard)[IndexMedicalRecord];
                    bool boolMedicine = DataWorker.BoolGetAllMedicineByMedicanRecordId(SelectedMedicalRecord);
                    if (boolMedicine)
                    {
                        AllMedicine = DataWorker.GetAllMedicinesByMedicalRecordId(SelectedMedicalRecord);
                    }
                    MedicalRecordNumber();
                }
            }
        }

        #region[Лекарства]
        public RelayCommand AddNewMedicine
        {
            get
            {
                return null ?? new RelayCommand(obj =>
                {
                    DataWorker.AddNewMedicine(SelectedMedicalRecord, Medicine);
                    UpdateAllMedicalRecord();
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
                        UpdateAllMedicalRecord();
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
                        UpdateAllMedicalRecord();
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
                    MedicalRecordNumber();
                    UpdateAllMedicalRecord();
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
                        IndexMedicalRecord += 1;
                        MedicalRecordNumber();
                        UpdateAllMedicalRecord();
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
                        UpdateAllMedicalRecord();
                    }
                });
            }
        }
        #endregion

        private void MedicalRecordNumber()
        {
            AllMedicalRecord = DataWorker.GetMedicalRecordByMedicalСardId(SelectedMedicalCard);
            SelectedMedicalRecord = DataWorker.GetMedicalRecordsByMedicalCardId(SelectedMedicalCard)[IndexMedicalRecord];
            bool boolMedicine = DataWorker.BoolGetAllMedicineByMedicanRecordId(SelectedMedicalRecord);
            if (boolMedicine)
            {
                AllMedicine = DataWorker.GetAllMedicinesByMedicalRecordId(SelectedMedicalRecord);
            }

            if (SelectedMedicalRecord != null)
            {
                var patient = DataWorker.GetPatientByMedicalRecord(SelectedMedicalRecord);
                PatientSurname = patient.Surname;
                PatientName = patient.Name;
                PatientLastname = patient.Lastname;
                PatientDateOfBirth = patient.DateOfBirth.ToShortDateString().ToString();
                PatientGender = patient.PatientGender.Titl;

                var doctor = DataWorker.GetDoctorByMedicalRecord(SelectedMedicalRecord);
                DoctorSurname = doctor.Surname;
                DoctorName = doctor.Name;
                DoctorLastname = doctor.Lastname;
                DoctorSpeciality = doctor.DoctorSpeciality.Titl;

                Diagnosis = SelectedMedicalRecord.Diagnosis;
                StartOfTreatment = SelectedMedicalRecord.StartOfTreatment.ToShortDateString().ToString();
                Diagnosis = SelectedMedicalRecord.Diagnosis;
                EndOfTreatment = SelectedMedicalRecord.EndOfTreatment.ToString();
                if (EndOfTreatment != "")
                {
                    EndOfTreatment = EndOfTreatment.Substring(0, 10);
                }
            }
        }

        private void UpdateAllMedicalRecord()
        {
            MedicalCardPage.PatientSurnameCard.Text = PatientSurname;
            MedicalCardPage.PatientNameCard.Text = PatientName;
            MedicalCardPage.PatientLastnameCard.Text = PatientLastname;
            MedicalCardPage.PatientDateOfBirthCard.Text = PatientDateOfBirth;
            MedicalCardPage.PatientGenderCard.Text = PatientGender;
            MedicalCardPage.DoctorSurnameCard.Text = DoctorSurname;
            MedicalCardPage.DoctorNameCard.Text = DoctorName;
            MedicalCardPage.DoctorLastnameCard.Text = DoctorLastname;
            MedicalCardPage.DoctorSpecialityCard.Text = DoctorSpeciality;
            MedicalCardPage.StartOfTreatmentCard.Text = StartOfTreatment;
            MedicalCardPage.EndOfTreatmentCard.Text = EndOfTreatment;
            MedicalCardPage.DiagnosisCard.Text = Diagnosis;
            MedicalCardPage.MedicineList.ItemsSource = AllMedicine;
        }
    }
}
