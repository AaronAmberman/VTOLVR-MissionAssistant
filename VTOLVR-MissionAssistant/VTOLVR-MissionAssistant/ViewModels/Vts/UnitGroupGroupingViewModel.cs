using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace VTOLVR_MissionAssistant.ViewModels.Vts
{
    /// <summary>An object to hold the unit group and that unit groups setting.</summary>
    public class UnitGroupGroupingViewModel : ViewModelBase, ICloneable
    {
        #region Fields

        private string name;
        private UnitGroupSettingsViewModel settings;
        private ObservableCollection<UnitSpawnerViewModel> units = new ObservableCollection<UnitSpawnerViewModel>();

        #endregion

        #region Properties

        // Alpha, Bravo, Charlie, etc.
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        public UnitGroupSettingsViewModel Settings
        {
            get => settings;
            set
            {
                settings = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<UnitSpawnerViewModel> Units
        {
            get => units; 
            set
            {
                units = value;
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

        /// <summary>Creates a new instance of <see cref="UnitGroupGroupingViewModel"/> with all the same values as this instance.</summary>
        /// <returns>A cloned UnitGroupGrouping object.</returns>
        public UnitGroupGroupingViewModel Clone()
        {
            return new UnitGroupGroupingViewModel
            {
                Name = Name,
                Settings = Settings?.Clone(),
                Units = new ObservableCollection<UnitSpawnerViewModel>(Units.Select(x => x.Clone()).ToList()),
                Parent = Parent
            };
        }

        #endregion
    }
}
