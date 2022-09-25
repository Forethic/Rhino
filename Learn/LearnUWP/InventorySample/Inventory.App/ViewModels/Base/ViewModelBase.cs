using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;

namespace Inventory.ViewModels
{
    public class ViewModelBase : ModelBase
    {
        public bool IsMainView => CoreApplication.GetCurrentView().IsMain;

        public virtual string Title => string.Empty;
    }
}