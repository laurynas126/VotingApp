using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.VotingSystemAPI;

namespace VotingApp.ParliamentaryPoll
{
    class ParliamentaryVoting : Voting
    {

        private string _title;
        private const double minTurnout = 0.25;
        public ParliamentaryVoting(string title, int eligible)
        {
            _title = title;
            EligibleVoters = eligible;
        }

        public override void AddVotes(int choiceNr, string choiceTitle, int votes)
        {
            if (!IsOpen)
            {
                return;
            }
            if (TotalVotes + votes <= EligibleVoters)
            {
                TotalVotes += votes;
                var data = new NotifyData(number: choiceNr, optionName: choiceTitle, votes: votes, total: TotalVotes, eligible: EligibleVoters, validated: IsValidated());
                NotifyObservers(data);
            }
            else
            {
                EndVoting();
            }
            
        }

        public override bool IsValidated()
        {
            return ((double)TotalVotes / (double)EligibleVoters > minTurnout);
        }

        public override Memento SaveStateToMemento()
        {
            Memento generated = new ParliamentaryMemento((_title, IsOpen, EligibleVoters, TotalVotes, lastData));
            return generated;
        }

        public override void GetStateFromMemento(Memento mementoState)
        {
            var state = ((ParliamentaryMemento)mementoState).GetState();
            _title = state.title;
            IsOpen = state.isopen;
            EligibleVoters = state.eligible;
            TotalVotes = state.total;
            var mementoData = state.data;
            lastData = new NotifyData(IsOpen, mementoData.BallotNumber, mementoData.OptionName, mementoData.VotesReceived, IsValidated(), TotalVotes, _title, EligibleVoters, mementoData.ExtraData + " UNDO");
            NotifyObservers(lastData);
        }
    }
}
