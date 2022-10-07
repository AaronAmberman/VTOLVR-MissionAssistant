using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTOLVR_MissionAssistant.ViewModels
{
    /// <summary>The view model for the main window.</summary>
    public class MainWindowViewModel : ViewModelBase
    {
        #region Fields

        private MessageBoxViewModel messageBoxViewModel;

        #endregion

        #region Properties

        public MessageBoxViewModel MessageBoxViewModel
        {
            get { return messageBoxViewModel; }
            set 
            { 
                messageBoxViewModel = value; 
                OnPropertyChanged();
            }
        }

        #endregion
    }
}
