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
    [Register ("ViewController")]
    partial class HomeScreen
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem AddItem { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView contactsTableView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (AddItem != null) {
                AddItem.Dispose ();
                AddItem = null;
            }

            if (contactsTableView != null) {
                contactsTableView.Dispose ();
                contactsTableView = null;
            }
        }
    }
}