using System.Collections.Generic;

namespace ListCollection.Helper
{
    public class AddUserContacts
    {
        NamesAndPhones namesAndPhones = new NamesAndPhones();
        Photo photo = new Photo();
        Contacts lstcontacts = new Contacts();
        public Contacts AddContacts(int count)
        {
            for (int i = 0; i < count; i++)
            {
                lstcontacts.contacts.Add(new Contact(photo.getRandomPhoto(), namesAndPhones.getRandomName(), namesAndPhones.getRandomPhone()));
            }
            return lstcontacts;
        }
        public void AddContact(int position,string name,string phone, string idPhoto)
        {
            lstcontacts.contacts.Insert(position, new Contact(idPhoto,
                                                        string.IsNullOrEmpty(name) ? "noname" : name,
                                                        string.IsNullOrEmpty(phone) ? "your phone" : phone));
        }
    }
}
