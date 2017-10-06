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
    public class Contact
    {
        public Contact(string fname, string lname, int pnumber)
        {
            FName = fname;
            LName = lname;
            PNumber = pnumber;
        }

        public string FName { get; set; }
        public string LName { get; set; }
        public int PNumber { get; set; }

        public override string ToString()
        {
            return FName;
        }
    }
}