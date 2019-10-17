using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Refresh_The_Page.Utility
{
    public class Logger
    {
        public static void WriteError(Exception e)
        {
            Trace.WriteLine($"Message: {e.Message}");
            Trace.WriteLine($"Location: {e.Source}: {e.TargetSite}");
            Trace.WriteLine($"Data:");
            if (e.Data.Count > 0)
            {
                foreach(DictionaryEntry de in e.Data)
                {
                    Trace.WriteLine($"\t{de.Key.ToString()} : {de.Value}");
                }
            }
            Trace.WriteLine($"StackTrace: {e.StackTrace}");
        }
    }
}