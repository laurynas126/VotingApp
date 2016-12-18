using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VotingApp.UserInterfaceAPI;

namespace VotingApp.GraphicalUserInterface
{

    public partial class GUIDialog : Form, IUIDialog
    {
        public event resultsCreated ResultsCreatedEvent;

        private Dictionary<Label, TextBox> fieldList = new Dictionary<Label, TextBox>();
        public Dictionary<string, string> resultList = new Dictionary<string, string>();
        public GUIDialog()
        {
            InitializeComponent();
        }

        public void AddField(string fieldName)
        {
            FlowLayoutPanel panel = CreateElements(fieldName);
            panel.Dock = DockStyle.Bottom;
            panel.Padding = new Padding(5);
            this.Controls.Add(panel);
            this.Height = 70 + 30 * fieldList.Count;
        }

        public void SetTitle(string title)
        {
            this.Text = title;
        }

        //public void Show()
        //{
        //    this.Height = 60 * fieldList.Count;
        //    super();
        //    return;
        //}

        private FlowLayoutPanel CreateElements(string name)
        {
            FlowLayoutPanel container = new FlowLayoutPanel();
            Label key = new Label();
            key.Text = name;
            TextBox value = new TextBox()
            {
                Width = 200
            };
            container.Controls.Add(key);
            container.Controls.Add(value);
            container.Height = 30;
            fieldList.Add(key, value);
            return container;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach(var pair in fieldList)
            {
                resultList.Add(pair.Key.Text, pair.Value.Text);
            }
            ResultsCreatedEvent?.Invoke(resultList);
            Close();
            Dispose();
        }
    }
}
