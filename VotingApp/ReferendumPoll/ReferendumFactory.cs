using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.VotingSystemAPI;

namespace VotingApp.ReferendumPoll
{
    class ReferendumFactory : IPollFactory
    {
        public Voting CreateVoting(string title, int eligible)
        {
            ReferendumVoting refVoting = new ReferendumVoting(title, eligible);
            return refVoting;
        }
        public Option CreateOption(string title, string leaderName, int ballotNumber)
        {
            SimpleOption op = new SimpleOption(title, ballotNumber);
            return op;
        }
    }
}
