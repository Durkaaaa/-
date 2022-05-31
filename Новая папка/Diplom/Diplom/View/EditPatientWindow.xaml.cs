using Diplom.Model;
using Diplom.ViewModel;
using System.Windows;

namespace Diplom.View
{
    /// <summary>
    /// Логика взаимодействия для EditPatientWindow.xaml
    /// </summary>
    public partial class EditPatientWindow : Window
    {
        public EditPatientWindow(Patient selectedPatient)
        {
            InitializeComponent();
            DataContext = new DataEditPatientVM(selectedPatient);
        }
    }
}
