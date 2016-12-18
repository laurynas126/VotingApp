using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.VotingSystemAPI;

namespace VotingApp.ReferendumPoll
{
    public class RefMemento : Memento
    {
        private (string title, bool isopen, int eligible, int total, NotifyData data) state;
        public RefMemento((string title, bool isopen, int eligible, int total, NotifyData data) newState)
        {
            state = newState;
        }

        public (string title, bool isopen, int eligible, int total, NotifyData data) GetState()
        {
            return state;
        }
    }
}
