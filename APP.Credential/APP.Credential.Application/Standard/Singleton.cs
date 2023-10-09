﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using APP.Credential.Application.SMFLocation;


namespace APP.Credential.Application
{
    public class Singleton
    {
        private static Singleton instance = null;
        public IList<Location> Location { get; set; }
        public UserProfile userProfile { get; set; }


        private Singleton()
        {


        }

        private static object syncLock = new object();
        public static Singleton Instance
        {
            get
            {
                lock (syncLock)
                {
                    if (Singleton.instance == null)
                        Singleton.instance = new Singleton();
                    return Singleton.instance;
                }
            }
        }


    }
}
