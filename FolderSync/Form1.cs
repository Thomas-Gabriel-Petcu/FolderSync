using System.Reflection.Metadata.Ecma335;
using System.IO;
using System.Security.Principal;
using System.Diagnostics;
using System;

namespace FolderSync
{
    public partial class Form1 : Form
    {
        string sourcePath = "";
        string replicaPath = "";
        int intervalSeconds = 0;
        string logPath = "";
        string savedArgsFilePath = "SavedArgs.txt";

        public Form1()
        {
            InitializeComponent();
            notifyIcon1.ContextMenuStrip = contextMenuStripTray;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Run();
        }
        #region MinimizeFunctionality
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }
        private void ExittoolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        public void Run()
        {
            if (!RanAsAdmin())
            {
                labelWarningAdmin.Visible = true;
            }
            if (!AttemptInitialization())
            {
                argsWarningLabel.Visible = true;
            }
            else
            {
                SyncManager.LogPath = logPath;
                System.Threading.Timer synctimer;
                var startSpan = TimeSpan.Zero;
                var periodSpan = TimeSpan.FromSeconds(intervalSeconds);
                synctimer = new System.Threading.Timer(SyncCallback, null, startSpan, periodSpan);
            }
        }
        private void SyncCallback(object state)
        {
            WriteLogToConsole();
            SyncManager.Sync(sourcePath, replicaPath);
        }

        public bool AttemptInitialization()
        {
            string[] args = Environment.GetCommandLineArgs();
            if (!ArgsProcessed(args))
            {
                string[] savedArgs = RetrieveSavedArgs();
                if (!(savedArgs.Length > 1))
                {
                    MessageBox.Show("No previously saved arguments could be retrieved!\n Application will open interface for arguments passing.");
                    return false;
                }
                ArgsProcessed(savedArgs);
                argsWarningLabel.Visible = false;
                textBoxSource.Text = sourcePath;
                textBoxReplica.Text = replicaPath;
                textBoxInterval.Text = intervalSeconds.ToString();
                textBoxLogPath.Text = logPath;
                MessageBox.Show($"Initialized with SAVED args\n {savedArgs[0]} \n {savedArgs[1]} \n {savedArgs[2]} \n {savedArgs[3]} \n {savedArgs[4]}");
                return true;
            }
            SaveArgs(args);
            argsWarningLabel.Visible = false;
            textBoxSource.Text = sourcePath;
            textBoxReplica.Text = replicaPath;
            textBoxInterval.Text = intervalSeconds.ToString();
            textBoxLogPath.Text = logPath;
            MessageBox.Show($"Initialized with args\n {args[0]} \n {args[1]} \n {args[2]} \n {args[3]} \n {args[4]}");
            return true;
        }
        private void SaveArgs(string[] args)
        {
            if (!ArgsValidation(args)) return; //Incorrect args format
            if (File.Exists(savedArgsFilePath))
            {
                File.Delete(savedArgsFilePath);
            }
            using (StreamWriter writer = File.CreateText(savedArgsFilePath))
            {
                foreach (string arg in args)
                {
                    writer.WriteLine(arg);
                }
            }
        }
        private string[] RetrieveSavedArgs()
        {
            MessageBox.Show("Searching for previously saved arguments");
            if (File.Exists(savedArgsFilePath))
            {
                //MessageBox.Show(savedArgsFilePath);
                string[] args = File.ReadAllLines(savedArgsFilePath);
                return args;
            }
            return new string[0];
        }
        private bool ArgsValidation(string[] args)
        {
            string errorMessage = "";
            if (!(args.Length > 1))
            {
                errorMessage += "Warning: no arguments found";
                MessageBox.Show(errorMessage);
                return false;
            }
            if (!Directory.Exists(args[1]))//First element is always executable so start at second
            {
                errorMessage += "Error: Given Source directory does not exist.\n";
            }
            if (!Directory.Exists(args[2]))
            {
                errorMessage += "Error: Given Replica directory does not exist.\n";
            }
            if (!int.TryParse(args[3], out int result) || result <= 0)
            {
                errorMessage += $"Error: Interval must be a positive whole number, not '{args[3]}'.\n";
            }
            if (!File.Exists(args[4]))
            {
                errorMessage += "Error: Given Log file does not exist.\n";
            }
            if (errorMessage != "")
            {
                MessageBox.Show(errorMessage);
                return false;
            }
            return true;
        }
        private bool ArgsProcessed(string[] args)
        {
            if (!ArgsValidation(args))
            {
                return false; //No need to output anything here the validation process already did
            }
            sourcePath = args[1];
            replicaPath = args[2];
            intervalSeconds = int.Parse(args[3]);//already tryParsed in validation.
            logPath = args[4];
            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string exeName = Environment.GetCommandLineArgs()[0];
            string source = textBoxSource.Text;
            string replica = textBoxReplica.Text;
            string interval = textBoxInterval.Text;
            string log = textBoxLogPath.Text;
            string[] args = { exeName, source, replica, interval, log };
            string constructedArgs = "";
            if (!ArgsProcessed(args))
            {
                return;
            }
            SaveArgs(args);
            constructedArgs = $"{source} {replica} {interval} {log}";
            argsWarningLabel.Visible = false;
            //MessageBox.Show($"Re-run with args\n {args[0]} \n {args[1]} \n {args[2]} \n {args[3]} \n {args[4]}");
            RunWithArguments(constructedArgs);
        }
        private bool RanAsAdmin()
        {
            WindowsIdentity user = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(user);

            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
        private void RunWithArguments(string args)
        {
            try
            {
                Process.Start(Application.ExecutablePath, args);
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        private void WriteLogToConsole()
        {
            richTextBox1.Clear();
            string[] lines = File.ReadAllLines(logPath);
            if (lines.Length <= 0) return;
            foreach (string line in lines)
            {
                richTextBox1.AppendText(line + Environment.NewLine);
            }
        }
    }
}