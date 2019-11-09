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

namespace RemotePad
{
    public static class Connection
    {
        public static int screenwidth = 0;
        public static int screenheight = 0;
        public static string ip;
        public static int port;
        public static DatagramPacket pout;
        public static DatagramSocket socket;
        public static byte[] buffer;
        public static bool connected = false;
        public static int BUFFER_SIZE = 16;
        public static int touchpadmultiplier = 1;
        public static int sensorpadmultiplier = 1;
        public static bool wDY = false;

        public static bool setconnect(String i, int p)
        {
            ip = i;
            port = p;
            return true;
        }
        public static bool disconnect()
        {
            if (connected)
            {
                socket.Close();
                connected = false;
            }
            return true;
        }
        public static bool isConnected()
        {
            return connected;
        }
        public static bool sendMove(int deltax, int deltay)
        {
            buffer = new byte[BUFFER_SIZE];
            string s = new String("e1:" + deltax + "," + deltay);
            buffer = Encoding.ASCII.GetBytes(s);

            try
            {
               // pout = new DatagramPacket(buffer, buffer.Length, new InetAddress(), port);

                try
                {

                    socket.Send(pout);
                    return true;
                }
                catch (IOException e)
                {
                    // TODO Auto-generated catch block
                    //e.StackTrace();
                    connected = false;
                    return false;
                }
            }
            catch (UnknownHostException e)
            {
                // TODO Auto-generated catch block
                //e.printStackTrace();
                connected = false;
                return false;
            }

        }
        public static bool sendrClick()
        {
            return false;
        }

        public static bool sendlClick()
        {
            return false;
        }

        public static bool sendScroll()
        {
            return false;
        }
    }
}