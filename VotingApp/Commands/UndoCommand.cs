using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.CommandAPI;

namespace VotingApp.Commands
{
    class UndoCommand : ICommand
    {

        private ICommandProcessor _processor;

        public UndoCommand(String title, ICommandProcessor processor)
        {
            Title = title;
            _processor = processor;
        }

        public string Title {get; set;}

        public void Execute()
        {
            _processor.UndoCommand();
        }
    }
}
