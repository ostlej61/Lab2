using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Flight holdFlight = new Flight();
        Controller controller = new Controller();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void DisplayFlights()
        {
            List<Flight> flightList = new List<Flight>();
            List<string> holdList = new List<string>();
            string holdData = "";
            flightList = controller.GetAll();

            foreach (Flight flightObj in flightList)
            {
                holdData = flightObj.FlightId + ", " + flightObj.FlightOrigin + ", " + flightObj.FlightDestination + ", " + flightObj.FlightNumPassengers;
                holdList.Add(holdData);
            }

            lstFlightDisplay.ItemsSource = holdList;
        }

        private void btnDisplayAll_Click(object sender, RoutedEventArgs e)
        {
            DisplayFlights();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            frmCreateFlight createFlight = new frmCreateFlight();
            createFlight.Show();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if(holdFlight.FlightId == null)
            {
                MessageBox.Show("Please display and select the flight you wish to edit.");
            }
            else
            {
                frmUpdateFlight updateFlight = new frmUpdateFlight(holdFlight);
                updateFlight.Show();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            controller.Delete(holdFlight);
            MessageBox.Show("Flight " + holdFlight.FlightId + " successfully Deleted.");
            DisplayFlights();
        }

        private void lstFlightDisplay_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstFlightDisplay.SelectedItem == null)
            {
                //do nothing
            }
            else
            {
                string selectedFlight = lstFlightDisplay.SelectedItem.ToString();
                string[] hold = selectedFlight.Split(", ");
                holdFlight.FlightId = hold[0];
                holdFlight.FlightOrigin = hold[1];
                holdFlight.FlightDestination = hold[2];
                holdFlight.FlightNumPassengers = hold[3];
            }
            
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
