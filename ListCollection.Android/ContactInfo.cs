using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace ListCollection.Android
{
    [Activity(Label = "ContactInfo")]
    public class ContactInfo : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ContactInfo);

            var name = FindViewById<TextView>(Resource.Id.infoname);
            var phone = FindViewById<TextView>(Resource.Id.infophone);
            var image = FindViewById<ImageView>(Resource.Id.infoimage);

            name.Text = Intent.GetStringExtra("name");
            phone.Text = Intent.GetStringExtra("phone");
            var idImage = (int)typeof(Resource.Drawable).GetField(Intent.GetStringExtra("photo")).GetValue(null);
            image.SetImageResource(idImage);
        }
    }
}