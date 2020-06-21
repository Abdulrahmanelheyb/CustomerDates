; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "Customer Dates"
#define MyAppVersion "1.0"
#define MyAppPublisher "AE3, Inc."
#define MyAppURL "http://www.ae3.com/"
#define MyAppExeName "CustomerDates.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application. Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{F681A5BD-6498-49F1-92C8-10A54BD45945}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={autopf}\{#MyAppName}
DefaultGroupName={#MyAppName}
; Uncomment the following line to run in non administrative install mode (install for current user only.)
;PrivilegesRequired=lowest
OutputDir=C:\Users\abdul\Desktop\setup
OutputBaseFilename=Customer Dates
SetupIconFile=D:\My Documents\MyProjects\Developer\VS Sources\Solutions\C#\Windows Presentation Foundation\CustomerDates\CustomerDates\Assets\ICON_Windows_256x256.ico
Compression=lzma
SolidCompression=yes
WizardStyle=modern

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "D:\My Documents\MyProjects\Developer\VS Sources\Solutions\C#\Windows Presentation Foundation\CustomerDates\CustomerDates\bin\Debug\CustomerDates.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\My Documents\MyProjects\Developer\VS Sources\Solutions\C#\Windows Presentation Foundation\CustomerDates\CustomerDates\bin\Debug\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

