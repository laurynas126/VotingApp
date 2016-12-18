using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VotingApp.CommandAPI;
using VotingApp.Repositories;
using VotingApp.UserInterfaceAPI;
using VotingApp.VotingSystemAPI;

namespace VotingApp.PollCommands
{
    class CreatePollCommand : ICommand, IUndoable
    {
        public string Title { get; set; }
        private IUIFactory factory;
        private IPollFactory pollFactory;
        private VotingRepository repo;

        Stack<string> pollsHistory = new Stack<string>();
        public CreatePollCommand(IUIFactory uif, IPollFactory pollFactory, VotingRepository repository)
        {
            //if (name is null)
            //{
            //    Title = this.GetType().Name;
            //}
            Title = GetType().Name;
            factory = uif;
            this.pollFactory = pollFactory;
            repo = repository;
        }
        public void Execute()
        {
            var dialog = factory.CreateDialog(Title, "Poll name", "Eligible voters");
            dialog.ResultsCreatedEvent += GetResults;
            dialog.Show();
        }

        private void GetResults(Dictionary<string, string> results)
        {
            if (results != null)
            {
                string name = results["Poll name"];
                int eligibleNum = -1;
                int.TryParse(results["Eligible voters"], out eligibleNum);
                var voting = pollFactory.CreateVoting(name, eligibleNum);
                repo.VotingDict.Add(name, voting);
                pollsHistory.Push(name);
            }
        }

        public void Undo()
        {
            var lastPoll = pollsHistory.Pop();
            repo.VotingDict.Remove(lastPoll);
        }
    }
}
