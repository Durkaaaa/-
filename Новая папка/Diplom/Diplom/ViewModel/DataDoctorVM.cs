using System;
using Diplom.Model;
using Diplom.Command;
using Diplom.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.ViewModel
{
    public class DataDoctorVM : ViewModelBase
    {
        public DataDoctorVM()
        {
            AllDoctor = DataWorker.GetAllDoctor();
        }

        private List<Doctor> _allDoctor;
        public List<Doctor> AllDoctor
        {
            get => _allDoctor;
            set 
            { 
                _allDoctor = value;
                NotifyPropertyChanged(nameof(AllDoctor));
            }
        }
    }
}
