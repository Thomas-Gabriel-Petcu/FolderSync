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
            textBoxSource = new TextBox();
            textBoxReplica = new TextBox();
            button1 = new Button();
            textBoxInterval = new TextBox();
            textBoxLogPath = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            labelWarningAdmin = new Label();
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
            argsWarningLabel.Size = new Size(471, 21);
            argsWarningLabel.TabIndex = 2;
            argsWarningLabel.Text = "Warning! Valid arguments not found, waiting for arguments.";
            argsWarningLabel.Visible = false;
            // 
            // textBoxSource
            // 
            textBoxSource.BackColor = Color.FromArgb(64, 64, 64);
            textBoxSource.ForeColor = SystemColors.InactiveCaption;
            textBoxSource.Location = new Point(507, 126);
            textBoxSource.Name = "textBoxSource";
            textBoxSource.Size = new Size(461, 29);
            textBoxSource.TabIndex = 3;
            // 
            // textBoxReplica
            // 
            textBoxReplica.BackColor = Color.FromArgb(64, 64, 64);
            textBoxReplica.ForeColor = SystemColors.InactiveCaption;
            textBoxReplica.Location = new Point(507, 204);
            textBoxReplica.Name = "textBoxReplica";
            textBoxReplica.Size = new Size(461, 29);
            textBoxReplica.TabIndex = 4;
            // 
            // button1
            // 
            button1.Location = new Point(650, 520);
            button1.Name = "button1";
            button1.Size = new Size(180, 77);
            button1.TabIndex = 7;
            button1.Text = "Re-run with new arguments";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBoxInterval
            // 
            textBoxInterval.BackColor = Color.FromArgb(64, 64, 64);
            textBoxInterval.ForeColor = SystemColors.InactiveCaption;
            textBoxInterval.Location = new Point(507, 287);
            textBoxInterval.Name = "textBoxInterval";
            textBoxInterval.Size = new Size(461, 29);
            textBoxInterval.TabIndex = 8;
            // 
            // textBoxLogPath
            // 
            textBoxLogPath.BackColor = Color.FromArgb(64, 64, 64);
            textBoxLogPath.ForeColor = SystemColors.InactiveCaption;
            textBoxLogPath.Location = new Point(507, 364);
            textBoxLogPath.Name = "textBoxLogPath";
            textBoxLogPath.Size = new Size(461, 29);
            textBoxLogPath.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(685, 102);
            label1.Name = "label1";
            label1.Size = new Size(93, 21);
            label1.TabIndex = 10;
            label1.Text = "Source path";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(685, 180);
            label2.Name = "label2";
            label2.Size = new Size(95, 21);
            label2.TabIndex = 11;
            label2.Text = "Replica path";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.ButtonFace;
            label3.Location = new Point(666, 263);
            label3.Name = "label3";
            label3.Size = new Size(132, 21);
            label3.TabIndex = 12;
            label3.Text = "Execution interval";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.ButtonFace;
            label4.Location = new Point(685, 340);
            label4.Name = "label4";
            label4.Size = new Size(96, 21);
            label4.TabIndex = 13;
            label4.Text = "Log file path";
            // 
            // labelWarningAdmin
            // 
            labelWarningAdmin.AutoSize = true;
            labelWarningAdmin.BackColor = SystemColors.AppWorkspace;
            labelWarningAdmin.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            labelWarningAdmin.ForeColor = Color.Yellow;
            labelWarningAdmin.Location = new Point(442, 69);
            labelWarningAdmin.Name = "labelWarningAdmin";
            labelWarningAdmin.Size = new Size(575, 21);
            labelWarningAdmin.TabIndex = 14;
            labelWarningAdmin.Text = "Warning! No administrator priviledges. Cannot perform delete operations.";
            labelWarningAdmin.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(1029, 630);
            Controls.Add(labelWarningAdmin);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxLogPath);
            Controls.Add(textBoxInterval);
            Controls.Add(button1);
            Controls.Add(textBoxReplica);
            Controls.Add(textBoxSource);
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
        private TextBox textBoxSource;
        private TextBox textBoxReplica;
        private Button button1;
        private TextBox textBoxInterval;
        private TextBox textBoxLogPath;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label labelWarningAdmin;
    }
}