using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace VTOLVR_MissionAssistant.ViewModels.Vts
{
    /// <summary>Represents a path in VTOL VR.</summary>
    public class PathViewModel : ViewModelBase, ICloneable
    {
        #region Fields

        private int id;
        private string name;
        private bool loop;
        private string pathMode;
        private ObservableCollection<ThreePointValueViewModel> points = new ObservableCollection<ThreePointValueViewModel>();

        #endregion

        #region Properties

        public int Id
        {
            get => id; set
            {
                id = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get => name; set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        public bool Loop
        {
            get => loop; set
            {
                loop = value;
                OnPropertyChanged();
            }
        }

        public string PathMode
        {
            get => pathMode; set
            {
                pathMode = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ThreePointValueViewModel> Points
        {
            get => points; set
            {
                points = value;
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

        /// <summary>Creates a new instance of <see cref="PathViewModel"/> with all the same values as this instance.</summary>
        /// <returns>A cloned Path object.</returns>
        public PathViewModel Clone()
        {
            return new PathViewModel
            {
                Id = Id,
                Name = Name,
                Loop = Loop,
                PathMode = PathMode,
                Points = new ObservableCollection<ThreePointValueViewModel>(Points.Select(x => x.Clone()).ToList()),
                Parent = Parent
            };
        }

        #endregion
    }
}
