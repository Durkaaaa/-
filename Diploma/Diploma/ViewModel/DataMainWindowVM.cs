using System.Windows.Controls;

namespace Diploma.ViewModel
{
    public class DataMainWindowVM : ViewModelBase
    {
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
