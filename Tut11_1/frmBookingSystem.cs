using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using BookingSystem;

namespace Tut11_1
{
    public partial class frmBookingSystem : Form
    {
        public frmBookingSystem()
        {
            InitializeComponent();
        }

        //create a global list of strings called bookingDetails to hold all the data
        //this can be used by all methods and forms within the project

        public List<string> bookingDetails = new List<string>();

        //the event handler for loading the form
        private void frmBookingSystem_Load(object sender, System.EventArgs e)
        {
            if (File.Exists("Details.txt"))
            {
                string strBookingList = "";
                using (StreamReader sr = new StreamReader("Details.txt"))
                {
                    strBookingList = sr.ReadToEnd();
                }

                string[] strDetails = strBookingList.Split('#');

                foreach (string info in strDetails)
                {
                    if (info != "")
                    {
                        bookingDetails.Add(info);
                    }
                }//end foreach
            }//end if
            
            //call the method to upload the list into the listbox for display
            LoadBookingsListBox();
        }

        //a method to insert all the items in the list in the listbox
        private void LoadBookingsListBox()
        {
            lstBookingDetails.Items.Clear();//clear the box of any previous data
            //add each item in the list to the listbox
            foreach (string s in bookingDetails)
                lstBookingDetails.Items.Add(s);
            //set the selected item to the first one in the list if there are any
            if (lstBookingDetails.Items.Count > 0)
                lstBookingDetails.SelectedIndex = 0;
        }

        //the event handler for the Add New button
        private void btnAddNew_Click(object sender, System.EventArgs e)
        {
            //create an instance of the Add New Student Form
            Form addForm = new frmAddNewStudent();
            DialogResult button = addForm.ShowDialog();//display as a dialog box
            if (button == DialogResult.OK)//if the user clicks OK
            {
                bookingDetails.Add(addForm.Tag.ToString());//take the current state of the list from the Add New Student Form
                LoadBookingsListBox();//display it in the listbox
            }
        }
        //the event handler for the Update button
        private void btnUpdate_Click(object sender, System.EventArgs e)
        {
            string customer = (string)bookingDetails[lstBookingDetails.SelectedIndex];//store the selected student from the listbox in a string variable

            //create a new instance of the Update Student Scores Form
            Form updateForm = new frmUpdateInfo();
            updateForm.Tag = customer;//set its current state to the selected data
            DialogResult button = updateForm.ShowDialog();//display it as a dialog box
            //if the user clicks OK
            if (button == DialogResult.OK)
            {
                bookingDetails.Insert(lstBookingDetails.SelectedIndex, updateForm.Tag.ToString());//insert the new
                bookingDetails.RemoveAt(lstBookingDetails.SelectedIndex + 1);//remove the old
                LoadBookingsListBox();//display the list in the listbox
            }
        }

        //the event handler for the delete button
        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            if (bookingDetails.Count > 0)
            {
                bookingDetails.RemoveAt(lstBookingDetails.SelectedIndex);//delete the selected item
                LoadBookingsListBox();//display the new list in the listbox
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                string strAllCustomers = "";
                foreach (string customer in bookingDetails)
                {
                    strAllCustomers += customer + '#';
                }

                //write the string to the file
                StreamWriter textOut = new StreamWriter("Details.txt");
                textOut.WriteLine(strAllCustomers.Remove(strAllCustomers.Length - 1));
                textOut.Close();              
                this.Close();
            }
            catch
            {
                MessageBox.Show("File could not be saved");
                this.Close();
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            //create an instance of the help form
            Form helpForm = new frmHelp();
            DialogResult button = helpForm.ShowDialog();//display as a dialog box
            
        }        

    }
}

