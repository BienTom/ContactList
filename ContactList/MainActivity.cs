using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using System.Collections.Generic;
using Android.Runtime;

namespace ContactList
{
    [Activity(Label = "ContactList", MainLauncher = true)]
    public class MainActivity : Activity
    {
        public static List<Contact> Contacts = new List<Contact>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Contacts.Add(new Contact("Tom", "Bien", 67854353));

            FindViewById<Button>(Resource.Id.addContact).Click += OnAddClick;
            FindViewById<Button>(Resource.Id.contactList).Click += OnContactListClick;
            FindViewById<Button>(Resource.Id.about).Click += OnAboutClick;
        }

        void OnAddClick (object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(AddContactActivity));
            StartActivity(intent);
        }

        void OnContactListClick(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(ContactListActivity));
            StartActivity(intent);
        }

        void OnAboutClick(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(AboutActivity));
            StartActivity(intent);
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            if (requestCode == 100 && resultCode == Result.Ok)
            {
                string fname = data.GetStringExtra("ContactFName");
                string lname = data.GetStringExtra("ContactLName");
                int phonenumber = data.GetIntExtra("PhoneNumber", -1);

                Contacts.Add(new Contact(fname, lname, phonenumber));
            }
        }
    }
}

