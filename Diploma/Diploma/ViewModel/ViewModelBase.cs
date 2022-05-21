﻿using Diploma.Model;
using Diploma.View;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Diploma.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        private List<Doctor> _listDoctor;
        public List<Doctor> ListDoctor
        {
            get => _listDoctor;
            set
            {
                _listDoctor = value;
                NotifyPropertyChanged(nameof(ListDoctor));
            }
        }

        private List<Patient> _listPatient;
        public List<Patient> ListPatient
        {
            get => _listPatient;
            set
            {
                _listPatient = value;
                NotifyPropertyChanged(nameof(ListPatient));
            }
        }



        #region [Изменение цвета TextBox]
        //Изменение цвета TextBox на красный
        public void SetRedBlockControll(Window window, string blockName)
        {
            Control block = window.FindName(blockName) as Control;
            block.BorderBrush = Brushes.Red;
        }

        //Изменение цвета TextBox на черный
        public void SetBlackBlockControll(Window window, string blockName)
        {
            Control block = window.FindName(blockName) as Control;
            block.BorderBrush = Brushes.Black;
        }
        #endregion

        //Окно с сообщением для пользователя
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
