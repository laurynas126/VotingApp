using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.Adapters;
using VotingApp.CommandAPI;
using VotingApp.Repositories;
using VotingApp.UserInterfaceAPI;
using VotingApp.VotingSystemAPI;

namespace VotingApp.PollCommands
{
    class ShowVotingCommand : ICommand
    {
        public string Title { get; set; }
        private VotingRepository votings;
        private IUIFactory factory;

        public ShowVotingCommand(string commandName, IUIFactory factory, VotingRepository repo)
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
                var view = factory.CreateDataView();
                VotingAdapter adapter = new VotingAdapter();
                selectedVoting.AddObserver(adapter);
                adapter.Subscribe(view);
                view.SetTitle(result["Name"]);
                var dict = new Dictionary<string, string>();
                dict["Has Started"] = selectedVoting.IsOpen.ToString();
                dict["Total Votes"] = selectedVoting.TotalVotes.ToString();
                dict["Eligible Voters"] = selectedVoting.EligibleVoters.ToString();
                adapter.SetData(dict);
                view.Show();

            }
        }
    }
}
