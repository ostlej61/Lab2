using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    public class Controller
    {
        public List<Flight> GetAll()
        {
            Database database = new Database();
            List<Flight> flightList = new List<Flight>();
            flightList = database.GetAll();
            return flightList;
        }

        public void Insert(Flight flight)
        {
            Database database = new Database();
            database.Insert(flight);
        }

        public void Update(Flight flight)
        {
            Database database = new Database();
            database.Update(flight);
        }

        public void Delete(Flight flight)
        {
            Database database = new Database();
            database.Delete(flight);
        }
    }
}
