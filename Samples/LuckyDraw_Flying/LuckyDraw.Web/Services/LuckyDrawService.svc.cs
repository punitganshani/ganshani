using System;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Collections.Generic;
using LuckyDraw.Web.Contracts;

namespace LuckyDraw.Web.Services
{
    [ServiceContract(Namespace = "")]
    [SilverlightFaultBehavior]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class LuckyDrawService
    {
        [OperationContract]
        public LuckyDrawParticipants GetNames()
        {
            LuckyDrawParticipants participants = new LuckyDrawParticipants();

            for (int i = 0; i < 500; i++)
            {
                participants.Names.Add("Name " + i.ToString());
            }

            return participants;
        }
    }
}
