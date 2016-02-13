using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// class for an address
/// use ICompareable for the 'sort' function
/// </summary>
public class Address : IComparable<Address>
{
    // variables
    public string lastName;
    public string firstName;
    public string addressLine1;
    public string addressLine2;
    public string city;
    public string state;
    public string zipCode; 


    //constructor
    public Address(string line)
    {
        string[] info; //array of strings, one address line
        info = line.Split(',');//splits string at comma into array of strings 
        lastName       = info[0];
        firstName      = info[1];
        addressLine1   = info[2];
        addressLine2   = info[3];
        city           = info[4];
        state          = info[5];
        zipCode        = info[6];
    }

    /** 
    **  in order to use the sort method for List<address> ,
    **  the address class must implement the IComparable<address> 
    **  interface and provide a Compare to method
    **/
    public int CompareTo(Address other)
    {
        int result = string.Compare(this.lastName, other.lastName);
        if(result == 0) //if they have the same last name, compare the first names
        {
            result = string.Compare(this.firstName, other.firstName); 
        }

        return result; 
    }
}