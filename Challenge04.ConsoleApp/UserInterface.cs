using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Challenge04.Repository;


namespace Challenge04.ConsoleApp
{
    public class UserInterface
    {

        OutingRepository _outingRepo = new OutingRepository();

        bool isRunning = true;

        public void Run()
        {
            _outingRepo.SeedOutingData();

            while (isRunning == true)
            {
                PrintMainMenu();

                string input = GetInputFromUser();

                UserInputSwitchCase(input);
            }
        }

        public string GetInputFromUser()
        {
            Console.WriteLine("Enter Selection... ");
            return Console.ReadLine();
        }

        private void PrintMainMenu()
        {
            Console.WriteLine(
                "1. * Display All Outings * \n" +
                "2. * Add New Outing to Database * \n" +
                "3. * Delete Outing From List * \n" +
                "4. * Display Total Cost of All Outings * \n" +
                "5. * Display Outing Cost by Outing Type * \n" +
                "6. * Exit Application *"
            );
        }

        private void UserInputSwitchCase(string input)
        {
            switch (input)
            {
                case "1":
                    ViewAllOutings();
                    break;
                case "2":
                    AddOutingToList();
                    break;
                case "3":
                    DeleteOutingFromList();
                    break;
                case "4":
                    DisplayCostOfAllOutings();
                    break;
                case "5":
                    DisplayCostOfAllOutingsByType();
                    break;
                case "6":
                    isRunning = false;
                    ExitApplication();
                    break;
                default:
                    break;
            }
        }

        private void ExitApplication()
        {
            Console.WriteLine("Closing Application. \n" + "Press any key when finished here...");
            Console.ReadKey();
        }

        private void ViewAllOutings()
        {
            List<Outing> allOutings = _outingRepo.GetAllOutingsFromList();

            foreach (Outing x in allOutings)
            {
                PrintOutingItem(x);
            }
            Console.WriteLine("Press enter when finished here");
            Console.ReadKey();
        }

        private void PrintOutingItem(Outing outing)
        {
            Console.WriteLine(
                $"Event Type - {outing.EventType}\n" +
                $"Number of Attendees - {outing.NumberOfPeople}\n" +
                $"Date of Event - {outing.Date}\n" +
                $"Cost Per Person - {outing.CostPerPerson}\n" +
                $"Total Cost of Event - {outing.CostOfEvent}\n"
            );
        }

        private void DeleteOutingFromList()
        {
            Console.WriteLine("Enter the Type of Outing you wish to delete");
            string input = GetInputFromUser();
            Console.WriteLine("Enter the date of the Outing you wish to delete.\n3What year was the event?");
            int year = Convert.ToInt32(GetInputFromUser());
            Console.WriteLine("What month was the event?");
            int month = Convert.ToInt32(GetInputFromUser());
            Console.WriteLine("What day was the event?");
            int day = Convert.ToInt32(GetInputFromUser());
            DateOnly dateInput = new DateOnly(year, month, day);

            bool success = _outingRepo.DeleteOutingByTypeAndDate(input, dateInput);

            if (success)
            {
                Console.WriteLine("Outing deleted......Press enter when finished here.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Couldn't find that Outing........Press enter when finished here.");
                Console.ReadKey();
            }
        }

        private void AddOutingToList()
        {
            Console.WriteLine("To add a new Outing to database, please enter the TYPE of OUTING now.");
            string outingType = GetInputFromUser();
            EventType eventType = (EventType)Enum.Parse(typeof(EventType), outingType);

            Console.WriteLine("Now enter the NUMBER OF PEOPLE in attendance.");
            int numberOfPeople = Convert.ToInt32(GetInputFromUser());

            Console.WriteLine("Now enter the DATE of the event...\nWhat year was the event?");
            int year = Convert.ToInt32(GetInputFromUser());
            Console.WriteLine("What month was the event?");
            int month = Convert.ToInt32(GetInputFromUser());
            Console.WriteLine("What day was the event?");
            int day = Convert.ToInt32(GetInputFromUser());
            DateOnly date = new DateOnly(year, month, day);

            Console.WriteLine("Now enter the COST PER ATTENDEE.");
            decimal CostPerPerson = Convert.ToDecimal(GetInputFromUser());

            Console.WriteLine("Now enter the TOTAL COST OF THE EVENT. ");
            decimal CostOfEvent = Convert.ToDecimal(GetInputFromUser());

            Outing newOuting = new Outing(eventType, numberOfPeople, date, CostPerPerson, CostOfEvent);

            _outingRepo.AddOutingToList(newOuting);

            Console.WriteLine("Event Added....press enter when done here.");
            Console.ReadKey();
        }


        public void DisplayCostOfAllOutings()
        {
            Console.WriteLine($"The TOTAL of ALL OUTING costs are - ");
            Console.Write(_outingRepo.OutingCostsCombined());
            Console.WriteLine("\n");
        }


        public void DisplayCostOfAllOutingsByType()
        {
            Console.WriteLine("Please enter an OUTING TYPE of which costs you wish to display.");
            string input = GetInputFromUser();

            Console.WriteLine($"The Total costs of all outings of type {input} are:");
            Console.Write(_outingRepo.OutingCostsByType(input));
            Console.WriteLine("\n");
        }

    }
}