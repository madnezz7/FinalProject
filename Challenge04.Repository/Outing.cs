using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Challenge04.Repository;

namespace Challenge04.Repository
{
    public class Outing
    {

        //Property

        public EventType EventType { get; set; }
        public int NumberOfPeople { get; set; }
        public DateOnly Date { get; set; }
        public decimal CostPerPerson { get; set; }
        public decimal CostOfEvent { get; set; }

        //Full Constructor
        public Outing(EventType eventType, int numberOfPeople, DateOnly date, decimal costPerPerson, decimal costOfEvent)
        {
            EventType = eventType;
            NumberOfPeople = numberOfPeople;
            Date = date;
            CostPerPerson = costPerPerson;
            CostOfEvent = costOfEvent;
        }
    }
    public enum EventType { golf, bowling, amusementPark, concert }
}