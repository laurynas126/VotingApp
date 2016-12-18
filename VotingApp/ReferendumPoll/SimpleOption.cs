using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.VotingSystemAPI;

namespace VotingApp.ReferendumPoll
{
    class SimpleOption : Option
    {
        private List<Observer> observers = new List<Observer>();
        public int BallotNumber
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public int Votes
        {
            get;
            set;
        }

        public SimpleOption(string name, int ballot)
        {
            Name = name;
            BallotNumber = ballot;
        }
        public string GetString()
        {
            return BallotNumber + ". " + Name;
        }

        public void Notify(NotifyData data)
        {
            if (data.IsOpen)
            {
                string choice = data.OptionName.ToLower();
                string thisName = Name.ToLower();
                if (choice.Equals(thisName) || BallotNumber == data.VotesReceived)
                {
                    if (data.ExtraData.Contains("UNDO"))
                    {
                        Votes -= data.VotesReceived;
                    }
                    else Votes += data.VotesReceived;
                    NotifyObservers(new NotifyData(data.IsOpen, BallotNumber, Name, data.VotesReceived, data.IsValidated, Votes, Name, -1, "I RECEIVED VOTES"));
                }
            }
            else NotifyObservers(new NotifyData(data.IsOpen, BallotNumber, Name, data.VotesReceived, data.IsValidated, Votes, Name, -1, "VOTING ENDED"));
        }

        public void AddObserver(Observer item)
        {
            observers.Add(item);
        }

        public void RemoveObserver(Observer item)
        {
            if (observers.Contains(item)) observers.Remove(item);
        }

        protected void NotifyObservers(NotifyData data)
        {
            foreach(var obs in observers)
            {
                obs.Notify(data);
            }
        }
    }
}
