using System;
using UIKit;
using ListCollection.Helper;
using ListCollection.iOS.Helper;

namespace ListCollection.iOS
{
    public partial class HomeScreen : UIViewController
    {
        Contacts lstContacts;
        AddUserContacts addUserContacts;
        TableSource tableSource;

        public HomeScreen(IntPtr handle) : base(handle)
        {
        }
          
        public override void ViewDidLoad() 
        {
            base.ViewDidLoad();
            addUserContacts = new AddUserContacts();

            lstContacts = addUserContacts.AddContacts(10);

            tableSource = new TableSource(lstContacts, this);
            contactsTableView.Source = tableSource;

            AddItem.Clicked += (sender, e) =>
            {
                OpenAddDialog();
            };
        }

        void OpenAddDialog()
        {
            var alert = UIAlertController.Create("Create new contact", "Enter name and phone", UIAlertControllerStyle.Alert);
            UITextField fieldName = null;
            UITextField fieldPhone = null;
            alert.AddTextField((Name) =>
            {
                fieldName = Name;
                fieldName.Placeholder = "Name";
                fieldName.AutocorrectionType = UITextAutocorrectionType.No;
                fieldName.KeyboardType = UIKeyboardType.Default;
                fieldName.ReturnKeyType = UIReturnKeyType.Done;
                fieldName.ClearButtonMode = UITextFieldViewMode.WhileEditing;

            });
            alert.AddTextField((Phone) =>
            {
                fieldPhone = Phone;
                fieldPhone.Placeholder = "Phone";
                fieldPhone.AutocorrectionType = UITextAutocorrectionType.No;
                fieldPhone.KeyboardType = UIKeyboardType.PhonePad;
                fieldPhone.ReturnKeyType = UIReturnKeyType.Done;
                fieldPhone.ClearButtonMode = UITextFieldViewMode.WhileEditing;

            });

            alert.AddAction(UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, alertAction => { }));

            alert.AddAction(UIAlertAction.Create("Save", UIAlertActionStyle.Default, (UIAlertAction obj) =>
            {
                addUserContacts.AddContact(position:0, fieldName.Text, fieldPhone.Text, "avatar_default");
                contactsTableView.ReloadData();
            }));
            PresentViewController(alert, true, null);
        }

        public void OpenInfoPage(string name,string phone,string image)
        {
            var second = Storyboard.InstantiateViewController("viewUser") as ContactInfo;

            second.SendName = name;
            second.SendPhone = phone;
            second.UserImage = image;

            second.ModalPresentationStyle = UIModalPresentationStyle.FullScreen;
            NavigationController.PushViewController(second, true);
        }

        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();
        }
    }
}