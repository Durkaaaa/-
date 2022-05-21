using Diploma.Command;
using Diploma.Model;
using System.Windows;
using System.Windows.Controls;

namespace Diploma.ViewModel
{
    public class DataMainWindowVM : ViewModelBase
    {
        

        public DataMainWindowVM() { }

        

        private Page _page;
        public Page Page
        {
            get => _page;
            set
            {
                _page = value;
                NotifyPropertyChanged(nameof(Page));
            }
        }

    }
}
