using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLibrary
{
    public static class StringHelper
    {
        public static string StringLenghtChange(this string o, int lenght)
        {
            if (o.Length > lenght)
            {
                return o.Substring(0, lenght) + "...";
            }
            else
            {
                return o;
            }
        }
    }
}
