namespace FolderSync
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            notifyIcon1 = new NotifyIcon(components);
            contextMenuStripTray = new ContextMenuStrip(components);
            ExittoolStripMenuItem = new ToolStripMenuItem();
            richTextBox1 = new RichTextBox();
            argsWarningLabel = new Label();
            contextMenuStripTray.SuspendLayout();
            SuspendLayout();
            // 
            // notifyIcon1
            // 
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "FolderSync";
            notifyIcon1.Visible = true;
            notifyIcon1.MouseDoubleClick += notifyIcon1_MouseDoubleClick;
            // 
            // contextMenuStripTray
            // 
            contextMenuStripTray.Items.AddRange(new ToolStripItem[] { ExittoolStripMenuItem });
            contextMenuStripTray.Name = "contextMenuStrip1";
            contextMenuStripTray.Size = new Size(155, 26);
            // 
            // ExittoolStripMenuItem
            // 
            ExittoolStripMenuItem.Name = "ExittoolStripMenuItem";
            ExittoolStripMenuItem.Size = new Size(154, 22);
            ExittoolStripMenuItem.Text = "Exit FolderSync";
            ExittoolStripMenuItem.Click += ExittoolStripMenuItem_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = Color.FromArgb(64, 64, 64);
            richTextBox1.ForeColor = SystemColors.InactiveCaption;
            richTextBox1.Location = new Point(29, 27);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.ScrollBars = RichTextBoxScrollBars.Vertical;
            richTextBox1.Size = new Size(395, 570);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "";
            // 
            // argsWarningLabel
            // 
            argsWarningLabel.AutoSize = true;
            argsWarningLabel.BackColor = SystemColors.AppWorkspace;
            argsWarningLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            argsWarningLabel.ForeColor = Color.Yellow;
            argsWarningLabel.Location = new Point(507, 30);
            argsWarningLabel.Name = "argsWarningLabel";
            argsWarningLabel.Size = new Size(461, 21);
            argsWarningLabel.TabIndex = 2;
            argsWarningLabel.Text = "Warning! Valid arguments not found, waitig for arguments.";
            argsWarningLabel.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(1029, 630);
            Controls.Add(argsWarningLabel);
            Controls.Add(richTextBox1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            MaximumSize = new Size(1045, 669);
            MinimumSize = new Size(1045, 669);
            Name = "Form1";
            Text = "FolderSync";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            contextMenuStripTray.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NotifyIcon notifyIcon1;
        private ContextMenuStrip contextMenuStripTray;
        private ToolStripMenuItem ExittoolStripMenuItem;
        private RichTextBox richTextBox1;
        private Label argsWarningLabel;
    }
}