using Diplom.View;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Diplom.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        #region [Изменение цвета TextBox]
        //Изменение цвета TextBox на красный
        public void SetRedBlockControll(Window window, string blockName)
        {
            Control block = window.FindName(blockName) as Control;
            block.BorderBrush = Brushes.Red;
        }

        //Изменение цвета TextBox на черный
        public void SetBlackBlockControll(Page page, string blockName)
        {
            Control block = page.FindName(blockName) as Control;
            block.BorderBrush = Brushes.Black;
        }

        //Изменение цвета TextBox на красный
        public void SetRedBlockControll(Page page, string blockName)
        {
            Control block = page.FindName(blockName) as Control;
            block.BorderBrush = Brushes.Red;
        }

        //Изменение цвета TextBox на черный
        public void SetBlackBlockControll(Window window, string blockName)
        {
            Control block = window.FindName(blockName) as Control;
            block.BorderBrush = Brushes.Black;
        }
        #endregion

        ////Окно с сообщением для пользователя
        public void ShowMessageToUser(string message)
        {
            MessageWindow messageWindow = new MessageWindow(message);
            SetCenterPositionAndOpen(messageWindow);
        }

        //Положение окна при открытии
        public void SetCenterPositionAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
