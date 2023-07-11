using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookADO;

public class Contact
{
    public int ContactId {  get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string ContactNumber { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }

    public Contact(int contactId, string firstName, string lastName, string email, string contactNumber, string city, string state, string zip) 
    { 
        this.ContactId = contactId;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Email = email;
        this.ContactNumber = contactNumber;
        this.City = city;
        this.State = state;
        this.Zip = zip;
    }
}
