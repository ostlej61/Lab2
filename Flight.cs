using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    [Serializable]
    public class Flight
    {
        //fields
        private string flightId;
        private string flightOrigin;
        private string flightDestination;
        private string flightNumPassengers;

        //constructors
        public Flight()
        {

        }

        //custom constructor
        public Flight(string inId, string inOrigin, string inDestination, string inNumPassengers)
        {
            FlightId = inId;
            FlightOrigin = inOrigin;
            FlightDestination = inDestination;
            FlightNumPassengers = inNumPassengers;
        }

        //properties
        public string FlightId
        {
            get { return flightId; }
            set { flightId = value; }
        }
        public string FlightOrigin
        {
            get { return flightOrigin; }
            set { flightOrigin = value; }
        }
        public string FlightDestination
        {
            get { return flightDestination; }
            set { flightDestination = value; }
        }
        public string FlightNumPassengers
        {
            get { return flightNumPassengers; }
            set { flightNumPassengers = value; }
        }
    }
}
