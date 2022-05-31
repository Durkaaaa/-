using Diplom.ViewModel;
using System.Windows;

namespace Diplom.View
{
    /// <summary>
    /// Логика взаимодействия для AddNewDoctorWindow.xaml
    /// </summary>
    public partial class AddNewDoctorWindow : Window
    {
        public AddNewDoctorWindow()
        {
            InitializeComponent();
            DataContext = new DataAddNewDoctorVM();
        }
    }
}
