using System;

namespace VTOLVR_MissionAssistant.ViewModels.Vts
{
    /// <summary>Represents a waypoint in VTOL VR.</summary>
    public class WaypointViewModel : ViewModelBase, ICloneable
    {
        #region Fields

        private ThreePointValueViewModel globalPoint;
        private int id;
        private string name;

        #endregion

        #region Properties

        public ThreePointValueViewModel GlobalPoint
        {
            get => globalPoint;
            set
            {
                globalPoint = value;
                OnPropertyChanged();
            }
        }

        public int Id
        {
            get => id;
            set
            {
                id = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get => name;
            set
            {
                name = value;
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

        /// <summary>Creates a new instance of <see cref="WaypointViewModel"/> with all the same values as this instance.</summary>
        /// <returns>A cloned UnitSpawner object.</returns>
        public WaypointViewModel Clone()
        {
            return new WaypointViewModel
            {
                GlobalPoint = GlobalPoint.Clone(),
                Id = Id,
                Name = Name,
                Parent = Parent
            };
        }

        #endregion
    }
}
