using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.VotingSystemAPI;

namespace VotingApp.ReferendumPoll
{
    class ReferendumVoting : Voting
    {
        private string _question;
        private const double minTurnout = 0.33;

        public ReferendumVoting(string question, int eligible)
        {
            _question = question;
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

        //Memento methods
        public override Memento SaveStateToMemento()
        {
            Memento createdMemento = new RefMemento((_question, IsOpen, EligibleVoters, TotalVotes, lastData));
            return createdMemento;
        }

        public override void GetStateFromMemento(Memento mementoState)
        {
            var state = ((RefMemento) mementoState).GetState();
            _question = state.title;
            IsOpen = state.isopen;
            EligibleVoters = state.eligible;
            TotalVotes = state.total;
            var mementoData = state.data;
            lastData = new NotifyData(IsOpen, mementoData.BallotNumber, mementoData.OptionName, mementoData.VotesReceived, IsValidated(), TotalVotes, _question, EligibleVoters, mementoData.ExtraData);
            NotifyObservers(mementoData);
        }
    }
}
