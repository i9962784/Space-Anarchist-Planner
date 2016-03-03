using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SovEvent
    {
        public Constants.TimerType EventType;
        private string _SystemName;
        public int SystemID;
        public string ConstellationName;
        public int ConstellationID;
        private string _RegionName;
        public int RegionID;
        private string _OwnerName;
        public int OwnerID;
        private DateTime _EventStarts;
        public int DefenderScore;
        public int AttackerScore;


        public string EventTypeDescription
        {
            get
            {
                return Constants.Translate(EventType);
            }
        }

        public string SystemName
        {
            get { return _SystemName; }
            set { _SystemName = value; }
        }

        public string RegionName
        {
            get { return _RegionName; }
            set { _RegionName = value; }
        }


        public string OwnerName
        {
            get { return _OwnerName; }
            set { _OwnerName = value; }
        }

        public DateTime EventStarts
        {
            get { return _EventStarts; }
            set { _EventStarts = value; }
        }

    }


}
