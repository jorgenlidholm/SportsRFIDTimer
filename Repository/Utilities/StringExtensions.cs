using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsRFIDTimer.Repository.Utilities
{
    public static class StringExtensions
    {
        public static string Fnuttify(this string str)
        {
            return String.Format("'{0}'", str);
        }
    }
}
