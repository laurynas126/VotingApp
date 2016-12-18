using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.CommandAPI;

namespace VotingApp.Commands
{
    class CommandProcessor : ICommandProcessor
    {
        private Stack<ICommand> commandHistory = new Stack<ICommand>();
        public void ExecuteCommand(ICommand cm)
        {
            if (cm is IUndoable)
            {
                commandHistory.Push(cm);
            }
            cm.Execute();
        }

        public void UndoCommand()
        {
            if (commandHistory.Count == 0)
            {
                return;
            }
            IUndoable lastCommand = commandHistory.Pop() as IUndoable;
            if (lastCommand != null)
            {
                lastCommand.Undo();
            }
        }
    }
}
