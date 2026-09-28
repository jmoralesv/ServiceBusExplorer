using System;
using System.IO;
using System.Security;

namespace ServiceBusExplorer.Helpers
{
    internal static class DpiDiagnosticsLog
    {
        private static readonly object syncRoot = new object();
        private static readonly string logFilePath = CreateLogFilePath();
        private static string writeError;

        internal static string LogFilePath => logFilePath;

        internal static bool TryWrite(string message, out string error)
        {
            lock (syncRoot)
            {
                if (writeError != null)
                {
                    error = writeError;
                    return false;
                }

                try
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(logFilePath));
                    File.AppendAllText(logFilePath, message + Environment.NewLine);
                    error = null;
                    return true;
                }
                catch (Exception exception) when (
                    exception is IOException ||
                    exception is UnauthorizedAccessException ||
                    exception is SecurityException)
                {
                    writeError = $"Unable to write DPI diagnostics to '{logFilePath}': {exception.Message}";
                    error = writeError;
                    return false;
                }
            }
        }

        private static string CreateLogFilePath()
        {
            var localApplicationData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            if (string.IsNullOrWhiteSpace(localApplicationData))
            {
                localApplicationData = AppDomain.CurrentDomain.BaseDirectory;
            }

            var fileName = $"DpiDiagnostics-{DateTime.Now:yyyyMMdd-HHmmss-fff}.log";
            return Path.Combine(localApplicationData, "ServiceBusExplorer", "DpiDiagnostics", fileName);
        }
    }
}
