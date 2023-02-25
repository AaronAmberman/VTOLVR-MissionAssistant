using System;

namespace VTOLVR_MissionAssistant.ViewModels.Vts
{
    /// <summary>Represents a static object in VTOL VR.</summary>
    public class StaticObjectViewModel : ViewModelBase, ICloneable
    {
        #region Fields

        private string prefabId;
        private int id;
        private ThreePointValueViewModel globalPosition;
        private ThreePointValueViewModel rotation;

        #endregion

        #region Properties

        public string PrefabId
        {
            get => prefabId; set
            {
                prefabId = value;
                OnPropertyChanged();
            }
        }

        public int Id
        {
            get => id; set
            {
                id = value;
                OnPropertyChanged();
            }
        }

        public ThreePointValueViewModel GlobalPosition
        {
            get => globalPosition; set
            {
                globalPosition = value;
                OnPropertyChanged();
            }
        }

        public ThreePointValueViewModel Rotation
        {
            get => rotation; set
            {
                rotation = value;
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

        /// <summary>Creates a new instance of <see cref="StaticObjectViewModel"/> with all the same values as this instance.</summary>
        /// <returns>A cloned StaticObject object.</returns>
        public StaticObjectViewModel Clone()
        {
            return new StaticObjectViewModel
            {
                PrefabId = PrefabId,
                Id = Id,
                GlobalPosition = GlobalPosition.Clone(),
                Rotation = Rotation.Clone(),
                Parent = Parent
            };
        }

        #endregion
    }
}
