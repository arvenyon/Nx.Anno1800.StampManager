using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinClient.BusinessLogic;
using WinClient.Models.BaseModels;

namespace WinClient.ViewModels
{
    /// <summary>
    /// Base class for any ViewModels
    /// </summary>
    public abstract class ViewModel : NotifyObject
    {
        internal __Main _main => __Main.Instance;
    }
}
