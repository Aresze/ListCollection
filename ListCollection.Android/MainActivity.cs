using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using ListCollection.Android.Adapter;
using ListCollection.Helper;
using System;

namespace ListCollection.Android
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private RecyclerView recycler;
        private RecycleViewAdapter adapter;
        private RecyclerView.LayoutManager layoutManager;
        Contacts lstContacts;
        AddUserContacts addUserContacts;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
           
            addUserContacts = new AddUserContacts();
            lstContacts = addUserContacts.AddContacts(10);

            recycler = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            layoutManager = new LinearLayoutManager(this);
            recycler.SetLayoutManager(layoutManager);
            adapter = new RecycleViewAdapter(lstContacts.getContacts());
            recycler.SetAdapter(adapter);
           

            var addItem = FindViewById<ImageView>(Resource.Id.addNewContact);

            addItem.Click += (sender, e) =>
            {
                openAddDialog();
            };
        }

        void openAddDialog()
        {
            var layoutInflater = LayoutInflater.From(Application.Context);
            var view = layoutInflater.Inflate(Resource.Layout.dialog_addcontact, null);

            var name = view.FindViewById<EditText>(Resource.Id.contactname);
            var phone = view.FindViewById<EditText>(Resource.Id.contactphone);

            var builder = new AlertDialog.Builder(this);
            builder.SetView(view);
            var alertDialog = builder.Create();

            alertDialog.SetTitle("New contact");
            alertDialog.SetButton("New", (s, e) =>
            {
                var position = 0;
                addUserContacts.AddContact(position, name.Text, phone.Text, "avatar_default");
                adapter.NotifyItemInserted(position);
                recycler.SmoothScrollToPosition(position);
            });

            alertDialog.SetButton2("Cancel", (s, e) =>
            {
                alertDialog.Cancel();
            });
            alertDialog.Show();
        }
    }
}
