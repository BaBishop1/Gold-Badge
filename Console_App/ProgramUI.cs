using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gold_Badge
{
    public class ProgramUI
    {
        private Drivers_Repo _driversRepo = new Drivers_Repo();

        public void Run()
        {
            SeedDriverList();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                System.Console.WriteLine("Lowell Oranization Logistics Driver Address Book\n" +
                "Please choose one of the available options.\n" +
                "   1. Add a Contact\n" +
                "   2. See List of All Contacts\n" +
                "   3. Search for a Contact by Name\n" +
                "   4. Edit an Existing Contact\n" +
                "   5. Delete a Contact\n" +
                "   6. Exit the Program\n" +
                "Please Enter a Number:\n");
                string Menu1Input = Console.ReadLine();
                switch (Menu1Input)
                {
                    case "1":
                        CreateDriver();
                        break;
                    case "2":
                        DisplayAllDrivers();
                        break;
                    case "3":
                        SearchDriverByName();
                        break;
                    case "4":
                        UpdateExistingDriver();
                        break;
                    case "5":
                        DeleteExistingDriver();
                        break;
                    default:
                        keepRunning = false;
                        break;
                }
            }
            System.Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
        private void CreateDriver()
        {
            Console.Clear();
            Drivers newDriver = new Drivers();
            System.Console.WriteLine("  Creating a new Contact\n" +
            " \nEnter the New Driver's First Name:");
            newDriver.FirstName = Console.ReadLine();
            System.Console.WriteLine("Enter the New Driver's Last Name:");
            newDriver.LastName = Console.ReadLine();
            System.Console.WriteLine("Enter the New Driver's Id Number:");
            newDriver.IdNumber = int.Parse(Console.ReadLine());
            System.Console.WriteLine("Enter the New Driver's Phone Number:");
            newDriver.PhoneNumber = int.Parse(Console.ReadLine());
            System.Console.WriteLine("Enter the New Driver's Address:");
            newDriver.Address = Console.ReadLine();
            System.Console.WriteLine("Enter the New Driver's Email:");
            newDriver.Email = Console.ReadLine();
            _driversRepo.AddDriverToList(newDriver);
            System.Console.WriteLine("Please press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
        private void DisplayAllDrivers()
        {
            Console.Clear();
            List<Drivers> _DriversList = _driversRepo.GetDriversList();
            System.Console.WriteLine("List of all Contacts in the System");
            foreach (Drivers drivers in _DriversList)
            {
                System.Console.WriteLine($"  First Name: {drivers.FirstName}\n" +
                $"  Last Name: {drivers.LastName}\n" +
                $"  Phone Number: {drivers.PhoneNumber}\n" +
                $"  Id Number: {drivers.IdNumber}\n");
            }


            System.Console.WriteLine("Please press any key to continue...");
            Console.ReadKey();
        }
        private void SearchDriverByName()
        {
            Console.Clear();
            System.Console.WriteLine("Enter the Driver's First Name:");
            string firstInput = Console.ReadLine();
            System.Console.WriteLine("Enter the Driver's Last Name:");
            string lastInput = Console.ReadLine();
            Drivers searchedDriver = _driversRepo.GetDriverByName(firstInput, lastInput);
            if (searchedDriver != null)
            {
                Console.Clear();
                System.Console.WriteLine($"  First Name: {searchedDriver.FirstName}\n" +
                $"  Last Name: {searchedDriver.LastName}\n" +
                $"  Phone Number: {searchedDriver.PhoneNumber}\n" +
                $"  Id Number: {searchedDriver.IdNumber}\n" +
                $"  Address: {searchedDriver.Address}\n" +
                $"  Email: {searchedDriver.Email}\n");
            }
            else
            {
                System.Console.WriteLine("No Driver by That Name was Found.");
            }
            System.Console.WriteLine("Please press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
        private void UpdateExistingDriver()
        {
            Console.Clear();
            System.Console.WriteLine("Enter the Id of the Driver you Would Like to Update:");
            int updateDriver = int.Parse(Console.ReadLine());
            Drivers chosenDriver = _driversRepo.GetDriverById(updateDriver);
            bool keepUpdateRunning = true;
            while (keepUpdateRunning)
            {
                System.Console.WriteLine($"First Name: {chosenDriver.FirstName}\n" +
                    $"Last Name: {chosenDriver.LastName}\n" +
                    $"Phone Number: {chosenDriver.PhoneNumber}\n" +
                    $"Id Number: {chosenDriver.IdNumber}\n" +
                    $"Address: {chosenDriver.Address}\n" +
                    $"Email: {chosenDriver.Email}\n");
                System.Console.WriteLine("What information Would you Like to Change?\n" +
                "1. First Name\n" +
                "2. Last Name\n" +
                "3. Phone Number\n" +
                "4. Id Number\n" +
                "5. Address\n" +
                "6. Email\n" +
                "Enter a Number from Above or Press any key to Leave:\n");
                string changeInput = Console.ReadLine();
                if (changeInput != "7")
                {
                    System.Console.WriteLine("Please Enter the new Information:\n");
                }
                string updatedInfo = Console.ReadLine();
                switch (changeInput)
                {
                    case "1":
                        chosenDriver.FirstName = updatedInfo;
                        break;
                    case "2":
                        chosenDriver.LastName = updatedInfo;
                        break;
                    case "3":
                        chosenDriver.PhoneNumber = int.Parse(updatedInfo);
                        break;
                    case "4":
                        chosenDriver.IdNumber = int.Parse(updatedInfo);
                        break;
                    case "5":
                        chosenDriver.Address = updatedInfo;
                        break;
                    case "6":
                        chosenDriver.Email = updatedInfo;
                        break;
                    default:
                        keepUpdateRunning = false;
                        break;
                }
            }
        }
        private void DeleteExistingDriver()
        {
            Console.Clear();
            DisplayAllDrivers();
            System.Console.WriteLine("Enter the Id of the Driver you want to Delete:");
            int delInput = int.Parse(Console.ReadLine());
            bool wasDeleted = _driversRepo.RemoveDriverFromList(delInput);
            if (wasDeleted)
            {
                System.Console.WriteLine("Deletion Successful!");
            }
            else
            {
                System.Console.WriteLine("Deletion Failed...");
            }
        }
        private void SeedDriverList()
        {
            Drivers Brayden = new Drivers("Brayden", "Bishop", 4231, "1111 address lane", "bab@bab.com", 11234123);
            _driversRepo.AddDriverToList(Brayden);
        }
    }
}
