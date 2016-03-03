using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class Constants
    {
        public enum TimerType
        {
            TCU = 1,
            IHub = 2,
            Station = 3,
            Freeport = 4
        }

        public static string Translate(TimerType tt)
        {
            if (tt == TimerType.TCU)
                return "TCU";
            if (tt == TimerType.IHub)
                return "IHub";
            if (tt == TimerType.Station)
                return "Station";
            if (tt == TimerType.Freeport)
                return "Freeport";

            return "";
        }
    }
}
