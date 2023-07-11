namespace AddressBookADO;

internal class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Data Source=KUNDAN;Initial Catalog=AddressBookSystem;Integrated Security=True;";
        AddressBook addressBook = new AddressBook(connectionString);
        // Add Contacts
        Contact contact1 = new Contact(1, "kundan", "kumar", "kun@dan", "9867", "sheohar", "Bihar", "12345");
        Contact contact2 = new Contact(2, "praveen", "kumar", "pra@veen", "45678", "bengaluru", "karnatak", "98765");
        Contact contact3 = new Contact(3, "shailav", "sinha", "shai@lav", "765432", "patna", "bihar", "54321");
        /*addressBook.AddContact(contact1);
        addressBook.AddContact(contact2);
        addressBook.AddContact(contact3);*/

        // Edit Contacts
        contact3.Email = "shailav@1211234";
        contact3.Zip = "12345";
        addressBook.EditContact(contact3);

        //Retrive Contacts
        /* Contact retrivedContact = addressBook.RetriveContact(3);
         if (retrivedContact != null)
         {
             Console.WriteLine($"FirstName: {retrivedContact.FirstName}");
             Console.WriteLine($"LastName: {retrivedContact.LastName}");
             Console.WriteLine($"Email: {retrivedContact.Email}");
             Console.WriteLine($"ContactNumber: {retrivedContact.ContactNumber}");
             Console.WriteLine($"City: {retrivedContact.City}");
             Console.WriteLine($"State: {retrivedContact.State}");
             Console.WriteLine($"Zip: {retrivedContact.Zip}");
         }
         else
         {
             Console.WriteLine("Contact not found:");
         }*/

        // Delete Contacts
        /*addressBook.DeleteContact(2);
        addressBook.DeleteContact(1);
        addressBook.DeleteContact(3);
        Console.WriteLine("Contact Deleted");*/
    }
}