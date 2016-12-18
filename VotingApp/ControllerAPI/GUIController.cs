using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VotingApp.CommandAPI;

namespace VotingApp.ControllerAPI
{
    public partial class GUIController : Form, IController
    {
        public ICommandProcessor Processor { get; set; }
        private Dictionary<Button, ICommand> commandList = new Dictionary<Button, ICommand>();

        public GUIController()
        {
            InitializeComponent();
            Text = "Main Menu";
        }

        public void AddCommand(ICommand cm)
        {
            Button menuItem = new Button();
            menuItem.Text = cm.Title;
            menuItem.Dock = DockStyle.Bottom;
            menuItem.Click += MenuItem_Click;
            Controls.Add(menuItem);
            commandList.Add(menuItem, cm);
            Height = commandList.Count * 30;
        }

        private void MenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine(sender.ToString());
            var button = (Button)sender;
            var command = commandList[button];
            ExecCommand(command);
        }

        public void ExecCommand(ICommand cm)
        {
            Processor.ExecuteCommand(cm);
        }

        public void SetCommandProcessor(ICommandProcessor cp)
        {
            Processor = cp;
        }

        public void Start()
        {
            Application.Run(this);
        }

        public void AddCommands(IList<ICommand> cmList)
        {
            foreach(var command in cmList)
            {
                AddCommand(command);
            }
        }
    }
}
