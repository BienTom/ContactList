using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace ContactList
{
    [Activity(Label = "Add Contact")]
    public class AddContactActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AddContact);
            
            FindViewById<Button>(Resource.Id.saveBttn).Click += OnSaveClick;
            FindViewById<Button>(Resource.Id.cancelBttn).Click += OnCancelClick;

            void OnSaveClick(object sender, EventArgs e)
            {
                string fname = FindViewById<EditText>(Resource.Id.firstNameInput).Text;
                string lname = FindViewById<EditText>(Resource.Id.lastNameInput).Text;
                int pnumber = int.Parse(FindViewById<EditText>(Resource.Id.phoneNoInput).Text);

                var intent = new Intent();

                intent.PutExtra("ContactFName", fname);
                intent.PutExtra("ContactLName", lname);
                intent.PutExtra("PhoneNumber", pnumber);

                SetResult(Result.Ok, intent);

                Finish();
            }

            void OnCancelClick(object sender, EventArgs e)
            {
                Finish();
            }
        }
    }
}