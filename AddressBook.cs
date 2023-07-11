using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AddressBookADO;

public class AddressBook
{
    private string connectionString;
    private SqlConnection connection;

    public AddressBook(string connectionString) 
    { 
        this.connectionString = connectionString;
        connection = new SqlConnection(connectionString);
    }

    public void AddContact(Contact contact)
    {
        try
        {
            connection.Open();
            string insertQuery = "insert into Contact(ContactId, FirstName, LastName, Email, ContactNumber, City, State, Zip) values(@contactId, @firstName, @lastName, @email, @contactNumber, @city, @state, @zip)";
            SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
            insertCommand.Parameters.AddWithValue("@contactId", contact.ContactId);
            insertCommand.Parameters.AddWithValue("@firstName", contact.FirstName);
            insertCommand.Parameters.AddWithValue("@lastName", contact.LastName);
            insertCommand.Parameters.AddWithValue("@email", contact.Email);
            insertCommand.Parameters.AddWithValue("@contactNumber", contact.ContactNumber);
            insertCommand.Parameters.AddWithValue("@city", contact.City);
            insertCommand.Parameters.AddWithValue("@state", contact.State);
            insertCommand.Parameters.AddWithValue("@zip", contact.Zip);
            insertCommand.ExecuteNonQuery();
        }
        catch(Exception e) 
        { 
            Console.WriteLine("Something wrong Contact not added" + e);
        }
        finally 
        { 
            connection.Close();
        }
    }

    public void EditContact(Contact contact)
    {
        try
        {
            connection.Open();
            string updateQuery = "UPDATE Contact SET FirstName = @firstName, LastName = @lastName, Email = @email, ContactNumber = @contactNumber, City = @city, State = @state, Zip = @zip Where ContactId = @contactId";
            SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
            updateCommand.Parameters.AddWithValue("@contactId", contact.ContactId);
            updateCommand.Parameters.AddWithValue("@firstName", contact.FirstName);
            updateCommand.Parameters.AddWithValue("@lastName", contact.LastName);
            updateCommand.Parameters.AddWithValue("@email", contact.Email);
            updateCommand.Parameters.AddWithValue("@contactNumber", contact.ContactNumber);
            updateCommand.Parameters.AddWithValue("@city", contact.City);
            updateCommand.Parameters.AddWithValue("@state", contact.State);
            updateCommand.Parameters.AddWithValue("@zip", contact.Zip);
            updateCommand.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            Console.WriteLine("something wrong contact not updated" + e.Message);
        }
        finally
        {
            connection.Close();
        }

    }
    public Contact RetriveContact(int contactId)
    {
        try
        {
            connection.Open();
            string selectQuery = "select * from Contact WHERE ContactId = @contactId";
            SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
            selectCommand.Parameters.AddWithValue("@contactId", contactId);
            SqlDataReader reader = selectCommand.ExecuteReader();

            if (reader.Read())
            {
                int ContactId = (int)reader["ContactId"];
                string firstName = (string)reader["FirstName"];
                string lastName = (string)reader["LastName"];
                string email = (string)reader["Email"];
                string contactNumber = (string)reader["ContactNumber"];
                string city = (string)reader["City"];
                string state = (string)reader["State"];
                string zip = (string)reader["Zip"];
                return new Contact(ContactId, firstName, lastName, email, contactNumber, city, state, zip);
            }
            return null;
        }
        finally 
        { 
            connection.Close(); 
        }
    }

    public void DeleteContact(int contactId)
    {
        try
        {
            connection.Open();
            string deleteQuery = "DELETE from Contact where contactId = @contactId";
            SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
            deleteCommand.Parameters.AddWithValue("@contactId", contactId);
            deleteCommand.ExecuteNonQuery();
        }
        finally 
        { 
            connection.Close(); 
        }
    }
}
