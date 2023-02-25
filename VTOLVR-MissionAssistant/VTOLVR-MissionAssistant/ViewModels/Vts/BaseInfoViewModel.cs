using System;

namespace VTOLVR_MissionAssistant.ViewModels.Vts
{
    /// <summary>Represents a base in VTOL VR.</summary>
    public class BaseInfoViewModel : ViewModelBase, ICloneable
    {
        #region Fields

        private int id;
        private string overrideBaseName;
        private string baseTeam;

        #endregion

        #region Properties

        public int Id
        {
            get => id;
            set
            {
                id = value;
                OnPropertyChanged();
            }
        }

        public string OverrideBaseName 
        { 
            get => overrideBaseName;
            set
            {
                overrideBaseName = value;
                OnPropertyChanged();
            }
        }

        public string BaseTeam 
        { 
            get => baseTeam;
            set
            {
                baseTeam = value;
                OnPropertyChanged();
            }
        }

        public CustomScenarioViewModel Parent { get; set; }

        #endregion

        #region Methods

        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>Creates a new instance of <see cref="BaseInfoViewModel"/> with all the same values as this instance.</summary>
        /// <returns>A cloned BaseInfo object.</returns>
        public BaseInfoViewModel Clone()
        {
            return new BaseInfoViewModel
            {
                Id = Id,
                OverrideBaseName = OverrideBaseName,
                BaseTeam = BaseTeam,
                Parent = Parent
            };
        }

        #endregion
    }
}
