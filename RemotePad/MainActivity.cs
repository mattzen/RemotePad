using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;
using Android.Views;

namespace RemotePad
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button touchpadbtn;
        Button sensorpadbtn;
        Button keyboardbbtn;
        EditText iptxt;
        EditText porttxt;
        TextView msglbl;
        Intent intent;
        //Connection con;
        SeekBar touchbar;
        SeekBar sensorbar;
        //SharedPreferences sharedPref;
        CheckBox wDYbox;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            //StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();

            //StrictMode.setThreadPolicy(policy);

            touchpadbtn = FindViewById<Button>(Resource.Id.button1);
            sensorpadbtn = FindViewById<Button>(Resource.Id.button2);
            keyboardbbtn = FindViewById<Button>(Resource.Id.button6);

            iptxt = FindViewById<EditText>(Resource.Id.editText1);
            porttxt = FindViewById<EditText>(Resource.Id.editText2);
            msglbl = FindViewById<TextView>(Resource.Id.textView2);


            touchbar = FindViewById<SeekBar>(Resource.Id.seekBar1);
            sensorbar = FindViewById<SeekBar>(Resource.Id.seekBar2);

            wDYbox = FindViewById<CheckBox>(Resource.Id.checkBox1);

            //Display display = getWindowManager().getDefaultDisplay();
            //Connection.screenwidth = display.getWidth();
            //Connection.screenheight = display.getHeight();

            //iptxt.setWidth((int)(Connection.screenwidth / 1.5));
            //porttxt.setWidth((int)(Connection.screenwidth - Connection.screenwidth / 1.5));

            ////option with motion in additional, third dimension(experimental)
            //wDYbox.setText("sensor: with DY");

            touchpadbtn.Click += Touchpadbtn_Click;

        }

        private void Touchpadbtn_Click(object sender, System.EventArgs e)
        {
            Connection.setconnect(iptxt.Text, int.Parse(porttxt.Text));
            intent = new Intent(this, typeof(TouchPadActivity));

            StartActivity(intent);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}