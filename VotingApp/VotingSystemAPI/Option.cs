using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingApp.VotingSystemAPI
{
    public interface Option: Observer

    {
        string Name { get; set; }
        int BallotNumber { get; set; }
        int Votes { get; set; }

        string GetString();
        void AddObserver(Observer item);
        void RemoveObserver(Observer item);
    }
}
