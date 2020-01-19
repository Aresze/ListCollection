using System.Collections.Generic;

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
        NamesAndPhones namesAndPhones;
        public Contacts()
        {
            contacts = new List<Contact>();
            namesAndPhones = new NamesAndPhones();
        }
        public List<Contact> getContacts()
        {
            return contacts;
        }
    }
}