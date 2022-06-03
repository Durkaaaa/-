using Diplom.ViewModel;
using System.Windows;

namespace Diplom.View
{
    /// <summary>
    /// Логика взаимодействия для AddNewTicketOneWindow.xaml
    /// </summary>
    public partial class AddNewTicketOneWindow : Window
    {
        public AddNewTicketOneWindow()
        {
            InitializeComponent();
            DataContext = new DataAddNewTicketOneVM();
        }
    }
}
