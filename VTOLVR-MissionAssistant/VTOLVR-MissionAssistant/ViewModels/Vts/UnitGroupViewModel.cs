using System;

namespace VTOLVR_MissionAssistant.ViewModels.Vts
{
    /// <summary>Represents all the unit groups for a team.</summary>
    public class UnitGroupViewModel : ViewModelBase, ICloneable
    {
        #region Fields

        private string name;
        private UnitGroupGroupingViewModel alpha;
        private UnitGroupGroupingViewModel bravo;
        private UnitGroupGroupingViewModel charlie;
        private UnitGroupGroupingViewModel delta;
        private UnitGroupGroupingViewModel echo;
        private UnitGroupGroupingViewModel foxtrot;
        private UnitGroupGroupingViewModel golf;
        private UnitGroupGroupingViewModel hotel;
        private UnitGroupGroupingViewModel india;
        private UnitGroupGroupingViewModel juliet;
        private UnitGroupGroupingViewModel kilo;
        private UnitGroupGroupingViewModel lima;
        private UnitGroupGroupingViewModel mike;
        private UnitGroupGroupingViewModel november;
        private UnitGroupGroupingViewModel oscar;
        private UnitGroupGroupingViewModel papa;
        private UnitGroupGroupingViewModel romeo;
        private UnitGroupGroupingViewModel quebec;
        private UnitGroupGroupingViewModel sierra;
        private UnitGroupGroupingViewModel tango;
        private UnitGroupGroupingViewModel uniform;
        private UnitGroupGroupingViewModel victor;
        private UnitGroupGroupingViewModel whiskey;
        private UnitGroupGroupingViewModel xray;
        private UnitGroupGroupingViewModel yankee;
        private UnitGroupGroupingViewModel zulu;

        #endregion

        #region Properties

        // ALLIED or ENEMY
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        public UnitGroupGroupingViewModel Alpha
        {
            get => alpha;
            set
            {
                alpha = value;
                OnPropertyChanged();
            }
        }

        public UnitGroupGroupingViewModel Bravo
        {
            get => bravo;
            set
            {
                bravo = value;
                OnPropertyChanged();
            }
        }

        public UnitGroupGroupingViewModel Charlie
        {
            get => charlie;
            set
            {
                charlie = value;
                OnPropertyChanged();
            }
        }

        public UnitGroupGroupingViewModel Delta
        {
            get => delta; 
            set
            {
                delta = value;
                OnPropertyChanged();
            }
        }

        public UnitGroupGroupingViewModel Echo
        {
            get => echo;
            set
            {
                echo = value;
                OnPropertyChanged();
            }
        }

        public UnitGroupGroupingViewModel Foxtrot
        {
            get => foxtrot;
            set
            {
                foxtrot = value;
                OnPropertyChanged();
            }
        }

        public UnitGroupGroupingViewModel Golf
        {
            get => golf;
            set
            {
                golf = value;
                OnPropertyChanged();
            }
        }

        public UnitGroupGroupingViewModel Hotel
        {
            get => hotel;
            set
            {
                hotel = value;
                OnPropertyChanged();
            }
        }

        public UnitGroupGroupingViewModel India
        {
            get => india;
            set
            {
                india = value;
                OnPropertyChanged();
            }
        }

        public UnitGroupGroupingViewModel Juliet
        {
            get => juliet;
            set
            {
                juliet = value;
                OnPropertyChanged();
            }
        }

        public UnitGroupGroupingViewModel Kilo
        {
            get => kilo;
            set
            {
                kilo = value;
                OnPropertyChanged();
            }
        }

        public UnitGroupGroupingViewModel Lima
        {
            get => lima;
            set
            {
                lima = value;
                OnPropertyChanged();
            }
        }

        public UnitGroupGroupingViewModel Mike
        {
            get => mike; 
            set
            {
                mike = value;
                OnPropertyChanged();
            }
        }

        public UnitGroupGroupingViewModel November
        {
            get => november;
            set
            {
                november = value;
                OnPropertyChanged();
            }
        }

        public UnitGroupGroupingViewModel Oscar
        {
            get => oscar;
            set
            {
                oscar = value;
                OnPropertyChanged();
            }
        }

        public UnitGroupGroupingViewModel Papa
        {
            get => papa;
            set
            {
                papa = value;
                OnPropertyChanged();
            }
        }

        public UnitGroupGroupingViewModel Quebec
        {
            get => quebec;
            set
            {
                quebec = value;
                OnPropertyChanged();
            }
        }

        public UnitGroupGroupingViewModel Romeo
        {
            get => romeo;
            set
            {
                romeo = value;
                OnPropertyChanged();
            }
        }

        public UnitGroupGroupingViewModel Sierra
        {
            get => sierra;
            set
            {
                sierra = value;
                OnPropertyChanged();
            }
        }

        public UnitGroupGroupingViewModel Tango
        {
            get => tango;
            set
            {
                tango = value;
                OnPropertyChanged();
            }
        }

        public UnitGroupGroupingViewModel Uniform
        {
            get => uniform;
            set
            {
                uniform = value;
                OnPropertyChanged();
            }
        }

        public UnitGroupGroupingViewModel Victor
        {
            get => victor;
            set
            {
                victor = value;
                OnPropertyChanged();
            }
        }

        public UnitGroupGroupingViewModel Whiskey
        {
            get => whiskey;
            set
            {
                whiskey = value;
                OnPropertyChanged();
            }
        }

        public UnitGroupGroupingViewModel Xray
        {
            get => xray; set
            {
                xray = value;
                OnPropertyChanged();
            }
        }

        public UnitGroupGroupingViewModel Yankee
        {
            get => yankee;
            set
            {
                yankee = value;
                OnPropertyChanged();
            }
        }

        public UnitGroupGroupingViewModel Zulu
        {
            get => zulu;
            set
            {
                zulu = value;
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

        /// <summary>Creates a new instance of <see cref="UnitGroupViewModel"/> with all the same values as this instance.</summary>
        /// <returns>A cloned UnitGroup object.</returns>
        public UnitGroupViewModel Clone()
        {
            return new UnitGroupViewModel
            {
                Name = Name,
                Alpha = Alpha?.Clone(),
                Bravo = Bravo?.Clone(),
                Charlie = Charlie?.Clone(),
                Delta = Delta?.Clone(),
                Echo = Echo?.Clone(),
                Foxtrot = Foxtrot?.Clone(),
                Golf = Golf?.Clone(),
                Hotel = Hotel?.Clone(),
                India = India?.Clone(),
                Juliet = Juliet?.Clone(),
                Kilo = Kilo?.Clone(),
                Lima = Lima?.Clone(),
                Mike = Mike?.Clone(),
                November = November?.Clone(),
                Oscar = Oscar?.Clone(),
                Papa = Papa?.Clone(),
                Quebec = Quebec?.Clone(),
                Romeo = Romeo?.Clone(),
                Sierra = Sierra?.Clone(),
                Tango = Tango?.Clone(),
                Uniform = Uniform?.Clone(),
                Victor = Victor?.Clone(),
                Whiskey = Whiskey?.Clone(),
                Xray = Xray?.Clone(),
                Yankee = Yankee?.Clone(),
                Zulu = Zulu?.Clone(),
                Parent = Parent
            };
        }

        #endregion
    }
}
