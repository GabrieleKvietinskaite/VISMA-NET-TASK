using System;
using System.Linq;

namespace NET_HOMEWORK
{
    public static class ConsoleReader
    {
        public static string ReadConsoleInput(string message)
        {
            Console.WriteLine(message);

            return Console.ReadLine();
        }

        public static string ReadNameInput(string message)
        {
            var name = "";

            while (name.Length <= 0 || name.Length > 20)
            {
                name = ReadConsoleInput(message);
            }

            return name;
        }

        public static long ReadPhoneNumberInput(Contact contact, string message)
        {
            var phoneNumberInput = "";
            long phoneNumber = 0;

            while (!long.TryParse(phoneNumberInput, out phoneNumber) || phoneNumberInput.Length <= 0 ||
                phoneNumberInput.Length > 11 || contact.Contacts.Any(c => c.PhoneNumbers.Contains(phoneNumber)))
            {
                phoneNumberInput = ReadConsoleInput(message);
            }

            return phoneNumber;
        }

        public static int ReadContactID(Contact contact, string message)
        {
            var contactIdInput = "";
            int contactId = 0;

            while (!Int32.TryParse(contactIdInput, out contactId) || contactIdInput.Length <= 0 || contactId > contact.Contacts.Count() || contactId <= 0)
            {
                contactIdInput = ReadConsoleInput(message);
            }

            return contactId;
        }

        public static int ReadPhoneNumberID(ContactModel contactModel, string message)
        {
            var phoneNumberIdInput = "";
            int phoneNumberId = 0;

            while (!Int32.TryParse(phoneNumberIdInput, out phoneNumberId) || phoneNumberIdInput.Length <= 0 || phoneNumberId > contactModel.PhoneNumbers.Count || phoneNumberId <= 0)
            {
                phoneNumberIdInput = ReadConsoleInput(message);
            }

            return phoneNumberId;
        }
    }
}
