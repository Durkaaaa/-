﻿using Diploma.Model;
using Diploma.ViewModel;
using System.Windows;

namespace Diploma.View
{
    /// <summary>
    /// Логика взаимодействия для EditTicketWindow.xaml
    /// </summary>
    public partial class EditTicketWindow : Window
    {
        public EditTicketWindow(Ticket selectedTicket)
        {
            InitializeComponent();
            DataContext = new DataEditTicketVM(selectedTicket);
        }
    }
}
