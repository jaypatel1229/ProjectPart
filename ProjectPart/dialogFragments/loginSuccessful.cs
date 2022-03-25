
using Android.Content;

using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using Felipecsl.GifImageViewLibrary;
using System;

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ProjectPart.dialogFragments
{
    public class loginSuccessful : DialogFragment
    {
        public GifImageView myGIFImage;
        public ImageView myImageClose;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
           
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            View view = inflater.Inflate(Resource.Layout.login_successful, container, false);
            myGIFImage = view.FindViewById<GifImageView>(Resource.Id.gifImageView);
            myImageClose = view.FindViewById<ImageView>(Resource.Id.closeImageView);
            Stream input = Resources.OpenRawResource(Resource.Drawable.successfully);
            byte[] bytes = ConvertByteArray(input);
            myGIFImage.SetBytes(bytes);
            myGIFImage.StartAnimation();
            myImageClose.Click += MyImageClose_Click;
            return view;
           
        }

        private void MyImageClose_Click(object sender, EventArgs e)
        {
           this.Dismiss();
        }

        private byte[] ConvertByteArray(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                    ms.Write(buffer, 0, read);
                return ms.ToArray();
            }
        }
    }
}