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
    class EndVotingCommand : ICommand
    {
        public string Title { get; set; }
        private VotingRepository votings;
        private IUIFactory factory;

        public EndVotingCommand(string commandName, IUIFactory factory, VotingRepository repo)
        {
            Title = commandName;
            this.factory = factory;
            votings = repo;
        }

        public void Execute()
        {
            var dialog = factory.CreateDialog("Select created voting", "Name");
            dialog.ResultsCreatedEvent += Dialog_ResultsCreatedEvent;
            dialog.Show();
        }

        private void Dialog_ResultsCreatedEvent(Dictionary<string, string> result)
        {
            if (votings.VotingDict.ContainsKey(result["Name"]))
            {
                Voting selectedVoting = votings.VotingDict[result["Name"]];
                selectedVoting.EndVoting();
            }
        }
    }
}
