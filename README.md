# FolderSync
FolderSync is a synchronization application that synchronizes a replica directory to be identical to a given source directory periodically.

## Selling Points
- User friendly interface
- User friendly flow
- Offers guidance for error solving
- Fast and reliable
- Remembers previously passed arguments
- GUI can be closed to run in background
- Gets the job done!

## FEATURES:
 - Periodic sync - happens at interval equal to given seconds
 - Logging - File and Folder creation/copy/delete operations are logged to file and to GUI console
 - Arguments - Command line arguments can be passed in several ways
   - Launching app through Command Prompt and passing arguments there
   - GUI - utilizing the user friendly GUI
   - Saved Arguments - Previous successfully used arguments are saved to file and reutilized if newly passed arguments are incorrect.
 - User friendly GUI - has a simple and easy to use GUI with log display and easy argument modifications.
## Technologies Used

C# programming Language<br>
Project type - Windows Forms Application<br>
IDE Visual Studio 2022 <br>
Target Framework .NET 6.0
## How to use

<b>If running from exe</b>
<br>
1. Run FolderSync.exe normally or as administrator. <br>
Because no arguments were given right away you will be prompted with the message box. Press ok:<br>
![Popup1](https://github.com/Thomas-Gabriel-Petcu/FolderSync/assets/73488732/05a2c11d-d65f-4ca2-a7ae-eb611d534213)
2. The application will search for previously saved arguments. Press ok:<br>
![Popup2](https://github.com/Thomas-Gabriel-Petcu/FolderSync/assets/73488732/c5f8711f-fee5-42be-8d0b-3afeb0cfbba7)
3. First time running there will be no saved arguments and this pop-up will appear. Press ok:<br>
![Popup3](https://github.com/Thomas-Gabriel-Petcu/FolderSync/assets/73488732/ca14a0e1-79b3-4aa4-977b-b063df905a68)
4. FolderSync will open GUI with empty fields for arguments and no console output:<br>
![No ArgumentsGUI](https://github.com/Thomas-Gabriel-Petcu/FolderSync/assets/73488732/c2f3d3ba-c8a5-48f0-b9e0-af7b123dfa2d)
5. Fill fields and click button "Re-run with new arguments"<br>
![AddedArguments](https://github.com/Thomas-Gabriel-Petcu/FolderSync/assets/73488732/51b0c00f-3324-463c-9588-7f307be288c6)
6. The application is now periodically syncing the two directories and outputing to log and console GUI.
![FolderSyncGUI](https://github.com/Thomas-Gabriel-Petcu/FolderSync/assets/73488732/7543095b-29bc-435c-99dd-c6c93085a90f)<br>
7. You can close the application with the X button in the top right corner and have it run in the background.
8. To terminate the application right click on the icon and click "Exit FolderSync"<br>
![Exit](https://github.com/Thomas-Gabriel-Petcu/FolderSync/assets/73488732/634735dc-5ca0-4f12-a8d9-28f9b015290e)

<br>
If running from Command Prompt<br>
Navigate to directory where FolderSync.exe is using "cd your-path-here"<br>
Use command "FolderSync.exe --help" to get the following help pop-up:
![screenshot](https://github.com/Thomas-Gabriel-Petcu/FolderSync/assets/73488732/44d808c6-e1a4-4735-8ead-f155c2c31dd3)
<br>
Use command "FolderSync.exe source replica interval log" as showin in help message to run the app with arguments.
