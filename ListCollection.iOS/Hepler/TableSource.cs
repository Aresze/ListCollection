using System;
using Foundation;
using ListCollection.Helper;
using UIKit;

namespace ListCollection.iOS.Helper
{
	public class TableSource : UITableViewSource
	{
		Contacts lstContacts;
		string cellIdentifier = "TableCell";
		HomeScreen owner;

		public TableSource(Contacts contacts, HomeScreen owner)
		{
			lstContacts = contacts;
			this.owner = owner;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return lstContacts.contacts.Count;
		}

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			/*UIAlertController okAlertController = UIAlertController.Create(lstContacts.contacts[indexPath.Row].Name,
																			lstContacts.contacts[indexPath.Row].Phone, 
																			UIAlertControllerStyle.Alert);
			okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
			owner.PresentViewController(okAlertController, true, null);

			tableView.DeselectRow(indexPath, true);*/
			owner.OpenInfoPage(lstContacts.contacts[indexPath.Row].Name,
								lstContacts.contacts[indexPath.Row].Phone,
								lstContacts.contacts[indexPath.Row].PhotoID);
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier);

			var cellStyle = UITableViewCellStyle.Subtitle;
			cell = new UITableViewCell(cellStyle, cellIdentifier);
			cell.TextLabel.Text = lstContacts.contacts[indexPath.Row].Name;

			cell.DetailTextLabel.Text = lstContacts.contacts[indexPath.Row].Phone;

			cell.ImageView.Image = UIImage.FromFile("Images/" + lstContacts.contacts[indexPath.Row].PhotoID);
			return cell;
		}

		public override void CommitEditingStyle(UITableView tableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath)
		{
			if (editingStyle == UITableViewCellEditingStyle.Delete)
			{
				new RemoveUserContact().RemoveContact(lstContacts, indexPath.Row);
				tableView.DeleteRows(new NSIndexPath[] { indexPath }, UITableViewRowAnimation.Fade);
			}
		}

	}
}