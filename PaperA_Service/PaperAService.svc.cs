using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PaperA_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PaperAService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PaperAService.svc or PaperAService.svc.cs at the Solution Explorer and start debugging.
    public class PaperAService : IPaperAService
    {
        PaperAClassesDataContext dbclasses = new PaperAClassesDataContext();
        public string Book_Reservation(Reservation reservation)
        {
            var res = (from r in dbclasses.Reservations where 
                       r.Email.Equals(reservation.Email) select r).FirstOrDefault();

            if (res != null)
            {
                return "exists!";
            }
            else
            {
                dbclasses.Reservations.InsertOnSubmit(reservation);
                try
                {
                    dbclasses.SubmitChanges();
                    return "booked!";
                }
                catch(Exception ex)
                {
                    ex.GetBaseException();
                    return "failed!";
                }
            }
        }

        public MenuItem GetMenuItem(int id)
        {
            var item = (from i in dbclasses.MenuItems where i.Id.Equals(id) select i).FirstOrDefault();

            if(item!=null)
            {
                MenuItem menu_item = new MenuItem
                {
                    Name = item.Name,
                    Description = item.Description,
                    Image = item.Image,
                    Price = item.Price
                };
                return menu_item;
            }
            else { return null; }
        }

        public List<MenuItem> GetMenuItems()
        {
            var items = (from mi in dbclasses.MenuItems
                         where mi.Active.Equals(1)
                         select mi).DefaultIfEmpty();

            if (items != null)
            {
                List<MenuItem> list = new List<MenuItem>();
                
                foreach(MenuItem mi in items)
                {
                    MenuItem item = new MenuItem
                    {
                        Id = mi.Id,
                        Name = mi.Name,
                        Price = mi.Price,
                        Image = mi.Image,
                        Category = mi.Category
                    };

                    list.Add(item);
                }

                return list;
            }
            else { return null; }
        }

        public Reservation GetReservation(string email)
        {
            var resv = (from r in dbclasses.Reservations
                        where r.Email.Equals(email)
                        select r).FirstOrDefault();

            if (resv != null)
            {
                Reservation reservation = new Reservation
                {
                    Name = resv.Name,
                    LName = resv.LName,
                    Email = resv.Email,
                    Persons = resv.Persons,
                    Phone = resv.Phone,
                    Date = resv.Date,
                    Time = resv.Time,
                    Note = resv.Note
                };

                return reservation;
            }
            else { return null; }
        }

        public string Update_Reservation(Reservation reservation)
        {
            var _reservation = (from res in dbclasses.Reservations where 
                                res.Email.Equals(reservation.Email) select res).FirstOrDefault();

            if (_reservation != null)
            {
                _reservation.Name = reservation.Name;
                _reservation.LName = reservation.LName;
                _reservation.Email = reservation.Email;
                _reservation.Persons = reservation.Persons;
                _reservation.Phone = reservation.Phone;
                _reservation.Time = reservation.Time;
                _reservation.Note = reservation.Note;

                try
                {
                    dbclasses.SubmitChanges();
                    return "updated!";
                }
                catch(Exception ex) 
                { 
                    ex.GetBaseException();
                    return "failed!";
                }
                
            }
            else
            {
                return "UNF!";
            }
        }
    }
}
