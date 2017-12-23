﻿using System;
using System.Windows.Forms;

namespace Tut11_1
{
    public partial class frmAddNewStudent : Form
    {
        public frmAddNewStudent()
        {
            InitializeComponent();
        }

        int intNum = 0; //uses variable to validate the phone number if its an integer
        int intDays; //stores the value of how many days are booked for a stay

        //the event handler for the OK button
        private void btnOK_Click(object sender, System.EventArgs e)
        {
            //the if statement uses function to validate if there are any data present in the text boxes and the combo boxes
            if (IsPresent(txtFullName, "Fullname") && (IsPresent(txtPhoneNumber, "Phone number") && (IsPresent(cboCardType, "Card type") && (IsPresent(txtCardNumber, "Card number") &&
                (IsPresent(txtCardholderName, "Cardholder name") && (IsPresent(cboExpirationMonth, "Expiration month") && (IsPresent(cboExpirationYear, "Expiration year") && (IsPresent(txtAddress, "Address")
                && (IsPresent(txtPostcode, "Postcode") && (IsPresent(cboCountry, "Country")))))))))))
            {
                //the if statement below validates the phone number field to make sure that only an integer has been entered 
                if (int.TryParse(txtPhoneNumber.Text, out intNum))
                {
                    //the if statement below makes sure that 0 number of night isn't booked
                    if (intDays != 0)
                    {

                        string strCustomerDetails = txtFullName.Text;//put the name at the start of the string
                        strCustomerDetails += "|"; //these lines divide different parts of the text boxes that are later used to split the long string of text and transfer it back into the form
                        strCustomerDetails += txtPhoneNumber.Text;
                        strCustomerDetails += "|";
                        strCustomerDetails += cboCardType.Text;
                        strCustomerDetails += "|";
                        strCustomerDetails += txtCardNumber.Text;
                        strCustomerDetails += "|";
                        strCustomerDetails += txtCardholderName.Text;
                        strCustomerDetails += "|";
                        strCustomerDetails += cboExpirationYear.Text;
                        strCustomerDetails += "|";
                        strCustomerDetails += cboExpirationMonth.Text;
                        strCustomerDetails += "|";
                        strCustomerDetails += txtAddress.Text;
                        strCustomerDetails += "|";
                        strCustomerDetails += txtPostcode.Text;
                        strCustomerDetails += "|";
                        strCustomerDetails += cboCountry.Text;
                        strCustomerDetails += "|";
                        strCustomerDetails += dtpCheckIn.Text;
                        strCustomerDetails += "|";
                        strCustomerDetails += dtpCheckOut.Text;
                        strCustomerDetails += "|";

                        this.Tag = strCustomerDetails;

                        this.DialogResult = DialogResult.OK;//activate the OK button
                    }
                    else
                    {
                        MessageBox.Show("Select the check in and check out dates");//error message to tell the user to select the correct check in and out dates
                    }
                }
                else
                {
                    MessageBox.Show("Enter an integer value for the Phone number"); // error message to tell the user to enter an integer value for the phone number
                }
            }
        }

        private bool IsPresent(TextBox textBox, string name) //the is present function that validates if a text box has any data inside of it
        {
            if (textBox.Text == "")
            {
                MessageBox.Show(name + " is a required field.", "Entry Error");
                textBox.Focus();
                return false;
            }
            return true;
        }

        private bool IsPresent(ComboBox comboBox, string name) //the is present function to make sure that an option has been selected from a combo box
        {
            if (comboBox.Text == "")
            {
                MessageBox.Show(name + " is a required field.", "Entry Error");
                comboBox.Focus();
                return false;
            }
            return true;
        }

        //this is an event for when the cancel button is clicked
        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close(); //this closes the form
        }

        //an event for when a date is choses from a date time picker
        private void dtpCheckIn_ValueChanged_1(object sender, EventArgs e)
        {
            daysBookedCalculation(dtpCheckIn, dtpCheckOut);
        }

        //an event for when a date is choses from a date time picker
        private void dtpCheckOut_ValueChanged_1(object sender, EventArgs e)
        {
            daysBookedCalculation(dtpCheckIn, dtpCheckOut);
        }

        //a function to calculate the difference between check in and check out dates to get the number of night booked as the answer
        private void daysBookedCalculation(DateTimePicker checkIn, DateTimePicker checkOut)
        {
            DateTimePicker d1 = checkIn;
            DateTimePicker d2 = checkOut;

            TimeSpan diff = d2.Value - d1.Value;

            intDays = diff.Days;

            txtDaysBooked.Text = intDays.ToString();
            priceOfBooking();
        }

        //an event for when a room has been selected
        private void cboRooms_SelectedIndexChanged(object sender, EventArgs e)
        {
            priceOfBooking();
        }

        //a function which runs when the rooms has been selected
        private void priceOfBooking()
        {
            if (this.cboRooms.SelectedItem == "1 room with 1 bed (£50 per day)")
            {
                int intPrice = intDays * 50;
                txtPriceOfStay.Text = "£" + intPrice.ToString();
            }
            else if (this.cboRooms.SelectedItem == "1 room with 2 beds (£100 per day)")
            {
                int intPrice = intDays * 100;
                txtPriceOfStay.Text = "£" + intPrice.ToString();
            }
            else if (this.cboRooms.SelectedItem == "1 room with 3 beds (£150 per day)")
            {
                int intPrice = intDays * 150;
                txtPriceOfStay.Text = "£" + intPrice.ToString();
            }
            else if (this.cboRooms.SelectedItem == "1 room with 4 beds (£200 per day)")
            {
                int intPrice = intDays * 200;
                txtPriceOfStay.Text = "£" + intPrice.ToString();
            }
            else if (this.cboRooms.SelectedItem == "1 room with 5 beds (£250 per day)")
            {
                int intPrice = intDays * 250;
                txtPriceOfStay.Text = "£" + intPrice.ToString();
            }
            else if (this.cboRooms.SelectedItem == "2 rooms with 1 bed each (£100 per day)")
            {
                int intPrice = intDays * 100;
                txtPriceOfStay.Text = "£" + intPrice.ToString();
            }
            else if (this.cboRooms.SelectedItem == "2 rooms with 2 & 1 beds (£150 per day)")
            {
                int intPrice = intDays * 150;
                txtPriceOfStay.Text = "£" + intPrice.ToString();
            }
            else if (this.cboRooms.SelectedItem == "2 rooms with 2 beds each (£200 per day)")
            {
                int intPrice = intDays * 200;
                txtPriceOfStay.Text = "£" + intPrice.ToString();
            }
            else if (this.cboRooms.SelectedItem == "2 rooms with 3 & 2 beds (£250 per day)")
            {
                int intPrice = intDays * 250;
                txtPriceOfStay.Text = "£" + intPrice.ToString();
            }
            else if (this.cboRooms.SelectedItem == "3 rooms with 1 bed each (£150 per day)")
            {
                int intPrice = intDays * 150;
                txtPriceOfStay.Text = "£" + intPrice.ToString();
            }
            else if (this.cboRooms.SelectedItem == "3 rooms with 2, 1 & 1 beds (£200 per day)")
            {
                int intPrice = intDays * 200;
                txtPriceOfStay.Text = "£" + intPrice.ToString();
            }
            else if (this.cboRooms.SelectedItem == "3 rooms with 2, 2 & 1 beds (£250 per day)")
            {
                int intPrice = intDays * 250;
                txtPriceOfStay.Text = "£" + intPrice.ToString();
            }
        }

    }
}
