using Diplom.ViewModel;
using System.Windows.Controls;

namespace Diplom.View
{
    /// <summary>
    /// Логика взаимодействия для DoctorPage.xaml
    /// </summary>
    public partial class DoctorPage : Page
    {
        public static ListView DoctorList;
        public DoctorPage()
        {
            InitializeComponent();
            DataContext = new DataDoctorVM();
            DoctorList = DoctorListBlock;
        }
    }
}
