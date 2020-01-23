// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace ListCollection.iOS
{
    [Register ("ContactInfo")]
    partial class ContactInfo
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView avatarView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel contactName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel contactPhone { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (avatarView != null) {
                avatarView.Dispose ();
                avatarView = null;
            }

            if (contactName != null) {
                contactName.Dispose ();
                contactName = null;
            }

            if (contactPhone != null) {
                contactPhone.Dispose ();
                contactPhone = null;
            }
        }
    }
}