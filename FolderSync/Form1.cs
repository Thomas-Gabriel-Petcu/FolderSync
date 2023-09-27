using System.Reflection.Metadata.Ecma335;
using System.IO;
namespace FolderSync
{
    public partial class Form1 : Form
    {
        private float timeIntervalInMinutes;
        System.Timers.Timer timer = new System.Timers.Timer();
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
            string[] args = Environment.GetCommandLineArgs();
            //if args are not correct notify the user
            //A) Previously saved args will be used instead (if they exist)
            //B) Application will run with a simple GUI for argument passing.
            //if args are correct continue using passed values and save args to file
            //foreach (string arg in args)
            //{
            //    MessageBox.Show($"{arg} with index {Array.IndexOf(args, arg)}");
            //}
            if (!ArgsProcessed(args))
            {
                string[] savedArgs = RetrieveSavedArgs();
                if (!(savedArgs.Length > 1))
                {
                    MessageBox.Show("No previously saved arguments could be retrieved!\n Application will open interface for arguments passing.");
                    //open a form for arguments passing.
                    return;
                }
                ArgsProcessed(savedArgs);
                return;
            }
            SaveArgs(args);

            //From this point on we can use the args for sync operations
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
            //MessageBox.Show(savedArgsFilePath);
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
                //MessageBox.Show($"Args length is {args.Length}");
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
                errorMessage += "Searching for previously saved arguments";
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
    }
}