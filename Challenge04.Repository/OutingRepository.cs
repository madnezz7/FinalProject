using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Challenge04.Repository;

namespace Challenge04.Repository
{
    public class OutingRepository
    {

        // Fake Database

        private List<Outing> _outingList = new List<Outing>();

        //CRUD
        // CREATE / READ / UPDATE / DELETE


        // CREATE
        public void AddOutingToList(Outing outing)
        {
            _outingList.Add(outing);
        }


        // READ
        public List<Outing> GetAllOutingsFromList()
        {
            return _outingList;
        }


        public decimal OutingCostsByType(string userInputType)
        {
            decimal sum = 0;
            foreach (Outing outing in _outingList)
            {
                if (userInputType.ToUpper() == outing.EventType.ToString().ToUpper())
                {
                    sum += outing.CostOfEvent;
                }
            }
            return sum;
        }

        public decimal OutingCostsCombined()
        {
            decimal sum = 0;
            foreach (Outing outing in _outingList)
            {
                sum += outing.CostOfEvent;
            }
            return sum;
        }


        // UPDATE



        // DELETE

        public bool DeleteOutingByTypeAndDate(string userInputType, DateOnly userInputDate)
        {
            foreach (Outing outing in _outingList)
            {
                if ((outing.EventType.ToString().ToUpper()) == (userInputType.ToUpper()) && (outing.Date == userInputDate))
                {
                    _outingList.Remove(outing);
                    return true;
                }
            }
            return false;
        }

        // SEED DATA

        public void SeedOutingData()
        {
            Outing golf = new Outing(EventType.golf, 10, new DateOnly(2020, 06, 12), 75.00m, 750.00m);

            Outing bowling = new Outing(EventType.bowling, 8, new DateOnly(2020, 05, 20), 15m, 120m);
            Outing amusementPark = new Outing(EventType.amusementPark, 20, new DateOnly(2020, 04, 21), 150.00m, 3000.00m);
            Outing concert = new Outing(EventType.concert, 15, new DateOnly(2020, 06, 20), 50.00m, 250.00m);


            Outing[] outingArr = { golf, bowling, amusementPark, concert };

            foreach (Outing x in outingArr)
            {
                AddOutingToList(x);
            }
        }

    }
}