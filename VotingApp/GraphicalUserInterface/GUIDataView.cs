using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VotingApp.UserInterfaceAPI;

namespace VotingApp.GraphicalUserInterface
{
    public partial class GUIDataView : Form, IUIDataView
    {
        public GUIDataView()
        {
            InitializeComponent();
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(List<string> value)
        {
            mainPanel.Controls.Clear();
            foreach(var str in value)
            {
                Label txt = new Label();
                txt.Text = str;
                txt.Dock = DockStyle.Bottom;
                mainPanel.Controls.Add(txt);
            }
        }

        public void SetData(Dictionary<string, string> data)
        {
            throw new NotImplementedException();
        }

        public void SetTitle(string title)
        {
            this.Text = title;
            this.title.Text = title;
        }

    }
}
