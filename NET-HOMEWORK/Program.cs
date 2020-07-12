using System;
using System.Collections.Generic;
using System.Linq;

namespace NET_HOMEWORK
{
    class Program
    {
        static void Main(string[] args)
        {
            Contact contact = new Contact();

            while (true)
            {
                string input = ConsoleReader.ReadConsoleInput("Choose your action(1-5): \n" +
                                                "1. Print all contacts. \n" +
                                                "2. Create new contact. \n" +
                                                "3. Update contact \n" +
                                                "4. Delete contact \n" +
                                                "5. Exit");

                switch (input)
                {
                    case "1":
                        Console.WriteLine("Action: PRINT ALL CONTACTS");
                        contact.PrintContacts();
                        break;
                    case "2":
                        Console.WriteLine("Action: CREATE NEW CONTACT");
                        CreateContact(ref contact);
                        break;
                    case "3":
                        Console.WriteLine("Action: UPDATE CONTACT");
                        UpdateContact(ref contact);
                        break;
                    case "4":
                        Console.WriteLine("Action: DELETE CONTACT");
                        DeleteContact(ref contact);
                        break;
                    case "5":
                        Console.WriteLine("Action: EXIT");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Wrong input");
                        break;
                }
            }
        }

        static void CreateContact(ref Contact contact)
        {
            var firstName = ConsoleReader.ReadNameInput("Insert first name:");
            var lastName = ConsoleReader.ReadNameInput("Insert last name:");
            long phoneNumber = ConsoleReader.ReadPhoneNumberInput(contact, "Insert phone number:");
            var address = ConsoleReader.ReadConsoleInput("Insert address:");

            ContactModel contactModel = new ContactModel
            {
                FirstName = firstName,
                LastName = lastName,
                PhoneNumbers = new List<long>() { phoneNumber },
                Address = address
            };

            contact.CreateContact(contactModel);
        }

        static void UpdateContact(ref Contact contact)
        {
            int contactId = ConsoleReader.ReadContactID(contact, "Insert contact ID number:");
            var contactToUpdate = contact.Contacts[contactId - 1];

            for (int i = 0; i < contactToUpdate.PhoneNumbers.Count; i++)
            {
                Console.WriteLine($"{contactId}.{i + 1} {contactToUpdate.FirstName} {contactToUpdate.LastName} {contactToUpdate.PhoneNumbers[i]} {contactToUpdate.Address}");
            }

            var firstName = ConsoleReader.ReadNameInput("Insert first name:");
            var lastName = ConsoleReader.ReadNameInput("Insert last name:");
            var address = ConsoleReader.ReadConsoleInput("Insert address:");
            string input = ConsoleReader.ReadConsoleInput("Do you want to edit phone number? y/n");

            var phoneNumbers = contactToUpdate.PhoneNumbers;

            if (input == "y" || input == "Y")
            {
                int phoneNumberId = ConsoleReader.ReadPhoneNumberID(contactToUpdate, "Insert phone number ID number:");                
                long phoneNumber = ConsoleReader.ReadPhoneNumberInput(contact, "Insert phone number:");
                phoneNumbers[phoneNumberId - 1] = phoneNumber;
            }

            ContactModel contactModel = new ContactModel
            {
                FirstName = firstName,
                LastName = lastName,
                PhoneNumbers = phoneNumbers,
                Address = address
            };

            contact.UpdateContact(contactModel, contactId - 1);
        }

        static void DeleteContact(ref Contact contact)
        {
            string input = "";

            while (input != "1" && input != "2")
            {
                input = ConsoleReader.ReadConsoleInput("Choose your action(1-2): \n" +
                                         "1. Delete contact \n" +
                                         "2. Delete contact phone number");
            }

            int contactId = ConsoleReader.ReadContactID(contact, "Insert contact ID number:");
            var contactToDelete = contact.Contacts[contactId - 1];

            if (input == "1")
            {
                contact.DeleteContact(contactId - 1);
            }
            else if (input == "2")
            {
                int phoneNumberId = ConsoleReader.ReadPhoneNumberID(contactToDelete, "Insert phone number ID number:");
                contact.DeleteContactPhoneNumber(contactId - 1, phoneNumberId - 1);
            }
        }
    }
}