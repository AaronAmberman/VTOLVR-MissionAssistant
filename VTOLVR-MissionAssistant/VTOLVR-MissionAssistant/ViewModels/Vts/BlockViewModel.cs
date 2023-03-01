using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace VTOLVR_MissionAssistant.ViewModels.Vts
{
    /// <summary>Represents a block in a conditional action (this can be the BASE_BLOCK or ELSE_IF blocks inside the BASE_BLOCK block).</summary>
    public class BlockViewModel : ViewModelBase, ICloneable
    {
        #region Fields

        private EventInfoViewModel actions;
        private int blockId;
        private string blockName;
        private ConditionalViewModel conditional;
        private EventInfoViewModel elseActions;
        private ObservableCollection<BlockViewModel> elseIfBlocks = new ObservableCollection<BlockViewModel>();

        #endregion

        #region Properties

        public EventInfoViewModel Actions
        {
            get => actions;
            set
            {
                actions = value;
                OnPropertyChanged();
            }
        }

        public int BlockId
        {
            get => blockId;
            set
            {
                blockId = value;
                OnPropertyChanged();
            }
        }

        public string BlockName
        {
            get => blockName;
            set
            {
                blockName = value;
                OnPropertyChanged();
            }
        }

        public ConditionalViewModel Conditional
        {
            get => conditional;
            set
            {
                conditional = value;
                OnPropertyChanged();
            }
        }

        public EventInfoViewModel ElseActions
        {
            get => elseActions;
            set
            {
                elseActions = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<BlockViewModel> ElseIfBlocks
        {
            get => elseIfBlocks;
            set
            {
                elseIfBlocks = value;
                OnPropertyChanged();
            }
        }

        // can be a ConditionalAction or another Block (ElseIfBlocks)
        public object Parent { get; set; }

        #endregion

        #region Methods

        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>Creates a new instance of <see cref="BlockViewModel"/> with all the same values as this instance.</summary>
        /// <returns>A cloned Block object.</returns>
        public BlockViewModel Clone()
        {
            return new BlockViewModel
            {
                Actions = Actions?.Clone(),
                BlockId = BlockId,
                BlockName = BlockName,
                Conditional = Conditional?.Clone(),
                ElseActions = ElseActions?.Clone(),
                ElseIfBlocks = new ObservableCollection<BlockViewModel>(ElseIfBlocks.Select(x => x.Clone()).ToList()),
                Parent = Parent
            };
        }

        #endregion
    }
}
