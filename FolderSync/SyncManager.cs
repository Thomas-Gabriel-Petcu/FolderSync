using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FolderSync
{
    public static class SyncManager
    {
        public static string LogPath
        {
            get { return LogPath; }
            set { LogPath = value; }
        }
        /// <summary>
        /// Executes necessary code for directory sync.
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="replicaPath"></param>
        public static void Sync(string sourcePath, string replicaPath)
        {
            //Create relative folder paths from source paths for replica folder
            //This is to check for files created in source that do not yet exist in replica
            List<string> sourceSubDirs = GetSubdirectoryPaths(sourcePath);
            List<string> replicaSubDirs = GetSubdirectoryPaths(replicaPath);
            foreach (string dir in sourceSubDirs)
            {
                string relativeDir = GetPathRelativeToFolder(dir, sourcePath, replicaPath);
                if (!replicaSubDirs.Contains(relativeDir))
                {
                    Directory.CreateDirectory(relativeDir);
                    //LOG CREATION OF DIRECTORY
                    OutputToLog($"CREATED {Path.GetFileName(relativeDir)} Folder at system Date/Time: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}", LogPath);
                }
            }
            //Create relative folder paths from replica paths for source folder
            //This is to check for files deleted from source that still exist in replica and should be deleted
            foreach (string dir in replicaSubDirs)
            {
                string relativeDir = GetPathRelativeToFolder(dir, replicaPath, sourcePath);
                if (!sourceSubDirs.Contains(relativeDir))
                {
                    //LOG DELETION OF FOLDER
                    try
                    {
                        Directory.Delete(relativeDir);
                        // LOG FILE DELETE
                        OutputToLog($"DELETED {Path.GetFileName(relativeDir)} Folder at " +
                        $"system Date/Time: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}", LogPath);
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        //LOG DELETION ERROR
                        OutputToLog($"ERROR {ex}", LogPath);
                    }
                }
            }
            //Get all file paths in source
            List<string> sourceFilePaths = GetFilePaths(sourcePath);

            //Get all file paths in replica
            List<string> replicaFilePaths = GetFilePaths(replicaPath);

            //Create relative file paths from source paths for replica folder
            //This is to check for files created in source that do not yet exist in replica
            foreach (string sourceFilePath in sourceFilePaths)
            {
                string relative = GetPathRelativeToFolder(sourceFilePath, sourcePath, replicaPath);
                if (!File.Exists(relative))//create it
                {
                    File.Copy(sourceFilePath, relative);
                    //LOG COPY OF FILE
                    OutputToLog($"COPIED {Path.GetFileName(Path.GetFileName(sourceFilePath))} File at " +
                    $"system Date/Time: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} to destination {relative}", LogPath);
                }
                //If it exists, compare to see if they're the same
                using (var sourceStream = new FileStream(sourceFilePath, FileMode.Open))
                using (var replicaStream = new FileStream(relative, FileMode.OpenOrCreate))
                {
                    using (MD5 md5 = MD5.Create())
                    {
                        byte[] sourceHashBytes = md5.ComputeHash(sourceStream);
                        byte[] replicaHashBytes = md5.ComputeHash(replicaStream);

                        sourceStream.Close();
                        replicaStream.Close();
                        if (!CompareByteArrays(sourceHashBytes, replicaHashBytes))
                        {
                            File.Copy(sourceFilePath, relative, true);
                            //LOG FILE COPY
                            OutputToLog($"COPIED {Path.GetFileName(Path.GetFileName(sourceFilePath))} File at " +
                             $"system Date/Time: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} to destination {relative}", LogPath);
                        }
                    }
                }
            }

            //Create relative file paths from replica paths for source folder
            //This is to check for files deleted from source that still exist in replica
            foreach (string replicaFilePath in replicaFilePaths)
            {
                string relative = GetPathRelativeToFolder(replicaFilePath, replicaPath, sourcePath);
                if (!File.Exists(relative))
                {
                    try
                    {
                        File.Delete(replicaPath);
                        // LOG FILE DELETE
                        OutputToLog($"DELETED {Path.GetFileName(replicaPath)} Folder at " +
                        $"system Date/Time: {DateTime.Now:yyyy-MM-dd HH:mm:ss}", LogPath);
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        //LOG DELETION ERROR
                        OutputToLog($"ERROR {ex}", LogPath);
                    }
                }
            }
        }
        private static bool CompareByteArrays(Byte[] array1, Byte[] array2)
        {
            if (array1.Length != array2.Length) return false; //should be impossible though as MD5 returns an array of 16 Bytes
            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i]) return false;
            }
            return true;
        }

        /// <summary>
        /// Gets a list of all file paths in directory and subdirectories.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private static List<string> GetFilePaths(string path)
        {
            List<string> filePaths = new List<string>();
            string[] files =  Directory.GetFiles(path);
            filePaths.AddRange(files);
            string[] subdirectories = Directory.GetDirectories(path);
            foreach (string subdirectory in subdirectories) 
            {
                List<string> subFilePaths = GetFilePaths(subdirectory);
                filePaths.AddRange(subFilePaths);
            }
            return filePaths;
        }
        /// <summary>
        /// Gets a list of all subdirectory paths.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private static List<string> GetSubdirectoryPaths(string path)
        {
            List<string> directoryPaths = new List<string>();
            string[] dirs = Directory.GetDirectories(path);
            directoryPaths.AddRange(dirs);
            int index = 0;
            while (index < directoryPaths.Count)
            {
                string directory = directoryPaths[index];
                List<string> subDirPaths = GetSubdirectoryPaths(directory);
                directoryPaths.AddRange(subDirPaths);
                index++;
            }
            return directoryPaths;
        }

        /// <summary>
        /// Appends given string to log file, if log file exists.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="logFilePath"></param>
        public static void OutputToLog(string text, string logFilePath)
        {
            if (!File.Exists(logFilePath))
            {
                MessageBox.Show($"No log file found at {logFilePath}");
                return;
            }
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine(text);
            }
        }

        /// <summary>
        /// Returns a path of given directory, relative to replica, instead of relative to source directory.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="sourceDir"></param>
        /// <param name="replicaDir"></param>
        /// <returns></returns>
        private static string GetPathRelativeToFolder(string path, string sourceDir ,string replicaDir)
        {
            string result = replicaDir;
            string sourceDirName = Path.GetFileName(sourceDir);
            int sourceNameIndex = path.IndexOf(sourceDirName);
            if (sourceNameIndex >= 0) //shouldn't really ever be a negative value?
            {
                result += "\\";
                result += path.Substring(sourceNameIndex + sourceDirName.Length);
            }
            return result;
        }
    }
}