using Diplom.ViewModel;
using System.Windows;

namespace Diplom.View
{
    /// <summary>
    /// Логика взаимодействия для AddNewPatientWindow.xaml
    /// </summary>
    public partial class AddNewPatientWindow : Window
    {
        public AddNewPatientWindow()
        {
            InitializeComponent();
            DataContext = new DataAddNewPatientVM();
        }
    }
}
