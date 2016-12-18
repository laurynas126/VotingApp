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
    class ShowOptionCommand : ICommand
    {
        public string Title { get; set; }
        private OptionRepository options;
        private IUIFactory factory;

        public ShowOptionCommand(string commandName, IUIFactory factory, OptionRepository repo)
        {
            Title = commandName;
            this.factory = factory;
            options = repo;
        }

        public void Execute()
        {
            var dialog = factory.CreateDialog("Select created option", "Name");
            dialog.ResultsCreatedEvent += Dialog_ResultsCreatedEvent;
            dialog.Show();
        }

        private void Dialog_ResultsCreatedEvent(Dictionary<string, string> result)
        {
            if (options.OptionDict.ContainsKey(result["Name"]))
            {
                Option selection = options.OptionDict[result["Name"]];
                var view = factory.CreateDataView();
                view.SetTitle(selection.Name);
                OptionAdapter adapter = new OptionAdapter();
                selection.AddObserver(adapter);
                adapter.Subscribe(view);
                var dict = new Dictionary<string, string>();
                dict["Data"] = selection.GetString();
                adapter.SetData(dict);
                view.Show();
            }
        }
    }
}
