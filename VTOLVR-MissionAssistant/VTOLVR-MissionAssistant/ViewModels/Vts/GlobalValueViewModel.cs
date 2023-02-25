using System;

namespace VTOLVR_MissionAssistant.ViewModels.Vts
{
    /// <summary>Represents a global value in VTOL VR.</summary>
    public class GlobalValueViewModel : ViewModelBase, ICloneable
    {
        #region Fields

        private int index;
        private string name;
        private string description;
        private int value;

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

        public string Name
        {
            get => name; 
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get => description; 
            set
            {
                description = value;
                OnPropertyChanged();
            }
        }

        public int Value
        {
            get => value; 
            set
            {
                this.value = value;
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

        /// <summary>Creates a new instance of <see cref="GlobalValueViewModel"/> with all the same values as this instance.</summary>
        /// <returns>A cloned GlobalValue object.</returns>
        public GlobalValueViewModel Clone()
        {
            return new GlobalValueViewModel
            {
                Index = Index,
                Name = Name,
                Description = Description,
                Value = Value,
                Parent = Parent
            };
        }

        public override string ToString()
        {
            return $"{Index};{Name};{Description};{Value};";
        }

        #endregion
    }
}
