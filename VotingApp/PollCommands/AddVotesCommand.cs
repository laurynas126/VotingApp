using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.CommandAPI;
using VotingApp.Repositories;
using VotingApp.UserInterfaceAPI;
using VotingApp.VotingSystemAPI;

namespace VotingApp.PollCommands
{
    class AddVotesCommand : ICommand, IUndoable
    {
        public string Title { get; set; }
        private VotingRepository votings;
        private IUIFactory factory;
        private IPollFactory pollFact;

        private Stack<(string, Memento)> votingObjectStates = new Stack<(string, Memento)>();
        public AddVotesCommand(string commandName, IUIFactory factory, IPollFactory pollFactory, VotingRepository voteRepo)
        {
            Title = commandName;
            this.factory = factory;
            pollFact = pollFactory;
            votings = voteRepo;
        }

        public void Execute()
        {
            var dialog = factory.CreateDialog("Enter voting name", "Name", "Ballot number", "Option name", "Vote count");
            dialog.ResultsCreatedEvent += Dialog_ResultsCreatedEvent;
            dialog.Show();
        }

        private void Dialog_ResultsCreatedEvent(Dictionary<string, string> result)
        {
            if (votings.VotingDict.ContainsKey(result["Name"]))
            {
                Voting selected = votings.VotingDict[result["Name"]];
                int ballot = -1;
                int votes = -1;
                if (int.TryParse(result["Ballot number"], out ballot) && int.TryParse(result["Vote count"], out votes))
                {
                    votingObjectStates.Push((result["Name"], selected.SaveStateToMemento()));
                    selected.AddVotes(ballot, result["Option name"], votes);
                }
            }
        }

        public void Undo()
        {
            if (votingObjectStates.Count != 0)
            {
                var lastCommand = votingObjectStates.Pop();
                var voting = votings.VotingDict[lastCommand.Item1];
                voting.GetStateFromMemento(lastCommand.Item2);
            }
            
        }
    }
}
