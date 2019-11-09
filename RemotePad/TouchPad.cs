using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Net;
using RemotePad;

namespace RemotePad
{
    public class TouchPad
    {
        public float xpos = 0;
        public float ypos = 0;

        public float deltax = 0;
        public float deltay = 0;

        public string str;

        public void setPos(float x, float y)
        {

            xpos = x;
            ypos = y;

        }

        bool posChanged(float x, float y)
        {
            if (xpos != x || ypos != y)
                return true;
            else
                return false;
        }
        public bool sendAction(String cl)
        {

            if (cl.Equals("lc"))
                str = "lc";
            else if (cl.Equals("rc"))
                str = "rc";
            else if (cl.Equals("mv"))
                str = (int)deltax * (Connection.touchpadmultiplier / 2) + "," + (int)deltay * (Connection.touchpadmultiplier / 2);
            else if (cl.Equals("dr"))
                str = "dr:" + (int)deltax + "," + (int)deltay;
            else if (cl.Equals("sc"))
                str = "sc:" + (int)deltay;
            else if (cl.Equals("bc"))
                str = "bc";
            else if (cl.Equals("fc"))
                str = "fc";


            Connection.buffer = new byte[16];
            //Connection.buffer = str.getBytes();

            if (!Connection.isConnected())
            {

                try
                {
                    Connection.socket = new DatagramSocket(Connection.port);
                    Connection.connected = true;
                }
                catch (SocketException e)
                {
                    // TODO Auto-generated catch block
//e.printStackTrace();
                }
            }

            try
            {
                //Connection.pout = 
                //    new DatagramPacket(Connection.buffer, Connection.buffer.length, InetAddress.getByName(Connection.ip), Connection.port);
            }
            catch (UnknownHostException e1)
            {
                // TODO Auto-generated catch block
               // e1.printStackTrace();
                return false;
            }

            try
            {


                //Connection.pout.setLength(Connection.buffer.length);
                //Connection.socket.send(Connection.pout);



            }
            catch (IOException e)
            {
                // TODO Auto-generated catch block
                //e.printStackTrace();
                return false;

            }
            return true;

        }


        public float getXpos()
        {
            return xpos;
        }


        public void setXpos(float xpos)
        {
            this.xpos = xpos;
        }


        public float getYpos()
        {
            return ypos;
        }


        public void setYpos(float ypos)
        {
            this.ypos = ypos;
        }


        public float getDeltax()
        {
            return deltax;
        }


        public void setDeltax(float deltax)
        {
            this.deltax = deltax;
        }


        public float getDeltay()
        {
            return deltay;
        }


        public void setDeltay(float deltay)
        {
            this.deltay = deltay;
        }

        public String getStr()
        {
            return str;
        }


        public void setStr(String str)
        {
            this.str = str;
        }


        public bool status()
        {
            return Connection.isConnected();
        }

    }
}