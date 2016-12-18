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
    class AddOptionCommand : ICommand, IUndoable
    {
        public string Title { get; set; }
        private VotingRepository votings;
        private OptionRepository options;
        private IUIFactory factory;
        private IPollFactory pollFact;

        private Stack<(Voting, Option)> eventHistory = new Stack<(Voting,Option)>();
        public AddOptionCommand(string commandName, IUIFactory factory, IPollFactory pollFactory, VotingRepository voteRepo, OptionRepository optRepo)
        {
            Title = commandName;
            this.factory = factory;
            pollFact = pollFactory;
            votings = voteRepo;
            options = optRepo;
        }

        public void Execute()
        {
            var dialog = factory.CreateDialog("Enter required data", "Voting title", "Option title", "Ballot number", "Leader name(Optional)");
            dialog.ResultsCreatedEvent += Dialog_ResultsCreatedEvent;
            dialog.Show();
        }

        private void Dialog_ResultsCreatedEvent(Dictionary<string, string> result)
        {
            if (votings.VotingDict.ContainsKey(result["Voting title"]))
            {
                int number = -1;
                int.TryParse(result["Ballot number"], out number);
                Voting selectedVoting = votings.VotingDict[result["Voting title"]];
                Option opt = pollFact.CreateOption(result["Option title"], result["Leader name(Optional)"], number);
                options.OptionDict.Add(result["Option title"], opt);
                selectedVoting.AddObserver(opt);
                eventHistory.Push((selectedVoting, opt));
            }
        }

        public void Undo()
        {
            if (eventHistory.Count != 0)
            {
                var lastExec = eventHistory.Pop();
                lastExec.Item1.RemoveObserver(lastExec.Item2);
                options.OptionDict.Remove(lastExec.Item2.Name);
            }
        }
    }
}
