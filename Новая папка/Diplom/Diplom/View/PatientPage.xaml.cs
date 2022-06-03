using Diplom.ViewModel;
using System.Windows.Controls;

namespace Diplom.View
{
    /// <summary>
    /// Логика взаимодействия для PatientPage.xaml
    /// </summary>
    public partial class PatientPage : Page
    {
        public static ListView PatientList;
        public PatientPage()
        {
            InitializeComponent();
            DataContext = new DataPatientVM();
            PatientList = PatientListBlock;
        }
    }
}
