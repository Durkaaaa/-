using Diplom.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.ViewModel
{
    public class DataAddNewDoctorVM : ViewModelBase
    {
        private string _surname;
        private string _name;
        private string _lastname;
        private int _specialityId;
        private int _cabinetId;
        private DateTime _dateOfEmployment;
        private DateTime _workWith;
        private DateTime _workUntil;
        private RelayCommand _addNewDoctor;

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
        public int SpecialityId
        {
            get => _specialityId;
            set
            {
                _specialityId = value;
                NotifyPropertyChanged(nameof(SpecialityId));
            }
        }
        public int CabinetId
        {
            get => _cabinetId;
            set
            {
                _cabinetId = value;
                NotifyPropertyChanged(nameof(CabinetId));
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
        public DateTime WorkWith
        {
            get => _workWith;
            set
            {
                _workWith = value;
                NotifyPropertyChanged(nameof(WorkWith));
            }
        }
        public DateTime WorkUntil
        {
            get => _workUntil;
            set
            {
                _workUntil = value;
                NotifyPropertyChanged(nameof(WorkUntil));
            }
        }
        #endregion

        public RelayCommand AddNewDactor
        {
            get
            {
                return _addNewDoctor ?? new RelayCommand(obj =>
                {
                    var result = DataWorker.AddNewDoctor();

                });
            }
        }
    }
}
