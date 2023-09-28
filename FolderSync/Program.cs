using System.Drawing.Text;

namespace FolderSync
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Dictionary<string, string> options = new Dictionary<string, string>
        {
            { "SourcePath", "Source folder path." },
            { "ReplicaPath", "Replica folder path." },
            { "Interval", "Sync interval in seconds"},
            { "LogPath","Log file path"}
        };


            
            // Check if the "--help" option is provided
            if (args.Length > 0 && (args[0] == "--help" || args[0] == "-h"))
            {
                string append = "";
                foreach (KeyValuePair<string,string> pair in options)
                {
                    append += $"{pair.Key}, {pair.Value}\n";
                }
                MessageBox.Show("Commands are:\n " +
                    "FolderSync SourcePath ReplicaPath Interval LogPath\n" +
                    "--help or -h displays this message\n" +
                    "options are:\n" +
                    $"{append}");

                return;
            }

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}