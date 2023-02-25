using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace VTOLVR_MissionAssistant.ViewModels.Vts
{
    public class ObjectiveFieldsViewModel : ViewModelBase, ICloneable
    {
        #region Fields

        private ConditionalViewModel failConditional;
        private ConditionalViewModel successConditional;
        private float? radius;
        private ObservableCollection<UnitSpawnerViewModel> targets = new ObservableCollection<UnitSpawnerViewModel>();
        private int? minRequired;
        private int? perUnitReward;
        private int? fullCompletionBonus;
        private float? unloadRadius;
        private WaypointViewModel dropoffRallyPoint;
        private float? triggerRadius;
        private bool? sphericalRadius;
        private UnitSpawnerViewModel targetUnit;
        private float? fuelLevel;
        private string completionMode;
        private UnitSpawnerViewModel target;

        #endregion

        #region Properties

        public ConditionalViewModel FailConditional
        {
            get => failConditional; 
            set
            {
                failConditional = value;
                OnPropertyChanged();
            }
        }

        public ConditionalViewModel SuccessConditional
        {
            get => successConditional;
            set
            {
                successConditional = value;
                OnPropertyChanged();
            }
        }

        public float? Radius
        {
            get => radius; 
            set
            {
                radius = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<UnitSpawnerViewModel> Targets
        {
            get => targets; 
            set
            {
                targets = value;
                OnPropertyChanged();
            }
        }

        public int? MinRequired
        {
            get => minRequired; 
            set
            {
                minRequired = value;
                OnPropertyChanged();
            }
        }

        public int? PerUnitReward
        {
            get => perUnitReward; 
            set
            {
                perUnitReward = value;
                OnPropertyChanged();
            }
        }

        public int? FullCompletionBonus
        {
            get => fullCompletionBonus; 
            set
            {
                fullCompletionBonus = value;
                OnPropertyChanged();
            }
        }

        public float? UnloadRadius
        {
            get => unloadRadius;
            set
            {
                unloadRadius = value;
                OnPropertyChanged();
            }
        }

        public WaypointViewModel DropoffRallyPoint
        {
            get => dropoffRallyPoint; 
            set
            {
                dropoffRallyPoint = value;
                OnPropertyChanged();
            }
        }

        public float? TriggerRadius
        {
            get => triggerRadius; 
            set
            {
                triggerRadius = value;
                OnPropertyChanged();
            }
        }

        public bool? SphericalRadius
        {
            get => sphericalRadius; 
            set
            {
                sphericalRadius = value;
                OnPropertyChanged();
            }
        }

        public UnitSpawnerViewModel TargetUnit
        {
            get => targetUnit; 
            set
            {
                targetUnit = value;
                OnPropertyChanged();
            }
        }

        public float? FuelLevel
        {
            get => fuelLevel; 
            set
            {
                fuelLevel = value;
                OnPropertyChanged();
            }
        }

        public string CompletionMode
        {
            get => completionMode; 
            set
            {
                completionMode = value;
                OnPropertyChanged();
            }
        }

        public UnitSpawnerViewModel Target
        {
            get => target; 
            set
            {
                target = value;
                OnPropertyChanged();
            }
        }

        public ObjectiveViewModel Parent { get; set; }

        #endregion

        #region Methods

        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>Creates a new instance of <see cref="ObjectiveFieldsViewModel"/> with all the same values as this instance.</summary>
        /// <returns>A cloned ObjectiveFields object.</returns>
        public ObjectiveFieldsViewModel Clone()
        {
            return new ObjectiveFieldsViewModel
            {
                FailConditional = FailConditional?.Clone(),
                SuccessConditional = SuccessConditional.Clone(),
                Radius = Radius,
                Targets = new ObservableCollection<UnitSpawnerViewModel>(Targets.Select(x => x.Clone()).ToList()),
                MinRequired = MinRequired,
                PerUnitReward = PerUnitReward,
                FullCompletionBonus = FullCompletionBonus,
                UnloadRadius = UnloadRadius,
                DropoffRallyPoint = DropoffRallyPoint?.Clone(),
                TriggerRadius = TriggerRadius,
                SphericalRadius = SphericalRadius,
                TargetUnit = TargetUnit?.Clone(),
                FuelLevel = FuelLevel,
                CompletionMode = CompletionMode,
                Target = Target?.Clone(),
                Parent = Parent
            };
        }

        #endregion
    }
}
