using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace VTOLVR_MissionAssistant.ViewModels.Vts
{
    /// <summary>Represents a conditional in VTOL VR.</summary>
    public class ConditionalViewModel : ViewModelBase, ICloneable
    {
        #region Fields

        private ObservableCollection<ComputationViewModel> computations = new ObservableCollection<ComputationViewModel>();
        private int id;
        private ThreePointValueViewModel outputNodePosition;
        private int? root;

        #endregion

        #region Properties

        public ObservableCollection<ComputationViewModel> Computations
        {
            get => computations;
            set
            {
                computations = value;
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

        public ThreePointValueViewModel OutputNodePosition
        {
            get => outputNodePosition;
            set
            {
                outputNodePosition = value;
                OnPropertyChanged();
            }
        }

        public int? Root
        { 
            get => root;
            set
            {
                root = value;
                OnPropertyChanged();
            }
        }

        // can be a CustomScenario (in the conditionals collection), Block or an Event
        public object Parent { get; set; }

        #endregion

        #region Methods

        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>Creates a new instance of <see cref="ConditionalViewModel"/> with all the same values as this instance.</summary>
        /// <returns>A cloned Conditional object.</returns>
        public ConditionalViewModel Clone()
        {
            return new ConditionalViewModel
            {
                Computations = new ObservableCollection<ComputationViewModel>(Computations.Select(x => x.Clone()).ToList()),
                OutputNodePosition = OutputNodePosition?.Clone(),
                Id = Id,
                Root = Root,
                Parent = Parent
            };
        }

        #endregion
    }
}
