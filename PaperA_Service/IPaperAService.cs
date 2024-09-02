using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PaperA_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPaperAService" in both code and config file together.
    [ServiceContract]
    public interface IPaperAService
    {
        [OperationContract]
        List<MenuItem> GetMenuItems();

        [OperationContract]
        MenuItem GetMenuItem(int id);

        [OperationContract]
        string Book_Reservation(Reservation reservation);

        [OperationContract]
        Reservation GetReservation(string email);

        [OperationContract]
        string Update_Reservation(Reservation reservation);
    }
}
