using Diplom.Model.Data;
using Diplom.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace Diplom.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Frame FramePage;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new DataMainVM();
            FramePage = FrameBlock;
        }
    }
}
