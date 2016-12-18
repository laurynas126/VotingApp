using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.CommandAPI;

namespace VotingApp.ControllerAPI
{
    interface IController
    {
        void SetCommandProcessor(ICommandProcessor cp);
        void ExecCommand(ICommand cm);
        void AddCommand(ICommand cm);
        void AddCommands(IList<ICommand> cmList);
        void Start();
    }
}
