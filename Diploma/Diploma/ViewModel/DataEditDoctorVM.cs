using Diploma.Command;
using Diploma.Model;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Diploma.ViewModel
{
    public class DataEditDoctorVM : ViewModelBase
    {
        public static string Surname { get; set; }
        public static string Name { get; set; }
        public static string Lastname { get; set; }
        public static Speciality SelectedSpeciality { get; set; }
        public static int WorkExperience { get; set; }
        public static DateTime WorkWith { get; set; }
        public static DateTime WorkUntil { get; set; }
        public static int IndexSpeciality { get; set; }
        public Doctor SelectedDoctor { get; set; }

        public DataEditDoctorVM(Doctor selectedDoctor)
        {
            SelectedDoctor = selectedDoctor;
            Surname = SelectedDoctor.Surname;
            Name = SelectedDoctor.Name;
            Lastname = SelectedDoctor.Lastname;
            SelectedSpeciality = SelectedDoctor.Speciality;
            WorkExperience = SelectedDoctor.WorkExperience;
            WorkWith = SelectedDoctor.WorkWith;
            WorkUntil = SelectedDoctor.WorkUntil;
            IndexSpeciality = DataWorker.GetIndexSpeciality(SelectedDoctor.SpecialityId);
        }

        private List<Speciality> _allSpeciality = DataWorker.GetAllSpeciality();
        public List<Speciality> AllSpeciality
        {
            get { return _allSpeciality; }
            set
            {
                _allSpeciality = value;
                NotifyPropertyChanged("AllSpeciality");
            }
        }

        public RelayCommand EditDoctor
        {
            get
            {
                return null ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    if (SelectedDoctor != null)
                    {
                        if (Surname == null || Surname.Replace(" ", "").Length == 0 ||
                            Name == null || Name.Replace(" ", "").Length == 0 ||
                            Lastname == null || Lastname.Replace(" ", "").Length == 0 ||
                            SelectedSpeciality == null ||
                            WorkWith >= WorkUntil)
                        {
                            if (Surname == null || Surname.Replace(" ", "").Length == 0)
                                SetRedBlockControll(window, "SurnameBlock");
                            else
                                SetBlackBlockControll(window, "SurnameBlock");

                            if (Name == null || Name.Replace(" ", "").Length == 0)
                                SetRedBlockControll(window, "NameBlock");
                            else
                                SetBlackBlockControll(window, "NameBlock");

                            if (Lastname == null || Lastname.Replace(" ", "").Length == 0)
                                SetRedBlockControll(window, "LastnameBlock");
                            else
                                SetBlackBlockControll(window, "LastnameBlock");

                            if (SelectedSpeciality == null)
                                ShowMessageToUser("Не выбрана специальность");

                            if ((WorkWith.Hour >= WorkUntil.Hour) && (WorkUntil.Minute > WorkUntil.Minute))
                                ShowMessageToUser("Не праильное время");
                        }
                        else
                        {
                            SetBlackBlockControll(window, "SurnameBlock");
                            SetBlackBlockControll(window, "NameBlock");
                            SetBlackBlockControll(window, "LastnameBlock");
                            var result = DataWorker.EditDoctor(SelectedDoctor, Surname, Name, Lastname,
                                SelectedSpeciality, WorkExperience, WorkWith, WorkUntil);
                            ShowMessageToUser(result);
                            Zeroing();
                            window.Close();
                        }
                    }
                });
            }
        }

        private void Zeroing()
        {
            Surname = null;
            Name = null;
            Lastname = null;
            SelectedSpeciality = null;
            WorkExperience = 0;
            WorkWith = DateTime.Now;
            WorkUntil = DateTime.Now;
            SelectedDoctor = null;
            IndexSpeciality = 0;
        }
    }
}
