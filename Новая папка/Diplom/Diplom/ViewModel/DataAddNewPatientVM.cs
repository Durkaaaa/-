using Diplom.Command;
using Diplom.Model;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Diplom.ViewModel
{
    public class DataAddNewPatientVM : ViewModelBase
    {
        private string _surname;
        private string _name;
        private string _lastname;
        private Gender _gender;
        private DateTime _dateOfBirth;
        private string _policy;
        private string _snils;
        private string _passportSeries;
        private string _passportNumber;
        private string _address;
        private List<Gender> _genders;

        public DataAddNewPatientVM()
        {
            AllGender = DataWorker.GetAllGender();
        }

        #region[Поля]
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

        public Gender Gender
        {
            get => _gender;
            set
            {
                _gender = value;
                NotifyPropertyChanged(nameof(Gender));
            }
        }

        public DateTime DateOfBirth
        {
            get => _dateOfBirth;
            set
            {
                _dateOfBirth = value;
                NotifyPropertyChanged(nameof(DateOfBirth));
            }
        }

        public string Policy
        {
            get => _policy;
            set
            {
                _policy = value;
                NotifyPropertyChanged(nameof(Policy));
            }
        }

        public string Snils
        {
            get => _snils;
            set
            {
                _snils = value;
                NotifyPropertyChanged(nameof(Snils));
            }
        }

        public string PassportSeries
        {
            get => _passportSeries;
            set
            {
                _passportSeries = value;
                NotifyPropertyChanged(nameof(PassportSeries));
            }
        }

        public string PassportNumber
        {
            get => _passportNumber;
            set
            {
                _passportNumber = value;
                NotifyPropertyChanged(nameof(PassportNumber));
            }
        }

        public string Address
        {
            get => _address;
            set
            {
                _address = value;
                NotifyPropertyChanged(nameof(Address));
            }
        }

        public List<Gender> AllGender
        {
            get => _genders;
            set
            {
                _genders = value;
                NotifyPropertyChanged(nameof(AllGender));
            }
        }
        #endregion

        public RelayCommand AddNewPatient
        {
            get
            {
                return null ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    if (Surname == null || Surname.Replace(" ", "").Length == 0 ||
                        Name == null || Name.Replace(" ", "").Length == 0 ||
                        Lastname == null || Lastname.Replace(" ", "").Length == 0 ||
                        Gender == null ||
                        DateOfBirth > DateTime.Now ||
                        Policy == null || Policy.Replace(" ", "").Length == 0 ||
                        Snils == null || Snils.Replace(" ", "").Length == 0 ||
                        PassportSeries == null || PassportSeries.Replace(" ", "").Length == 0 ||
                        PassportNumber == null || PassportNumber.Replace(" ", "").Length == 0 ||
                        Address == null || Address.Replace(" ", "").Length == 0)
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

                        if (Gender == null)
                            ShowMessageToUser("Не выбран пол");

                        if (DateOfBirth > DateTime.Now)
                            ShowMessageToUser("Не правильная дата");

                        if (Policy == null || Policy.Replace(" ", "").Length == 0)
                            SetRedBlockControll(window, "PolicyBlock");
                        else
                            SetBlackBlockControll(window, "PolicyBlock");

                        if (Snils == null || Snils.Replace(" ", "").Length == 0)
                            SetRedBlockControll(window, "SnilsBlock");
                        else
                            SetBlackBlockControll(window, "SnilsBlock");

                        if (PassportSeries == null || PassportSeries.Replace(" ", "").Length == 0)
                            SetRedBlockControll(window, "PassportSeriesBlock");
                        else
                            SetBlackBlockControll(window, "PassportSeriesBlock");

                        if (PassportNumber == null || PassportNumber.Replace(" ", "").Length == 0)
                            SetRedBlockControll(window, "PassportNumberBlock");
                        else
                            SetBlackBlockControll(window, "PassportNumberBlock");

                        if (Address == null || Address.Replace(" ", "").Length == 0)
                            SetRedBlockControll(window, "AddressBlock");
                        else
                            SetBlackBlockControll(window, "AddressBlock");
                    }
                    else
                    {
                        SetBlackBlockControll(window, "SurnameBlock");
                        SetBlackBlockControll(window, "NameBlock");
                        SetBlackBlockControll(window, "LastnameBlock");
                        SetBlackBlockControll(window, "PolicyBlock");
                        SetBlackBlockControll(window, "SnilsBlock");
                        SetBlackBlockControll(window, "PassportSeriesBlock");
                        SetBlackBlockControll(window, "PassportNumberBlock");
                        SetBlackBlockControll(window, "AddressBlock");
                        var result = DataWorker.AddNewPatient(Surname, Name, Lastname, Gender,
                            DateOfBirth, Policy, Snils, PassportSeries, PassportNumber, Address);
                        ShowMessageToUser(result);
                        Zeroing();
                        window.Close();
                    }
                });
            }
        }

        private void Zeroing()
        {
            Surname = null;
            Name = null;
            Lastname = null;
            Gender = null;
            DateOfBirth = DateTime.Now;
            Policy = null;
            Snils = null;
            PassportSeries = null;
            PassportNumber = null;
            Address = null;
        }
    }
}
