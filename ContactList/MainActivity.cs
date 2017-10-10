using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using System.Collections.Generic;

//https://developer.xamarin.com/recipes/android/fundamentals/

namespace ContactList
{
    [Activity(Label = "Contact List", MainLauncher = true)]
    public class MainActivity : Activity
    {
        public static List<Contact> Contacts = new List<Contact>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            Contacts.Add(new Contact("Tom", "Bien", 67854353));

            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            FindViewById<Button>(Resource.Id.addContact).Click += OnAddClick;
            FindViewById<Button>(Resource.Id.contactList).Click += OnContactListClick;
            FindViewById<Button>(Resource.Id.about).Click += OnAboutClick;      
        }

        void OnAddClick (object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(AddContactActivity));
            StartActivityForResult(intent, 100);
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

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
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