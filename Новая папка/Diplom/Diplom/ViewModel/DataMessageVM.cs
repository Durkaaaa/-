using Diplom.Command;
using System.Windows;

namespace Diplom.ViewModel
{
    public class DataMessageVM : ViewModelBase
    {
        //Закрытие окна
        public RelayCommand CloseWindow
        {
            get
            {
                return null ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    window.Close();
                });
            }
        }
    }
}
