using Diplom.Command;
using Diplom.Model;
using Diplom.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.ViewModel
{
    public class DataTicketVM : ViewModelBase
    {
        public static Ticket SelectedTicket { get; set; }

        private List<Ticket> _allTicket = DataWorker.GetAllTicket();
        public List<Ticket> AllTicket
        {
            get { return _allTicket; }
            set
            {
                _allTicket = value;
                NotifyPropertyChanged("AllTicket");
            }
        }

        public RelayCommand AddNewTicket
        {
            get
            {
                return null ?? new RelayCommand(obj =>
                {
                    AddNewTicketOneWindow addNewTicketOneWindow = new AddNewTicketOneWindow();
                    SetCenterPositionAndOpen(addNewTicketOneWindow);
                    //UpdateAllTicketPage();
                });
            }
        }

        //public RelayCommand EditTicket
        //{
        //    get
        //    {
        //        return null ?? new RelayCommand(obj =>
        //        {
        //            if (SelectedTicket != null)
        //            {
        //                EditTicketWindow editTicketWindow = new EditTicketWindow(SelectedTicket);
        //                SetCenterPositionAndOpen(editTicketWindow);
        //                SelectedTicket = null;
        //                UpdateAllTicketPage();
        //            }
        //        });
        //    }
        //}

        //public RelayCommand DeleteTicket
        //{
        //    get
        //    {
        //        return null ?? new RelayCommand(obj =>
        //        {
        //            if (SelectedTicket != null)
        //            {
        //                var result = DataWorker.DeleteTicket(SelectedTicket);
        //                ShowMessageToUser(result);
        //                SelectedTicket = null;
        //                UpdateAllTicketPage();
        //            }
        //        });
        //    }
        //}
    }
}
