using System;
using System.Collections.Generic;
using System.Text;

namespace MedliClinic.Utilities.Utility
{
    public static class SystemFormat
    {
        public static string DateFormat()
        {
            return "MM/dd/yyyy";
        }


        public static string DateTimeFormat()
        {
            return "MM/dd/yyyy hh:mm tt";
        }

        public static string TimeFormat()
        {
            return "HH:mm";
        }
    }
}
