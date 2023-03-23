using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gold_Badge
{
    public class Drivers_Repo
    {
        private List<Drivers> _driversList = new List<Drivers>();
        // Create - add a contact
        public void AddDriverToList(Drivers drivers)
        {
            _driversList.Add(drivers);
        }
        // Read - list all contacts
        public List<Drivers> GetDriversList()
        {
            return _driversList;
        }

        // Read - get by name
        public Drivers GetDriverByName(string firstName, string lastName)
        {
            foreach (Drivers drivers in _driversList)
            {
                if (drivers.FirstName == firstName && drivers.LastName == lastName)
                {
                    return drivers;
                }
                else
                {
                    return null;
                }
            }
            return null;
        }
        // Update - edit by id
        public Drivers GetDriverById(int idNumber)
        {
            foreach (Drivers drivers in _driversList)
            {
                if (drivers.IdNumber == idNumber)
                {
                    return drivers;
                }
            }
            return null;
        }
        public bool UpdateDriverList(int idInput, Drivers newInfo)
        {
            Drivers oldInfo = GetDriverById(idInput);
            if (oldInfo != null)
            {
                oldInfo.FirstName = newInfo.FirstName;
                oldInfo.LastName = newInfo.LastName;
                oldInfo.IdNumber = newInfo.IdNumber;
                oldInfo.PhoneNumber = newInfo.PhoneNumber;
                oldInfo.Address = newInfo.Address;
                oldInfo.Email = newInfo.Email;
                return true;
            }
            else
            {
                return false;
            }
        }
        // Delete - Remove contact by id
        public bool RemoveDriverFromList(int idNumber)
        {
            Drivers Idinput = GetDriverById(idNumber);
            if (Idinput == null)
            {
                return false;
            }
            int initialCount = _driversList.Count;
            _driversList.Remove(Idinput);
            if (initialCount > _driversList.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
