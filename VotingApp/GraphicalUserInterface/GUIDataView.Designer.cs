using System;
using VotingApp.UserInterfaceAPI;

namespace VotingApp.GraphicalUserInterface
{
    partial class GUIDataView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.title = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(32, 29);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(51, 20);
            this.title.TabIndex = 0;
            this.title.Text = "label1";
            // 
            // mainPanel
            // 
            this.mainPanel.Location = new System.Drawing.Point(36, 53);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(254, 216);
            this.mainPanel.TabIndex = 1;
            // 
            // GUIDataView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 292);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.title);
            this.Name = "GUIDataView";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Text = "GUIMainView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Panel mainPanel;
    }
}