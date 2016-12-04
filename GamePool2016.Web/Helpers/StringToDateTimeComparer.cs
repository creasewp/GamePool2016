using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamePool2016.Helpers
{
    internal class StringToDateTimeComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            DateTime datex;
            DateTime.TryParse(x, out datex);
            DateTime datey;
            DateTime.TryParse(y, out datey);

            return datex.CompareTo(datey);
        }
    }
}