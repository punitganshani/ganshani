using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace LuckyDraw.Web.Contracts
{
    [DataContract]
    public class LuckyDrawParticipants
    {
        [DataMember]
        public List<string> Names { get; set; }

        public LuckyDrawParticipants()
        {
            Names = new List<string>();
        }
    }
}