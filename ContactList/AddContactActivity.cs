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
    [Activity(Label = "Add Contact")]
    public class AddContactActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AddContact);
            // Create your application here
            FindViewById<Button>(Resource.Id.saveBttn).Click += OnSaveClick;
            FindViewById<Button>(Resource.Id.cancelBttn).Click += OnCancelClick;

            void OnSaveClick(object sender, EventArgs e)
            {
                string fName = FindViewById<EditText>(Resource.Id.firstNameInput).Text;
                string lName = FindViewById<EditText>(Resource.Id.lastNameInput).Text;
                int phoneNumber = int.Parse(FindViewById<EditText>(Resource.Id.phoneNoInput).Text);
                //wyjątki na puste pola dopisać

                var intent = new Intent();

                intent.PutExtra("ContactFName", fName);
                intent.PutExtra("ContactLName", lName);
                intent.PutExtra("PhoneNumber", phoneNumber);

                SetResult(Result.Ok, intent);
                Finish();
            }//Wyświetlanie nie działa w liście po dodaniu obiektu, problem tutaj

            void OnCancelClick(object sender, EventArgs e)
            {
                Finish();
            }

            /* Potwierdzenie CANCELa bez SAVEa
            async void OnAlertYesNoClicked(object sender, EventArgs e)
            {
                var answer = await DisplayAlert("Cancel?", "All data will be unsaved", "Yes", "No");
                Debug.WriteLine("Answer: " + answer);
            } */
        }
    }
}