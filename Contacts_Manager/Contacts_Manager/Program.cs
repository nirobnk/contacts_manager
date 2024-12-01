using System;
using System.Collections.Generic;
using Contacts_Manager;

namespace Contacts_Manager
{
    class Program
    {
        //global list to store contacts
        private static List<Contact> contacts = new List<Contact>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n--- Phone Contact Manager ---");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. Search Contact");
                Console.WriteLine("3. Display All Contacts");
                Console.WriteLine("4. Delete Contact");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddContact();
                        break;
                    case "2":
                        SearchContact();
                        break;
                    case "3":
                        DisplayContacts();
                        break;
                    case "4":
                        DeleteContact();
                        break;
                    case "5":
                        Console.WriteLine("Exiting... Goodbye !");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
        //method to add a new contact
        static void AddContact()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            
            Console.Write("Enter Phone Number: ");
            string phoneNumber = Console.ReadLine();
            
            Console.Write("Enter Email: ");
            string email = Console.ReadLine();
            
            contacts.Add(new Contact(name, phoneNumber, email));
            Console.WriteLine("Contact added successfully.");
        }
        
        //to search contact we need lots of method to do it from scratch for that 
        
        //implement linearsearch it doesnot need to sort the contact list
        static void SearchContactLinear(string searchName)
        {
            bool found = false;
            Console.WriteLine("\n--- Search Results ---");

            for (int i = 0; i < contacts.Count; i++)
            {
                if (contacts[i].Name.IndexOf(searchName, StringComparison.OrdinalIgnoreCase) >= 0)                {
                    Console.WriteLine(contacts[i].ToString());
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("No such Contact");
            }
        }
        
        //then implement binary search therefore first we need to bubble sort this contact liest
        //bubble sort method is here
        static void BubbleSortContacts()
        {
            for (int i = 0; i < contacts.Count - 1; i++)
            {
                for (int j = 0; j < contacts.Count - i - 1; j++)
                {
                    if (string.Compare(contacts[j].Name, contacts[j + 1].Name, StringComparison.OrdinalIgnoreCase) > 0)
                    {
                        var temp = contacts[j];
                        contacts[j] = contacts[j + 1];
                        contacts[j + 1] = temp;
                    }
                }
            }
        }
        
        //binary search method
        static void SearchContactBinary(string searchName)
        {
            //Ensure the list is sorted before searching
            BubbleSortContacts();
            
            int low = 0, high = contacts.Count - 1;
            bool found = false;

            while (low <= high)
            {
                int mid = (low + high) / 2;
                int comparison = string.Compare(searchName, contacts[mid].Name, StringComparison.OrdinalIgnoreCase);

                if (comparison == 0)
                {
                    Console.WriteLine($"Contact Found: {contacts[mid].ToString()}");
                    found = true;
                    break;
                }
                else if (comparison < 0)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            if (!found)
            {
                Console.WriteLine("No such Contact");
            }
        }
        static void SearchContact()
        {
            Console.WriteLine("\nChoose Search Method:");
            Console.WriteLine("1. Linear Search");
            Console.WriteLine("2. Binary Search (sorted)");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();
            
            Console.Write("Enter Name to Search: ");
            string searchName = Console.ReadLine();

            if (choice == "1")
            {
                SearchContactLinear(searchName);
            }
            else if (choice == "2")
            {
                SearchContactBinary(searchName);
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }//this is the end of search function making
        
        //method to display all contacts

        static void DisplayContacts()
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("No such Contacts");
                return;
            }
            Console.WriteLine("\n--- All Contacts ---");
            foreach (var contact in contacts)
            {
                Console.WriteLine(contact);
            }
        }
        
        //method to delete a contact by name

        static void DeleteContact()
        {
            Console.Write("Enter Name of Contact to Delete: ");
            string name = Console.ReadLine();
            
            var contactToRemove = contacts.Find(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (contactToRemove != null)
            {
                contacts.Remove(contactToRemove);
                Console.WriteLine("Contact deleted successfully!");
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
        }
    }
}