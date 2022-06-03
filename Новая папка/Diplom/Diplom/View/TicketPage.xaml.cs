using Diplom.ViewModel;
using System.Windows.Controls;

namespace Diplom.View
{
    /// <summary>
    /// Логика взаимодействия для TicketPage.xaml
    /// </summary>
    public partial class TicketPage : Page
    {
        public TicketPage()
        {
            InitializeComponent();
            DataContext = new DataTicketVM();
        }
    }
}
