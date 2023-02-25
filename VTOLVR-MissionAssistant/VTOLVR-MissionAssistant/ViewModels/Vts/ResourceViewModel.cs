using System;

namespace VTOLVR_MissionAssistant.ViewModels.Vts
{
    /// <summary>Represents a resource in the resource manifest for the VTS file.</summary>
    public class ResourceViewModel : ViewModelBase, ICloneable
    {
        #region Fields

        private int index;
        private string path;

        #endregion

        #region Properties

        public int Index
        {
            get => index; 
            set
            {
                index = value;
                OnPropertyChanged();
            }
        }

        public string Path
        {
            get => path; 
            set
            {
                path = value;
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

        /// <summary>Creates a new instance of <see cref="ResourceViewModel"/> with all the same values as this instance.</summary>
        /// <returns>A cloned Resource object.</returns>
        public ResourceViewModel Clone()
        {
            return new ResourceViewModel
            {
                Index = Index,
                Path = Path,
                Parent = Parent
            };
        }

        #endregion
    }
}
