using Diploma.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.ViewModel
{
    public class DataEditTicketVM : ViewModelBase
    {
        public static Ticket SelectedTicket { get; set; }
        public DataEditTicketVM(Ticket selectedTicket)
        {
            SelectedTicket = selectedTicket;
        }
    }
}
