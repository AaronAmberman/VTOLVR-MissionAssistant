using System;

namespace VTOLVR_MissionAssistant.ViewModels.Vts
{
    /// <summary>Represents a unit in VTOL VR.</summary>
    public class UnitSpawnerViewModel : ViewModelBase, ICloneable
    {
        #region Fields

        private string editorPlacementMode;
        private ThreePointValueViewModel globalPosition;
        private ThreePointValueViewModel lastValidPlacement;
        private ThreePointValueViewModel rotation;
        private int spawnChance;
        private string spawnFlags;
        private UnitFieldsViewModel unitFields;
        private string unitId;
        private int unitInstanceId;
        private string unitName;

        #endregion

        #region Properties

        public string EditorPlacementMode
        {
            get => editorPlacementMode;
            set
            {
                editorPlacementMode = value;
                OnPropertyChanged();
            }
        }

        public ThreePointValueViewModel GlobalPosition
        {
            get => globalPosition;
            set
            {
                globalPosition = value;
                OnPropertyChanged();
            }
        }

        public ThreePointValueViewModel LastValidPlacement
        {
            get => lastValidPlacement; 
            set
            {
                lastValidPlacement = value;
                OnPropertyChanged();
            }
        }

        public ThreePointValueViewModel Rotation
        {
            get => rotation;
            set
            {
                rotation = value;
                OnPropertyChanged();
            }
        }

        public int SpawnChance
        {
            get => spawnChance;
            set
            {
                spawnChance = value;
                OnPropertyChanged();
            }
        }

        public string SpawnFlags
        {
            get => spawnFlags;
            set
            {
                spawnFlags = value;
                OnPropertyChanged();
            }
        }

        public UnitFieldsViewModel UnitFields
        {
            get => unitFields; 
            set
            {
                unitFields = value;
                OnPropertyChanged();
            }
        }

        public string UnitId
        {
            get => unitId; 
            set
            {
                unitId = value;
                OnPropertyChanged();
            }
        }

        public int UnitInstanceId
        {
            get => unitInstanceId;
            set
            {
                unitInstanceId = value;
                OnPropertyChanged();
            }
        }

        public string UnitName
        {
            get => unitName;
            set
            {
                unitName = value;
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

        /// <summary>Creates a new instance of <see cref="UnitSpawnerViewModel"/> with all the same values as this instance.</summary>
        /// <returns>A cloned UnitSpawner object.</returns>
        public UnitSpawnerViewModel Clone()
        {
            return new UnitSpawnerViewModel
            {
                EditorPlacementMode = EditorPlacementMode,
                GlobalPosition = GlobalPosition.Clone(),
                LastValidPlacement = LastValidPlacement.Clone(),
                Rotation = Rotation.Clone(),
                SpawnChance = SpawnChance,
                SpawnFlags = SpawnFlags,
                UnitFields = UnitFields.Clone(),
                UnitId = UnitId,
                UnitInstanceId = UnitInstanceId,
                UnitName = UnitName,
                Parent = Parent
            };
        }

        #endregion
    }
}
