using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingApp.VotingSystemAPI
{
    interface IPollFactory
    {
        Voting CreateVoting(string title, int eligible);
        Option CreateOption(string title, string leaderName, int ballotNumber);
    }
}
