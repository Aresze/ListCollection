using Android.App;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using ListCollection.Helper;
using static ListCollection.Android.Helper.EventType;

namespace ListCollection.Android.Adapter
{
    class RecycleViewHolder : RecyclerView.ViewHolder
    {
        public ImageView image { get; set; }
        public TextView name { get; set; }
        public TextView phone { get; set; }
        public ImageView delete { get; set; }
        public RecycleViewHolder(View itemView, Action<int, eventClick> listener) : base(itemView)
        {
            image = itemView.FindViewById<ImageView>(Resource.Id.imageView);
            phone = itemView.FindViewById<TextView>(Resource.Id.phone);
            name = itemView.FindViewById<TextView>(Resource.Id.name);
            delete = itemView.FindViewById<ImageView>(Resource.Id.delete);

            delete.Click += (sender, e) =>
            {
                listener(base.LayoutPosition, eventClick.delete);
            };
            itemView.Click += (sender, e) =>
            {
                listener(base.LayoutPosition, eventClick.info);
            };
        }
    }

    class RecycleViewAdapter : RecyclerView.Adapter
    {
        private Contacts contacts = new Contacts();
        RemoveUserContact removeUserContact = new RemoveUserContact();

        public RecycleViewAdapter(List<Contact> lstContacts)
        {
            contacts.contacts = lstContacts;
        }

        public override int ItemCount => contacts.contacts.Count();

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var viewHolder = holder as RecycleViewHolder;
            viewHolder.image.SetImageResource((int)typeof(Resource.Drawable).GetField(contacts.contacts[position].PhotoID).GetValue(null));
            viewHolder.phone.Text = contacts.contacts[position].Phone;
            viewHolder.name.Text = contacts.contacts[position].Name;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            LayoutInflater inflater = LayoutInflater.From(parent.Context);
            View itemView = inflater.Inflate(Resource.Layout.list_item, parent, false);

            return new RecycleViewHolder(itemView, OnClick);
        }
        void OnClick(int position, eventClick e)
        {
            switch (e)
            {
                case eventClick.delete: RemoveItem(position); break;
                case eventClick.info: OpenInfo(position); break;
                default: break;
            }
        }

        private void OpenInfo(int position)
        {
            var intent = new Intent(Application.Context, typeof(ContactInfo));
            intent.AddFlags(ActivityFlags.NewTask);
            intent.PutExtra("name", contacts.contacts[position].Name);
            intent.PutExtra("phone", contacts.contacts[position].Phone);
            intent.PutExtra("photo", contacts.contacts[position].PhotoID);
            Application.Context.StartActivity(intent);
        }

        public void RemoveItem(int position)
        {
            //_lstContacts.RemoveAt(position);
            removeUserContact.RemoveContact(contacts, position);
            NotifyItemRemoved(position);
        }
    }
}