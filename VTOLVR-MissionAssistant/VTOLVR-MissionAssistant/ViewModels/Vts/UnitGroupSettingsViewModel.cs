using System;

namespace VTOLVR_MissionAssistant.ViewModels.Vts
{
    /// <summary>Represents a settings object for a unit group (e.g. Alpha_SETTINGS, Bravo_SETTINGS, etc.).</summary>
    public class UnitGroupSettingsViewModel : ViewModelBase, ICloneable
    {
        #region Fields

        private string name;
        private string syncAltSpawns;

        #endregion

        #region Properties

        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        public string SyncAltSpawns
        {
            get => syncAltSpawns; 
            set
            {
                syncAltSpawns = value;
                OnPropertyChanged();
            }
        }

        public UnitGroupGroupingViewModel Parent { get; set; }

        #endregion

        #region Methods

        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>Creates a new instance of <see cref="UnitGroupSettingsViewModel"/> with all the same values as this instance.</summary>
        /// <returns>A cloned UnitGroupSettings object.</returns>
        public UnitGroupSettingsViewModel Clone()
        {
            return new UnitGroupSettingsViewModel
            {
                Name = Name,
                SyncAltSpawns = SyncAltSpawns
            };
        }

        #endregion
    }
}
