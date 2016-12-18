using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.CommandAPI;

namespace VotingApp.ControllerAPI
{
    class CLIController : IController
    {
        private ICommandProcessor processor;
        private List<ICommand> commandList = new List<ICommand>();

        public void AddCommand(ICommand cm)
        {
            commandList.Add(cm);
        }

        public void ExecCommand(ICommand cm)
        {
            processor.ExecuteCommand(cm);
        }

        public void SetCommandProcessor(ICommandProcessor cp)
        {
            processor = cp;
        }

        public void Start()
        {
            int choice = -1;
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("---------Main Menu----------");
                int index = 1;
                foreach(var command in commandList)
                {
                    Console.WriteLine(index + ". " + command.Title);
                    index++;
                }
                Console.WriteLine(index + ". Exit");
                Console.WriteLine("-----------------------------");
                Console.WriteLine();
                int.TryParse(Console.ReadLine(), out choice);
                if (choice < index && choice > 0)
                {
                    ExecCommand(commandList.ElementAt(choice - 1));
                }
                else if (choice == index)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect input");
                }

            }
        }

        public void AddCommands(IList<ICommand> cmList)
        {
            foreach (var command in cmList)
            {
                AddCommand(command);
            }
        }
    }
}
