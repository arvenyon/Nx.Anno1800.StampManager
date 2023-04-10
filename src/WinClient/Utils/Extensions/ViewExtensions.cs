using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using WinClient.Utils.Extensions.ExtensionModels;

namespace WinClient.Utils.Extensions
{
    /// <summary>
    /// Collection of extension methods for views
    /// </summary>
    public static class ViewExtensions
    {
        /// <summary>
        /// Saves current state of the Window (Position, Size, WindowState) persistent
        /// </summary>
        /// <param name="window">The window of which the state should be saved</param>
        public static void SaveState(this Window window)
        {
            EnsureWindowValid(window);

            var fileName = ResolveWindowStateStorePath(window);
            var state = new ViewState(
                window.Left,
                window.Top,
                window.ActualWidth,
                window.ActualHeight,
                window.WindowState == WindowState.Maximized);
            var jsonState = JsonSerializer.Serialize(state);
            File.WriteAllText(fileName, jsonState);
        }

        /// <summary>
        /// Restores the saved state of the Window (Position, Size, WindowState)
        /// </summary>
        /// <param name="window">The window of which the state should be restored</param>
        public static void RestoreState(this Window window)
        {
            EnsureWindowValid(window);

            var fileName = ResolveWindowStateStorePath(window);
            ViewState state = null;
            if (File.Exists(fileName))
            {
                var jsonState = File.ReadAllText(fileName);
                state = JsonSerializer.Deserialize<ViewState>(jsonState);
            }
            else
            {
                state = new ViewState(
                    30,
                    30,
                    1080,
                    720,
                    true);
            }

            window.Left = state.PosX;
            window.Top = state.PosY;
            window.Width = state.Width;
            window.Height = state.Height;
            window.WindowState = state.IsMaximized ? WindowState.Maximized : WindowState.Normal;
        }

        private static void EnsureWindowValid(Window window)
        {
            if (string.IsNullOrWhiteSpace(window.Name))
                throw new InvalidOperationException("In order to save or restore window states, the window needs a unique Window.[Name].");
        }

        private static string ResolveWindowStateStorePath(Window window)
        {
            var dir = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                Assembly.GetExecutingAssembly().GetName().Name,
                "ViewStates");
            Directory.CreateDirectory(dir);
            return Path.Combine(dir, $"{window.Name}_ViewState.json");
        }
    }
}
