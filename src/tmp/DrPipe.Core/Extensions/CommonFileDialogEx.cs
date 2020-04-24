using System.IO;
using System.Linq;

namespace Microsoft.WindowsAPICodePack.Dialogs
{
    public static class CommonFileDialogEx
    {
        public static CommonOpenFileDialog ToFileDialog(this CommonOpenFileDialog dialog)
        {
            dialog.IsFolderPicker = false;
            return dialog;
        }
        public static CommonOpenFileDialog ToFolderDialog(this CommonOpenFileDialog dialog)
        {
            dialog.IsFolderPicker = true;
            return dialog;
        }

        public static TDialog WithFilter<TDialog>(this TDialog dialog, string displayName, params string[] extensions)
            where TDialog : CommonFileDialog
        {
            var extensionList = string.Join(", ", extensions);
            dialog.Filters.Add(new CommonFileDialogFilter(displayName, extensionList));
            return dialog;
        }

        public static string GetPath(this CommonSaveFileDialog dialog)
        {
            var result = dialog.ShowDialog();
            if (result == CommonFileDialogResult.Ok)
            {
                var index      = dialog.SelectedFileTypeIndex - 1;
                var extensions = dialog.Filters[index].Extensions;
                var fileName   = dialog.FileName;
                foreach (var exe in extensions)
                {
                    if (Path.GetExtension(fileName).ToUpper() == $".{exe}".ToUpper())
                    {
                        return fileName;
                    }
                }
                return $"{fileName}.{extensions[0]}";
            }
            return null;
        }
        public static string GetPath(this CommonOpenFileDialog dialog)
        {
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                return dialog.FileName;
            return null;
        }
        public static string[] GetPaths(this CommonOpenFileDialog dialog)
        {
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                return dialog.FileNames.ToArray();
            return null;
        }
    }
}
