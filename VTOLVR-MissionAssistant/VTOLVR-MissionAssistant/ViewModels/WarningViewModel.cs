namespace VTOLVR_MissionAssistant.ViewModels
{
    public class WarningViewModel : ViewModelBase
    {
        #region Fields

        private string message;
        private string subType;
        private string type;

        #endregion

        #region Properties

        public string Message
        {
            get => message;
            set 
            {
                message = value;
                OnPropertyChanged();
            }
        }

        public string SubType
        {
            get => subType;
            set
            {
                subType = value;
                OnPropertyChanged();
            }
        }

        public string Type
        {
            get => type;
            set
            {
                type = value;
                OnPropertyChanged();
            }
        }

        #endregion
    }
}
