
using System;
using System.Collections.Generic;

namespace CleanCode.LongParameterList
{
    public class DateRange
    {
        private DateTime _dateFrom;
        private DateTime _dateTo;
        public DateRange(DateTime dateFrom, DateTime dateTo)
        {
            _dateFrom = dateFrom;
            _dateTo = dateTo;
        }

        public DateTime DateFrom 
        {
             get{ return _dateFrom;}
        } 
        public DateTime DateTo
        {
             get{ return _dateTo;}
        } 
        
    }
    public class LongParameterList
    {
        public IEnumerable<Reservation> GetReservations(
           DateRange dateRage,
           User user, int locationId,
           LocationType locationType, int? customerId = null)
        {
            if (dateRage.DateFrom >= DateTime.Now)
                throw new ArgumentNullException("dateFrom");
            if (dateRage.DateTo <= DateTime.Now)
                throw new ArgumentNullException("dateTo");

            throw new NotImplementedException();
        }

    }

    internal class ReservationDefinition
    {
    }

    public class LocationType
    {
    }

    public class User
    {
        public object Id { get; set; }
    }

    public class Reservation
    {
    }
}
