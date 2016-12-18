using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingApp.CommandAPI
{
    public interface ICommandProcessor
    {
        void ExecuteCommand(ICommand cm);
        void UndoCommand();
    }
}
