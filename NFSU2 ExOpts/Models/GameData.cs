using System;
using System.Runtime.Serialization;

namespace NFSU2_ExOpts.Models
{
    [DataContract]
    public class GameData
    {
        [DataMember]
        public ulong TimeInSec { get; private set; }
        [DataMember]
        public DateTime LastStartup { get; set; }

        public GameData()
        {
            TimeInSec = 0;
            LastStartup = DateTime.Now;
        }
        public GameData(int timeInSec, DateTime lastStartup)
        {
            TimeInSec = (ulong)timeInSec;
            LastStartup = lastStartup;
        }

        public void IncreaseTime(int timeInSec)
        {
            TimeInSec += (ulong)timeInSec;
        }
        public void SetLastStartup()
        {
            LastStartup = DateTime.Now;
        }
    }
}
