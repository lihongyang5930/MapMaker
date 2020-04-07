using System;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace MindOne.Core.Services
{
    public class DialogService
    {
        string _openDialogTitle;
        string _saveDialogTitle;
        string _defaultDirectory;
        string _messageBoxTitle;
        public DialogService(string messageBoxTitle, string openTitle, string saveTitle, string defaultDirectory)
        {
            _messageBoxTitle  = messageBoxTitle;
            _openDialogTitle  = openTitle;
            _saveDialogTitle  = saveTitle;
            _defaultDirectory = defaultDirectory;
        }

        public DialogResult ShowMessageBox(string text)
        {
            return MessageBox.Show(text, _messageBoxTitle);
        }
        public DialogResult ShowMessageBox(string text, MessageBoxButtons buttons)
        {
            return MessageBox.Show(text, _messageBoxTitle, buttons);
        }
        public DialogResult ShowMessageBox(string text, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return MessageBox.Show(text, _messageBoxTitle, buttons, icon);
        }

        public string OpenFolder()
        {
            return CreateOpenFileDialog().ToFolderDialog().GetPath();
        }
        public string[] OpenFolders()
        {
            return CreateOpenFileDialog().ToFolderDialog().GetPaths();
        }

        public string OpenShapeFile()
        {
            return CreateShapeFileDialog().GetPath();
        }
        public string[] OpenShapeFiles()
        {
            return CreateShapeFileDialog().GetPaths();
        }

        public string OpenDrPipeProject()
        {
            return CreateOpenFileDialog()
                        .WithFilter("Dr.Pipe Project File", "*.dpf")
                        .ToFileDialog()
                        .GetPath();
        }
        public string SaveDrPipeProject(string defaultFileName = null)
        {
            return CreateSaveFileDialog(null, defaultFileName)
                        .WithFilter("Dr.Pipe Project File", "*.dpf")
                        .GetPath();
        }

        public string OpenPattern()
        {
            return CreateOpenFileDialog()
                        .WithFilter("EPANET Pattern File", "*.pat")
                        .ToFileDialog()
                        .GetPath();
        }
        public string SavePattern(string defaultFileName = null)
        {
            return CreateSaveFileDialog(null, defaultFileName)
                        .WithFilter("EPANET Pattern File", "*.pat")
                        .GetPath();
        }

        public string SaveTextFile(string defaultFileName = null)
        {
            return CreateSaveFileDialog(null, defaultFileName)
                        .WithFilter("텍스트 문서", "txt")
                        .GetPath();
        }

        public string OpenXlsx()
        {
            return CreateOpenFileDialog()
                        .WithFilter("Excel File", "*.xlsx")
                        .ToFileDialog()
                        .GetPath();
        }
        public string SaveXlsx(string defaultFileName = null)
        {
            return CreateSaveFileDialog(null, defaultFileName)
                        .WithFilter("Excel File", "*.xlsx")
                        .GetPath();
        }

        public string OpenInpFile()
        {
            return CreateOpenFileDialog()
                        .WithFilter("EPANET inp파일", "*.inp")
                        .ToFileDialog()
                        .GetPath();
        }
        public string SaveInpFile(string defaultFileName = null)
        {
            return CreateSaveFileDialog(null, defaultFileName)
                        .WithFilter("EPANET inp파일", "*.inp")
                        .GetPath();
        }

        private CommonOpenFileDialog CreateShapeFileDialog()
        {
            return CreateOpenFileDialog()
                        .WithFilter("ESRI Shapefile", "*.shp")
                        .ToFileDialog();
        }
        private CommonOpenFileDialog CreateOpenFileDialog(string title = null)
        {
            var dialog = new CommonOpenFileDialog
            {
                Title = title ?? _openDialogTitle,
                RestoreDirectory = true,
                IsFolderPicker = false,
                DefaultDirectory = _defaultDirectory,
                AddToMostRecentlyUsedList = false,
                AllowNonFileSystemItems = false,
                EnsureFileExists = true,
                EnsurePathExists = true,
                EnsureReadOnly = false,
                EnsureValidNames = true,
                Multiselect = true,
                ShowPlacesList = true
            };
            return dialog;
        }

        private CommonSaveFileDialog CreateSaveFileDialog(string title = null, string defaultFileName = null)
        {
            var dialog = new CommonSaveFileDialog
            {
                Title = title ?? _saveDialogTitle,
                RestoreDirectory = true,
                DefaultFileName = defaultFileName,
                DefaultDirectory = _defaultDirectory,
                AddToMostRecentlyUsedList = false,
                EnsureValidNames = true,
                ShowPlacesList = true,
                DefaultExtension = null
            };
            return dialog;
        }
    }
}
