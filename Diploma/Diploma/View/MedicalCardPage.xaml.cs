using Diploma.Model;
using Diploma.ViewModel;
using System.Windows.Controls;

namespace Diploma.View
{
    /// <summary>
    /// Логика взаимодействия для MedicalCardPage.xaml
    /// </summary>
    public partial class MedicalCardPage : Page
    {
        public MedicalCardPage(Patient selectedPatient)
        {
            InitializeComponent();
            DataContext = new DataMedicalCardVM(selectedPatient);
        }
    }
}
