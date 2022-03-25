
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectPart
{
    public class fragmentTwo : Fragment
    {
        TextView textViewOne, textViewTwo;
        ImageView imageViewOne, imageViewTwo;
        private DateFromPickerDialoguefragment dateFromPickerDialoguefragment;
        private DateToPickerDialoguefragment dateToPickerDialoguefragment;
        private readonly string _tag = "Main Activity";
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            View view = inflater.Inflate(Resource.Layout.WorkFromHomeLayout, container, false);
            imageViewOne =view.FindViewById<ImageView>(Resource.Id.imageViewFromCalender);
            textViewOne = view.FindViewById<TextView>(Resource.Id.textViewShowDateFrom);

            imageViewTwo = view.FindViewById<ImageView>(Resource.Id.imageViewToCalender);
            textViewTwo = view.FindViewById<TextView>(Resource.Id.textViewShowDateTo);

            ObjectCreation();
            BindEventofDateChange();

            imageViewOne.Click += FromDatePicker;
            imageViewTwo.Click += ToDatePicker;
           
            return view;
        }
        private void FromDatePicker(object sender, EventArgs e)
        {
            dateFromPickerDialoguefragment.Show(Activity.SupportFragmentManager, _tag);

        }

        private void ToDatePicker(object sender, EventArgs e)
        {
            dateToPickerDialoguefragment.Show(Activity.SupportFragmentManager, _tag);
        }


        private void ObjectCreation()
        {
            dateFromPickerDialoguefragment = new DateFromPickerDialoguefragment();
            dateToPickerDialoguefragment = new DateToPickerDialoguefragment();
        }
        private void BindEventofDateChange()
        {
            dateFromPickerDialoguefragment.OnDateChangeHandler += DatePickerDialoguefragment_FromDateChangeHandler;
            dateToPickerDialoguefragment.OnDateChangeHandler += DatePickerDialoguefragment_ToDateChangeHandler;
        }

        private void DatePickerDialoguefragment_FromDateChangeHandler(object sender, DateTime e)
        {
            textViewOne.Text = e.ToString(format: "dd/MM/yyyy");
        }
        private void DatePickerDialoguefragment_ToDateChangeHandler(object sender, DateTime e)
        {

            textViewTwo.Text = e.ToString(format: "dd/MM/yyyy");
        }
    }
}