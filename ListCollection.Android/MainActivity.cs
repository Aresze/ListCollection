using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using ListCollection.Android.Adapter;
using ListCollection.Android.Helper;
using System;

namespace ListCollection.Android
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private RecyclerView recycler;
        private RecycleViewAdapter adapter;
        private RecyclerView.LayoutManager layoutManager;
        NamesAndPhones namesAndPhones;
        Photo photo;
        Contacts lstContacts;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            namesAndPhones = new NamesAndPhones();
            photo = new Photo();
            lstContacts = new Contacts();
            
            recycler = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            layoutManager = new LinearLayoutManager(this);
            recycler.SetLayoutManager(layoutManager);
            adapter = new RecycleViewAdapter(lstContacts.getContacts());
            recycler.SetAdapter(adapter);
            addContacts(10);

            var addItem = FindViewById<ImageView>(Resource.Id.addNewContact);
            addItem.Click += (sender, e) =>
            {
                openDialog();
            };
        }

        void openDialog()
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
                adapter.AddItem(position: 1,photo.getRandomPhoto(), name.Text, phone.Text);
                recycler.SmoothScrollToPosition(0);
            });

            alertDialog.SetButton2("Cancel", (s, e) =>
            {
                alertDialog.Cancel();
            });
            alertDialog.Show();
        }

        void addContacts(int count)
        {
            for(int i = 0; i < count; i++)
            {
                adapter.AddItem(position: lstContacts.contacts.Count, photo.getRandomPhoto(), namesAndPhones.getRandomName(), namesAndPhones.getRandomPhone());
            }
            recycler.SmoothScrollToPosition(0);
        }
    }
}
