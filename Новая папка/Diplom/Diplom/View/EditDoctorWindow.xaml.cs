using Diplom.Model;
using Diplom.ViewModel;
using System.Windows;

namespace Diplom.View
{
    /// <summary>
    /// Логика взаимодействия для EditDoctorWindow.xaml
    /// </summary>
    public partial class EditDoctorWindow : Window
    {
        public EditDoctorWindow(Doctor selectedDoctor)
        {
            InitializeComponent();
            DataContext = new DataEditDoctorVM(selectedDoctor);
        }
    }
}
