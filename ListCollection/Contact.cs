using System.Collections.Generic;
using UIKit;

namespace ListCollection
{
    public class Contact
    {
        public Contact(string photo, string name, string phone)
        {
            PhotoID = photo;
            Name = name;
            Phone = phone;
        }
        public string PhotoID { get; }
        public string Name { get; }
        public string Phone { get; }
       
    }

    public class Contacts
    {
        public List<Contact> contacts;
        public Contacts()
        {
            contacts = new List<Contact>();
        }
        public List<Contact> getContacts()
        {
            return contacts;
        }
    }
}