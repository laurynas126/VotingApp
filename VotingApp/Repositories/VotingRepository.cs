using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.VotingSystemAPI;

namespace VotingApp.Repositories
{
    public class VotingRepository
    {
        public Dictionary<string, Voting> VotingDict { get; }
        public VotingRepository()
        {
            VotingDict = new Dictionary<string, Voting>();
        }
    }
}
