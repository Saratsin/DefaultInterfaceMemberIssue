using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using DefaultInterfaceMemberIssueLibrary;

namespace DefaultInterfaceMemberIssueSampleMin24
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            using var textView = FindViewById<TextView>(Resource.Id.text_view);

            CheckListenerMethods(out var errorsText);
            if (string.IsNullOrEmpty(errorsText))
            {
                return;
            }

            textView.Text = errorsText;
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void CheckListenerMethods(out string errorsText)
        {
            errorsText = string.Empty;
            try
            {
                ListenersChecker.CheckListenerMethodsFromJavaWorld();
            }
            catch (Exception ex)
            {
                errorsText += $"1. {ex.Message}";
            }
            
            try
            {
                ListenersChecker.CheckListenerMethodsFromCSharpWorld();
            }
            catch (Exception ex)
            {
                errorsText += $"\n2. {ex.Message}";
            }
        }
    }
}
