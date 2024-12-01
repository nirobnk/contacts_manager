namespace Contacts_Manager;

public class Contact
{
    public string Name {get; set;}
    public string Email {get; set;}
    public string PhoneNumber {get; set;}

    public Contact(string name, string email, string phoneNumber)
    {
        Name = name;
        Email = email;
        PhoneNumber = phoneNumber;
    }

    public override string ToString()
    {
        return $"Name: {Name}, Email: {Email}, PhoneNumber: {PhoneNumber}";
    }
}