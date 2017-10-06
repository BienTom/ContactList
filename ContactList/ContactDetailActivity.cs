using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ContactList
{
    [Activity(Label = "ContactDetailActivity")]
    public class ContactDetailActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ContactDetail);

            int position = Intent.GetIntExtra("ItemPosition",-1);

            var item = MainActivity.Contacts[position];

            FindViewById<TextView>(Resource.Id.fnameTextView1).Text = "First name: " + item.FName;
            FindViewById<TextView>(Resource.Id.lnameTextView1).Text = "Last name: " + item.LName;
            FindViewById<TextView>(Resource.Id.numberTextView3).Text = "Phone: " + item.PNumber;

        }
    }
}