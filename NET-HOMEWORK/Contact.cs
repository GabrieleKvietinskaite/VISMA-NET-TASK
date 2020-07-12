using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NET_HOMEWORK
{
    public class Contact
    {
        public List<ContactModel> Contacts;
        public string DataFilePath;

        public Contact()
        {
            this.Contacts = ReadData();
        }

        public List<ContactModel> ReadData()
        {
            DataFilePath = ConsoleReader.ReadConsoleInput("Insert JSON data file full path:");
            var contactModel = JsonConvert.DeserializeObject<List<ContactModel>>(File.ReadAllText(DataFilePath));

            return contactModel;
        }

        public void SaveData()
        {
            File.WriteAllText(DataFilePath, JsonConvert.SerializeObject(Contacts));
        }

        public void PrintContacts()
        {
            for(int i = 0; i < Contacts.Count; i++)
            {
                for(int j = 0; j < Contacts[i].PhoneNumbers.Count; j++)
                {
                    Console.WriteLine($"{i + 1}.{j + 1} {Contacts[i].FirstName} {Contacts[i].LastName} {Contacts[i].PhoneNumbers[j]} {Contacts[i].Address}");
                }
            }
        }

        public void CreateContact(ContactModel contactModel)
        {
            var contact = this.Contacts.FirstOrDefault(c => c.FirstName == contactModel.FirstName && c.LastName == contactModel.LastName);

            if(contact != null)
            {
                contact.PhoneNumbers.Add(contactModel.PhoneNumbers.First());
            }
            else
            {
                this.Contacts.Add(contactModel);
            }
            SaveData();
        }
        public void UpdateContact(ContactModel contactModel, int contactId)
        {
            var contact =  this.Contacts.FirstOrDefault(c => c.FirstName == contactModel.FirstName && c.LastName == contactModel.LastName);

            if(contact != null)
            {
                contact.PhoneNumbers.AddRange(contactModel.PhoneNumbers);
                contact.Address = contactModel.Address;
                this.Contacts.RemoveAt(contactId);
            }
            else
            {
                contact = this.Contacts[contactId];
                contact.FirstName = contactModel.FirstName;
                contact.LastName = contactModel.LastName;
                contact.PhoneNumbers = contactModel.PhoneNumbers;
                contact.Address = contactModel.Address;
            }
            SaveData();
        }

        public void DeleteContact(int contactId)
        {
            this.Contacts.RemoveAt(contactId);
            SaveData();
        }

        public void DeleteContactPhoneNumber(int contactId, int phoneNumberId)
        {
            this.Contacts[contactId].PhoneNumbers.RemoveAt(phoneNumberId);
            if(this.Contacts[contactId].PhoneNumbers.Count <= 0)
            {
                DeleteContact(contactId);
            }
            SaveData();
        }
    }
}
