using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace ContactList
{
    [Activity(Label = "ContactListActivity")]
    public class ContactListActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ContactList);

            var lv = FindViewById<ListView>(Resource.Id.listView1);
            lv.Adapter = new ArrayAdapter<Contact>(this, Android.Resource.Layout.SimpleListItem1, Android.Resource.Id.Text1, MainActivity.Contacts);

            lv.ItemClick += OnItemClick;

        void OnItemClick (object sender, AdapterView.ItemClickEventArgs e)
            {
                int position = e.Position; //e.Position = position in the list of contact user touched
                var intent = new Intent(this, typeof(ContactDetailActivity));

                intent.PutExtra("ContactPosition", position);
                StartActivity(intent);
            }
            
        }
    }
}