using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using RemotePad;

namespace RemotePad
{
    [Activity(Label = "TouchPadActivity")]
    public class TouchPadActivity : Activity
    {
        TextView tv;
        TouchPad tp;
        Button lc;
        Button rc;
        bool drag = false;
        LinearLayout lclickArea;
        LinearLayout rclickArea;
        LinearLayout scrollArea;
        LinearLayout forwardArea;
        LinearLayout backArea;
        LinearLayout moveArea;
        static int singleclick = 0;

        static int tempid = 0;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.touch_pad_layout);
            // Create your application here

            tp = new TouchPad();

            lclickArea = FindViewById<LinearLayout>(Resource.Id.lclickArea);
            forwardArea = FindViewById<LinearLayout>(Resource.Id.forwardArea);
            scrollArea = FindViewById<LinearLayout>(Resource.Id.scrollArea);
            backArea = FindViewById<LinearLayout>(Resource.Id.backArea);
            rclickArea = FindViewById<LinearLayout>(Resource.Id.rclickArea);
            moveArea = FindViewById<LinearLayout>(Resource.Id.moveArea);

            lclickArea.SetBackgroundColor(Color.Black);
            forwardArea.SetBackgroundColor(Color.Red);
            scrollArea.SetBackgroundColor(Color.Gray);
            backArea.SetBackgroundColor(Color.Red);
            rclickArea.SetBackgroundColor(Color.Black);
            moveArea.SetBackgroundColor(Color.White);

            moveArea.Touch += MoveArea_Touch;
            lclickArea.Touch += LeftArea_Touch;
        }

        public void MoveArea_Touch(object s, View.TouchEventArgs e)
        {
            if (e.Event.Action == MotionEventActions.Down)
            {
                tp.setPos(e.Event.GetX(), e.Event.GetY());
            }
        }

        public void LeftArea_Touch(object s, View.TouchEventArgs e)
        {
            if (e.Event.Action == MotionEventActions.Down)
            {
                tp.setPos(e.Event.GetX(), e.Event.GetY());
            }
        }
    }
}