using Diplom.Command;
using Diplom.Model;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Diplom.ViewModel
{
    public class DataEditDoctorVM : ViewModelBase
    {
        private Doctor _selectedDoctor;
        private string _surname;
        private string _name;
        private string _lastname;
        private Speciality _speciality;
        private Cabinet _cabinet;
        private int _specialityIndex;
        private int _cabinetIndex;
        private DateTime _dateOfEmployment;
        private int _workWithHour;
        private int _workWithMinute;
        private int _workUntilHour;
        private int _workUntilMinute;
        private List<Speciality> _specialities;
        private List<Cabinet> _cabinets;

        public DataEditDoctorVM(Doctor selectedDoctor)
        {
            SelectedDoctor = selectedDoctor;
            _surname = SelectedDoctor.Surname;
            _name = SelectedDoctor.Name;
            _lastname = SelectedDoctor.Lastname;
            _speciality = SelectedDoctor.Speciality;
            _cabinet = SelectedDoctor.Cabinet;
            _dateOfEmployment = SelectedDoctor.DateOfEmployment;
            _workWithHour = SelectedDoctor.WorkWith.Hour;
            _workWithMinute = SelectedDoctor.WorkWith.Minute;
            _workUntilHour = SelectedDoctor.WorkUntil.Hour;
            _workUntilMinute = SelectedDoctor.WorkUntil.Minute;
            AllCabinet = DataWorker.GetAllCabinet();
            AllSpeciality = DataWorker.GetAllSpeciality();
        }

        #region[Поля]
        public Doctor SelectedDoctor
        {
            get => _selectedDoctor;
            set
            {
                _selectedDoctor = value;
                NotifyPropertyChanged(nameof(SelectedDoctor));
            }
        }

        public string Surname
        {
            get => _surname;
            set
            {
                _surname = value;
                NotifyPropertyChanged(nameof(Surname));
            }
        }
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                NotifyPropertyChanged(nameof(Name));
            }
        }
        public string Lastname
        {
            get => _lastname;
            set
            {
                _lastname = value;
                NotifyPropertyChanged(nameof(Lastname));
            }
        }
        public Speciality Speciality
        {
            get => _speciality;
            set
            {
                _speciality = value;
                NotifyPropertyChanged(nameof(Speciality));
            }
        }
        public int CabinetIndex
        {
            get => _cabinetIndex;
            set
            {
                _cabinetIndex = value;
                NotifyPropertyChanged(nameof(CabinetIndex));
            }
        }
        public int SpecialityIndex
        {
            get => _specialityIndex;
            set
            {
                _specialityIndex = value;
                NotifyPropertyChanged(nameof(SpecialityIndex));
            }
        }
        public Cabinet Cabinet
        {
            get => _cabinet;
            set
            {
                _cabinet = value;
                NotifyPropertyChanged(nameof(Cabinet));
            }
        }
        public DateTime DateOfEmployment
        {
            get => _dateOfEmployment;
            set
            {
                _dateOfEmployment = value;
                NotifyPropertyChanged(nameof(DateOfEmployment));
            }
        }
        public int WorkWithHour
        {
            get => _workWithHour;
            set
            {
                _workWithHour = value;
                NotifyPropertyChanged(nameof(WorkWithHour));
            }
        }

        public int WorkWithMinute
        {
            get => _workWithMinute;
            set
            {
                _workWithMinute = value;
                NotifyPropertyChanged(nameof(WorkWithMinute));
            }
        }

        public int WorkUntilHour
        {
            get => _workUntilHour;
            set
            {
                _workUntilHour = value;
                NotifyPropertyChanged(nameof(WorkUntilHour));
            }
        }

        public int WorkUntilMinute
        {
            get => _workUntilMinute;
            set
            {
                _workUntilMinute = value;
                NotifyPropertyChanged(nameof(WorkUntilMinute));
            }
        }

        public List<Cabinet> AllCabinet
        {
            get => _cabinets;
            set
            {
                _cabinets = value;
                NotifyPropertyChanged(nameof(AllCabinet));
            }
        }

        public List<Speciality> AllSpeciality
        {
            get => _specialities;
            set
            {
                _specialities = value;
                NotifyPropertyChanged(nameof(AllSpeciality));
            }
        }
        #endregion

        public RelayCommand EditDoctor
        {
            get
            {
                return null ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    if (Surname == null || Surname.Replace(" ", "").Length == 0 ||
                        Name == null || Name.Replace(" ", "").Length == 0 ||
                        Lastname == null || Lastname.Replace(" ", "").Length == 0 ||
                        Speciality == null ||
                        Cabinet == null ||
                        DateOfEmployment > DateTime.Now ||
                        WorkWithHour >= 24 ||
                        WorkWithHour < 0 ||
                        WorkWithMinute >= 60 ||
                        WorkWithMinute < 0 ||
                        WorkUntilHour >= 24 ||
                        WorkUntilHour < 0 ||
                        WorkUntilMinute >= 60 ||
                        WorkUntilMinute < 0)
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

                        if (Speciality == null)
                            ShowMessageToUser("Не выбрана специальность");

                        if (Cabinet == null)
                            ShowMessageToUser("Не выбран кабинет");

                        if (DateOfEmployment > DateTime.Now)
                            ShowMessageToUser("Неправильная дата");

                        if (WorkWithHour >= 24)
                            SetRedBlockControll(window, "WorkWithHourBlock");
                        else
                            SetBlackBlockControll(window, "WorkWithHourBlock");

                        if (WorkWithMinute >= 60)
                            SetRedBlockControll(window, "WorkWithMinuteBlock");
                        else
                            SetBlackBlockControll(window, "WorkWithMinuteBlock");

                        if (WorkUntilHour >= 24)
                            SetRedBlockControll(window, "WorkUntilHourBlock");
                        else
                            SetBlackBlockControll(window, "WorkUntilHourBlock");

                        if (WorkUntilMinute >= 60)
                            SetRedBlockControll(window, "WorkUntilMinuteBlock");
                        else
                            SetBlackBlockControll(window, "WorkUntilMinuteBlock");
                    }
                    else
                    {
                        var workWith = new DateTime(1, 1, 1, WorkWithHour, WorkWithMinute, 00);
                        var workUntil = new DateTime(1, 1, 1, WorkUntilHour, WorkUntilMinute, 00);

                        if (workWith >= workUntil)
                        {
                            ShowMessageToUser("Не правильное время работы");
                            SetRedBlockControll(window, "WorkWithHourBlock");
                            SetRedBlockControll(window, "WorkWithMinuteBlock");
                            SetRedBlockControll(window, "WorkUntilHourBlock");
                            SetRedBlockControll(window, "WorkUntilMinuteBlock");
                        }
                        else
                        {
                            SetBlackBlockControll(window, "SurnameBlock");
                            SetBlackBlockControll(window, "NameBlock");
                            SetBlackBlockControll(window, "LastnameBlock");
                            SetBlackBlockControll(window, "WorkWithHourBlock");
                            SetBlackBlockControll(window, "WorkWithMinuteBlock");
                            SetBlackBlockControll(window, "WorkUntilHourBlock");
                            SetBlackBlockControll(window, "WorkUntilMinuteBlock");
                            var result = DataWorker.EditDoctor(SelectedDoctor, Surname, Name, Lastname,
                                    Speciality, Cabinet, DateOfEmployment, workWith, workUntil);
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
            Speciality = null;
            Cabinet = null;
            DateOfEmployment = DateTime.Now;
            WorkWithHour = 0;
            WorkWithMinute = 0;
            WorkUntilHour = 0;
            WorkUntilMinute = 0;
            SelectedDoctor = null;
        }
    }
}
