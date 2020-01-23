namespace ListCollection.Helper
{
    public class RemoveUserContact
    {
       public void RemoveContact(Contacts contacts,int position)
        {
            if(contacts!=null)
                contacts.contacts.RemoveAt(position);
        }
    }
}
