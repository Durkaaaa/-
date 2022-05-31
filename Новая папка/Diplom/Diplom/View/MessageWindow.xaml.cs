using Diplom.ViewModel;
using System.Windows;

namespace Diplom.View
{
    /// <summary>
    /// Логика взаимодействия для MessageWindow.xaml
    /// </summary>
    public partial class MessageWindow : Window
    {
        public MessageWindow(string text)
        {
            InitializeComponent();
            DataContext = new DataMessageVM();
            MessageText.Text = text;
        }
    }
}
