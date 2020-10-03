using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lab2
{
    /// <summary>
    /// Interaction logic for frmCreateFlight.xaml
    /// </summary>
    public partial class frmCreateFlight : Window
    {
        Controller controller = new Controller();

        public frmCreateFlight()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtId.Text = string.Empty;
            txtOrigin.Text = string.Empty;
            txtDestination.Text = string.Empty;
            txtPassengers.Text = string.Empty;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            Flight flight;
            string id = txtId.Text.ToLower();
            string origin = txtOrigin.Text.ToLower();
            string destination = txtDestination.Text.ToLower();
            string passengers = txtPassengers.Text;

            if(id.Length < 6 || !id.Substring(0,3).All(char.IsLetter) || !id.Substring(4).All(char.IsDigit))
            {
                //Id wasn't formatted correctly
                lblError.Content = "Error: Id not formatted correctly. Please try again.";
                txtId.Focus();
                txtId.SelectAll();
            }
            else if(origin.Length < 4 || !origin.All(char.IsLetter))
            {
                //Id wasn't formatted correctly
                lblError.Content = "Error: Origin can only contains letters. Please try again.";
                txtOrigin.Focus();
                txtOrigin.SelectAll();
            }
            else if (destination.Length < 4 || !destination.All(char.IsLetter))
            {
                //Id wasn't formatted correctly
                lblError.Content = "Error: Destination can only contains letters. Please try again.";
                txtDestination.Focus();
                txtDestination.SelectAll();
            }
            else if (!passengers.All(char.IsDigit))
            {
                //Id wasn't formatted correctly
                lblError.Content = "Error: Passengers can only contains numbers. Please try again.";
                txtPassengers.Focus();
                txtPassengers.SelectAll();
            }
            else //everything is correct
            {
                flight = new Flight(id, origin, destination, passengers);
                controller.Insert(flight);
                MessageBox.Show("Flight " + flight.FlightId + " successfully created.");
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lblError.Content = string.Empty;
            txtId.Focus();
        }

        private void txtId_TextChanged(object sender, TextChangedEventArgs e)
        {
            lblError.Content = string.Empty;
        }

        private void txtOrigin_TextChanged(object sender, TextChangedEventArgs e)
        {
            lblError.Content = string.Empty;
        }

        private void txtDestination_TextChanged(object sender, TextChangedEventArgs e)
        {
            lblError.Content = string.Empty;
        }

        private void txtPassengers_TextChanged(object sender, TextChangedEventArgs e)
        {
            lblError.Content = string.Empty;
        }
    }
}
