using System.Windows.Input;
using WinClient.BusinessLogic.Commands;
using WinClient.Utils.Helpers;

namespace WinClient.ViewModels.WindowViewModels
{
    public sealed class MainViewModel : ViewModel
    {
        public ICommand ConvertCommand => new RelayCommand(
            _ =>
            {
                var stampPath = @"C:\Users\domin\OneDrive\Documents\Anno 1800\stamps\The Old World\Worker\Soap";
                StampsHelper.TranslateStampToXml(stampPath, string.Empty);
            });

    }
}
