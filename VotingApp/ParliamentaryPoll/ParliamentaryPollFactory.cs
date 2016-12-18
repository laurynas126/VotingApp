using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.VotingSystemAPI;

namespace VotingApp.ParliamentaryPoll
{
    class ParliamentaryPollFactory : IPollFactory
    {
        public Voting CreateVoting(string title, int eligible)
        {
            ParliamentaryVoting refVoting = new ParliamentaryVoting(title, eligible);
            return refVoting;
        }
        public Option CreateOption(string title, string leaderName, int ballotNumber)
        {
            PartyOption op = new PartyOption(title, ballotNumber, leaderName);
            return op;
        }
    }
}
