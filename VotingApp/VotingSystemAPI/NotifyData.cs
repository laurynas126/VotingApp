using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingApp.VotingSystemAPI
{
    public class NotifyData
    {
        public string PollName { get; }
        public bool IsOpen { get; }
        public string OptionName { get; }
        public int BallotNumber { get; }
        public int VotesReceived { get; }
        public bool IsValidated { get; }
        public int TotalVoters { get; }
        public int EligibleVoters { get; }
        public string ExtraData { get; }

        public NotifyData(bool isOpen = true, 
            int number = -1, 
            string optionName = "", 
            int votes = -1, 
            bool validated = false, 
            int total = -1,
            string pollName ="",
            int eligible = -1, 
            string extra = "")
        {
            IsOpen = isOpen;
            BallotNumber = number;
            OptionName = optionName;
            VotesReceived = votes;
            IsValidated = validated;
            TotalVoters = total;
            EligibleVoters = eligible;
            PollName = pollName;
            ExtraData = extra;
        }
    }
}
