using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.Fragment.App;
using AndroidX.ViewPager.Widget;
using Felipecsl.GifImageViewLibrary;
using Google.Android.Material.Tabs;
using Java.Lang;
using ProjectPart.dialogFragments;
using System;
using ActionBar = Android.App.ActionBar;


namespace ProjectPart
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        public TabLayout _mytabLayout;
        public TextView _mytextView;
        public FrameLayout frameLayout;
        public ImageView _myImage;
        public Button _myApplyButton;
        public GifImageView myGIFImage;

        AndroidX.Fragment.App.Fragment fragment;
        AndroidX.Fragment.App.Fragment fragment1;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.ApplyLeave);

            _mytabLayout = FindViewById<TabLayout>(Resource.Id.tabLayout);
            _myApplyButton = FindViewById<Button>(Resource.Id.applyButton);
            //myGIFImage = FindViewById<GifImageView>(Resource.Id.myGIFImage);
            //_mytabLayout.TabSelected += _myTabSelected;
            UIReferences();
            UIClick();

            setTabName();
            fragment1 = new fragmentOne();
            SupportFragmentManager.BeginTransaction().Replace(Resource.Id.frameLayoutEx, fragment1).Commit();
            _mytabLayout.TabSelected += (object sender, TabLayout.TabSelectedEventArgs e) =>
            {
                AndroidX.Fragment.App.Fragment fragment = null;
                var tab = e.Tab;
               
                switch (tab.Position)
                {
                    case 0:
                        fragment = new fragmentOne();
                        break;
                    case 1:
                        fragment = new fragmentTwo();
                        break;
                }
                SupportFragmentManager.BeginTransaction().Replace(Resource.Id.frameLayoutEx, fragment).Commit();
             
            };

        }
        private void setTabName()
        {
            _mytabLayout.AddTab(_mytabLayout.NewTab().SetText(Resource.String.leave));
            _mytabLayout.AddTab(_mytabLayout.NewTab().SetText(Resource.String.workFromHome));

        }

        private void UIReferences()
        {
            _myImage = FindViewById<ImageView>(Resource.Id.imageViewBack);
            
        }

        private void UIClick()
        {
            _myImage.Click += Back_Click;
            _myApplyButton.Click += _myApplyButton_Click;
        }

        private void _myApplyButton_Click(object sender, EventArgs e)
        {
            loginSuccessful loginFrag = new loginSuccessful();
            var frag = SupportFragmentManager.BeginTransaction();
            loginFrag.Cancelable = false;
            loginFrag.Show(frag, "loginFrag");

            /* myGIFImage= FindViewById<GifImageView>(Resource.Id.myGIFImage);
    // From Drawable
                Stream input = Resources.OpenRawResource(Resource.Drawable.loading);
                
                // You should convert the "input" into Byte Array 
                byte[] bytes = ConvertByteArray(input);
                
                myGIFImage.SetBytes(bytes);
                myGIFImage.StartAnimation();
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
                }*/
        }

        private void Back_Click(object sender, EventArgs e)
        {
            //Intent i = new Intent(this,typeof());
            //StartActivity(i);
        }

        
    }
}