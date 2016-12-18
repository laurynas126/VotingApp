using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingApp.VotingSystemAPI
{
    public abstract class Voting
    {
        public bool IsOpen { get; protected set; } = false;
        protected List<Observer> Observers { get; } = new List<Observer>();

        public int EligibleVoters { get; protected set; }
        public int TotalVotes { get; protected set; }
        protected NotifyData lastData;

        public void StartVoting()
        {
            if (!IsOpen)
            {
                IsOpen = true;
                lastData = new NotifyData(IsOpen, extra: "STARTED", eligible: EligibleVoters, total:TotalVotes);
                NotifyObservers(lastData);
            }
        }
        public void EndVoting()
        {
            if (!IsOpen)
            {
                return;
            }
            IsOpen = false;
            lastData = new NotifyData(IsOpen, validated: IsValidated(), total: TotalVotes, eligible: EligibleVoters, extra: "CLOSED");
            NotifyObservers(lastData);
        }
        public void NotifyObservers(int voteNum, string voteName, int votes)
        {
            lastData = new NotifyData(IsOpen, voteNum, voteName, votes, IsValidated(), TotalVotes);
            foreach (Observer o in Observers)
            {
                o.Notify(lastData);
            }
        }
        public void NotifyObservers(NotifyData data)
        {
            lastData = data;
            foreach (Observer o in Observers)
            {
                o.Notify(lastData);
            }
        }

        public void AddObserver(Observer obs)
        {
            Observers.Add(obs);
        }

        public void RemoveObserver(Observer obs)
        {
            if (Observers.Contains(obs)) Observers.Remove(obs);
        }

        public void AddVotes(int choiceNr, int votes)
        {
            AddVotes(choiceNr, "", votes);
        }
        public void AddVotes(string choiceTitle, int votes)
        {
            AddVotes(-1, choiceTitle, votes);
        }
        public abstract void AddVotes(int choiceNr, string choiceTitle, int votes);
        public abstract bool IsValidated();
        public abstract Memento SaveStateToMemento();
        public abstract void GetStateFromMemento(Memento data);
    }
}
