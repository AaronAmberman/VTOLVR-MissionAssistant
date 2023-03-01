using System;

namespace VTOLVR_MissionAssistant.ViewModels.Vts
{
    /// <summary>Represents a conditional action in the VTS file.</summary>
    public class ConditionalActionViewModel : ViewModelBase, ICloneable
    {
        #region Fields

        private BlockViewModel baseBlock;
        private int id;
        private string name;

        #endregion

        #region Properties

        public BlockViewModel BaseBlock
        {
            get => baseBlock;
            set
            {
                baseBlock = value;
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
                name=value;
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

        /// <summary>Creates a new instance of <see cref="ConditionalActionViewModel"/> with all the same values as this instance.</summary>
        /// <returns>A cloned ConditionalAction object.</returns>
        public ConditionalActionViewModel Clone()
        {
            return new ConditionalActionViewModel
            {
                BaseBlock = BaseBlock?.Clone(),
                Id = Id,
                Name = Name,
                Parent = Parent
            };
        }

        #endregion
    }
}
