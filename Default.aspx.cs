using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{

    //variables
    List<Address> addresses = new List<Address>();

    /// <summary>
    /// read the Address.csv file
    /// add the address to a list of addresses
    /// sort the list by last name, first name
    /// save the list as an application variable
    /// populate the dropdown list
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Application["addresses"] == null)  //if list of addresses is not populated yet
        {
            string path = Server.MapPath("App_Data/Addresses.csv"); //path to data
            using (StreamReader readFile = new StreamReader(path))  //read data
            {
                string line;
                while((line = readFile.ReadLine()) != null) //take in an address 
                {
                    Address tempAddress = new Address(line); 
                    addresses.Add(tempAddress);
                }
            }
            addresses.Sort();
            Application["addresses"] = addresses;
        }
        else
        {
            addresses = (List<Address>)Application["addresses"];
        }

        //at this point, the "addresses" application
        //list is populated, and sorted in alphabetical order
        char firstLetter;
        char prevLetter = '~';
        foreach(Address address in addresses)
        {
            firstLetter = address.lastName[0]; //grab first letter of last name
            if(firstLetter != prevLetter)      //if the last name is a new letter
            {
                LinkButton lb = new LinkButton(); //create a new button
                lb.Text = firstLetter.ToString();
                lb.ID = "lb" + firstLetter;
                lb.Click += LinkButton1_Click;
                phLinks.Controls.Add(lb );        //add button to the placeholder
                phLinks.Controls.Add(new LiteralControl("&nbsp &nbsp")); //add 2 spaces 
                prevLetter = firstLetter;
            }


        }// end foreach loop


    }//end function page_load


    //event handlr for button clicks 
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        //clear the drop down list 
        ddlNames.Items.Clear();
        //hide the old address
        lblAddress.Text = "blank";
        lblAddress.ForeColor = System.Drawing.Color.White;

        LinkButton btn = (LinkButton)sender; //the clicked button

        //populate the drop down list
        ListItem li = new ListItem("Please Select a Name", "");  //first option
        ddlNames.Items.Add(li);
        char frstLtr = btn.Text[0]; //what button what clicked
        char currentLtr = '~'; //temp assignment
        foreach (Address address in addresses)
        {
            currentLtr = address.lastName[0];
            //add all names to the ddl of the same first letter
            if (currentLtr == frstLtr) 
            {
                string tempName = address.lastName + "," + address.firstName;
                li = new ListItem(tempName, address.firstName);
                ddlNames.Items.Add(li);
            }
        }


    }//end function



    //event handlr for drop down list auto-postback
    protected void ddlNames_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if the user selects the first option 'please select a name'
        //erase the address and return
        if(ddlNames.SelectedIndex == 0) 
        {
            lblAddress.Text = "blank";
            lblAddress.ForeColor = System.Drawing.Color.White;
            return; 
        }

        lblAddress.ForeColor = System.Drawing.Color.Black;       //change the color of the address to black

        string[] names; //get the requested name
        names = ddlNames.SelectedItem.ToString().Split(',');
        string selectedLastName = names[0]; //last name
        string selectedName = names[1];     //first name

        string theAddress = ""; 

        foreach(Address address in addresses) //find the selected name in the list to retrieve the address
        {
            if(address.lastName == selectedLastName && address.firstName == selectedName) //if the correct name is found
            {
                if(address.addressLine2 == "") //if there is no second address line
                {
                    theAddress = address.addressLine1 + "<br />" 
                               + address.city + ", " 
                               + address.state + " " 
                               + address.zipCode;
                }
                else //there is a second address line
                {
                    theAddress = address.addressLine1 + "<br />" 
                               + address.addressLine2 + "<br />" 
                               + address.city + ", " 
                               + address.state + " " 
                               + address.zipCode;
                }
            }
        }

        lblAddress.Text = theAddress; //display the address 


    }//end function ddl auto postback
}//end class 