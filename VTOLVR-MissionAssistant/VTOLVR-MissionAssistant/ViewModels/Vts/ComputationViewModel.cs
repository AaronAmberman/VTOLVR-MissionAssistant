using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace VTOLVR_MissionAssistant.ViewModels.Vts
{
    /// <summary>Represents a COMP in VTS file for a conditional.</summary>
    public class ComputationViewModel : ViewModelBase, ICloneable
    {
        #region Fields

        private int? chance;
        private string comparison;
        private string controlCondition;
        private float? controlValue;
        private float? cValue;
        private ObservableCollection<ComputationViewModel> factors = new ObservableCollection<ComputationViewModel>();
        private GlobalValueViewModel globalValue;
        private int id;
        private bool? isNot;
        private string methodParameters;
        private string methodName;
        private object objectReference;
        private string type;
        private ThreePointValueViewModel uiPosition;
        private UnitSpawnerViewModel unit;
        private string unitGroup;
        private ObservableCollection<UnitSpawnerViewModel> unitList = new ObservableCollection<UnitSpawnerViewModel>();
        private string vehicleControl;

        #endregion

        #region Properties

        public int? Chance 
        { 
            get => chance;
            set
            {
                chance = value;
                OnPropertyChanged();
            }
        }

        public string Comparison 
        {
            get => comparison;
            set
            {
                comparison = value;
                OnPropertyChanged();
            }
        }

        public string ControlCondition 
        { 
            get => controlCondition;
            set
            {
                controlCondition = value;
                OnPropertyChanged();
            }
        }

        public float? ControlValue 
        { 
            get => controlValue;
            set
            {
                controlValue = value;
                OnPropertyChanged();
            }
        }

        public float? CValue 
        { 
            get => cValue;
            set
            {
                cValue = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ComputationViewModel> Factors 
        {
            get => factors;
            set
            {
                factors = value;
                OnPropertyChanged();
            }
        }

        public GlobalValueViewModel GlobalValue 
        { 
            get => globalValue;
            set
            {
                globalValue = value;
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

        public bool? IsNot 
        { 
            get => isNot;
            set
            {
                isNot = value;
                OnPropertyChanged();
            }
        }

        public string MethodParameters 
        { 
            get => methodParameters;
            set
            {
                methodParameters = value;
                OnPropertyChanged();
            }
        }

        public string MethodName 
        { 
            get => methodName;
            set
            {
                methodName = value;
                OnPropertyChanged();
            }
        }

        public object ObjectReference 
        { 
            get => objectReference;
            set
            {
                objectReference = value;
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

        public ThreePointValueViewModel UiPosition 
        { 
            get => uiPosition;
            set
            {
                uiPosition = value;
                OnPropertyChanged();
            }
        }

        public UnitSpawnerViewModel Unit 
        { 
            get => unit;
            set
            {
                unit = value;
                OnPropertyChanged();
            }
        }

        public string UnitGroup 
        { 
            get => unitGroup;
            set
            {
                unitGroup = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<UnitSpawnerViewModel> UnitList 
        {
            get => unitList;
            set
            {
                unitList = value;
                OnPropertyChanged();
            }
        }

        public string VehicleControl 
        { 
            get => vehicleControl;
            set
            {
                vehicleControl = value;
                OnPropertyChanged();
            }
        }

        public ConditionalViewModel Parent { get; set; }

        #endregion

        #region Methods

        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>Creates a new instance of <see cref="ComputationViewModel"/> with all the same values as this instance.</summary>
        /// <returns>A cloned Computation object.</returns>
        public ComputationViewModel Clone()
        {
            return new ComputationViewModel
            {
                Chance = Chance,
                Comparison = Comparison,
                ControlCondition = ControlCondition,
                ControlValue = ControlValue,
                CValue = CValue,
                Factors = new ObservableCollection<ComputationViewModel>(Factors.Select(x => x.Clone()).ToList()),
                GlobalValue = GlobalValue.Clone(),
                Id = Id,
                IsNot = IsNot,
                MethodParameters = MethodParameters,
                MethodName = MethodName,
                ObjectReference = ObjectReference,
                Type = Type,
                UiPosition = UiPosition.Clone(),
                Unit = Unit?.Clone(),
                UnitGroup = UnitGroup,
                UnitList = new ObservableCollection<UnitSpawnerViewModel>(UnitList.Select(x => x.Clone()).ToList()),
                VehicleControl = VehicleControl,
                Parent = Parent
            };
        }

        #endregion
    }
}
