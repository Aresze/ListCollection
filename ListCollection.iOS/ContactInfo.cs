using System;
using UIKit;

namespace ListCollection.iOS
{
    public partial class ContactInfo : UIViewController
    {
        public string UserImage { get; set; }
        public string SendName { get; set; }
        public string SendPhone { get; set; }
        public ContactInfo(IntPtr handle) : base(handle)
        {
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            contactName.Text = SendName;
            contactPhone.Text = SendPhone;
            avatarView.Image = UIImage.FromBundle("Images/" + UserImage);
        }
    }
}