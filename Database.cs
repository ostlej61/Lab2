using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lab2
{
    public class Database
    {
        private string path;
        StreamReader file;

        public List<Flight> GetAll()
        {
            List<Flight> flightList = new List<Flight>();
            Flight flight = new Flight();
            path = "Database\\Database.txt";
            string line;

            file = new StreamReader(path);
            while ((line = file.ReadLine()) != null)
            {
                string[] holdData = line.Split(',');
                flightList.Add(new Flight(holdData[0], holdData[1], holdData[2], holdData[3]));
            }

            flightList = flightList.OrderBy(x => x.FlightId).ToList();
            file.Close();
            return flightList;
        }

        public void Insert(Flight flight)
        {
            try
            {
                Database database = new Database();
                path = "Database\\Database.txt";
                List<Flight> flightList = new List<Flight>();

                //get all flights
                flightList = database.GetAll();

                //add and sort newest flight
                flightList.Add(flight);
                flightList = flightList.OrderBy(x => x.FlightId).ToList();

                //write back to database
                using (TextWriter writer = new StreamWriter(path)) 
                {
                    foreach (Flight flightObj in flightList)
                    {
                        writer.WriteLine(string.Format("{0},{1},{2},{3}",
                                                        flightObj.FlightId,
                                                        flightObj.FlightOrigin,
                                                        flightObj.FlightDestination,
                                                        flightObj.FlightNumPassengers));
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public void Update(Flight flight)
        {
            try
            {
                path = "Database\\Database.txt";
                List<Flight> flightList = new List<Flight>();
                Database database = new Database();

                //get all flights
                flightList = database.GetAll();

                //look for the flight to be updated
                foreach (Flight flightObj in flightList)
                {
                    if (flightObj.FlightId == flight.FlightId)
                    {
                        flightObj.FlightOrigin = flight.FlightOrigin;
                        flightObj.FlightDestination = flight.FlightDestination;
                        flightObj.FlightNumPassengers = flight.FlightNumPassengers;

                        flightList = flightList.OrderBy(x => x.FlightId).ToList();

                        //write back to database
                        using (TextWriter writer = new StreamWriter(path))
                        {
                            foreach (Flight flightObj2 in flightList)
                            {
                                writer.WriteLine(string.Format("{0},{1},{2},{3}",
                                                                flightObj2.FlightId,
                                                                flightObj2.FlightOrigin,
                                                                flightObj2.FlightDestination,
                                                                flightObj2.FlightNumPassengers));
                            }
                        }
                        
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(Flight flight)
        {
            try
            {
                path = "Database\\Database.txt";
                List<Flight> flightList = new List<Flight>();
                Database database = new Database();
                int counter = 0;

                //get all flights
                flightList = database.GetAll();

                //look for the flight to be updated
                foreach (Flight flightObj in flightList)
                {
                    if (flightObj.FlightId == flight.FlightId)
                    {
                        flightList.RemoveAt(counter);

                        //clear database
                        File.WriteAllText(path, String.Empty);

                        //write back to database
                        using (TextWriter writer = new StreamWriter(path))
                        {
                            foreach (Flight flightObj2 in flightList)
                            {
                                writer.WriteLine(string.Format("{0},{1},{2},{3}",
                                                                flightObj2.FlightId,
                                                                flightObj2.FlightOrigin,
                                                                flightObj2.FlightDestination,
                                                                flightObj2.FlightNumPassengers));
                            }
                        }

                        break;
                    }
                    counter++;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
