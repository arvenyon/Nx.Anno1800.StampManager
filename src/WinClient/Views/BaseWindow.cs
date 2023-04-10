using System.Windows;
using WinClient.Utils.Extensions;

namespace WinClient.Views
{
    public class BaseWindow : Window
    {
        public BaseWindow()
        {
            this.Initialized += (s, e) =>
            {
                this.RestoreState();
            };
            this.Closing += (s, e) =>
            {
                this.SaveState();
            };
        }

    }
}
