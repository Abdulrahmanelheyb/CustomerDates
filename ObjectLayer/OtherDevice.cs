﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectLayer
{
    public class OtherDevice : Device
    {
        public OtherDevice()
        {

        }
        public static List<OtherDevice> OtherDevices = new List<OtherDevice>();
        public static List<string> ExternalsTypes = new List<string>();

        public string Externals { get; set; }


        



    }
}
