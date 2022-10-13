using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VTOLVR_MissionAssistant.Core.Types;
using VtsFileManager;

namespace VTOLVR_MissionAssistant.Core.Services
{
    public class VtsDataProcessorService
    {
        #region Fields

        #endregion

        #region Properties

        #endregion

        #region Constructors

        #endregion

        #region Methods

        public CustomScenario ProcessFile(string file)
        {
            VtsCustomScenario vtsCustomScenario = VtsReader.ReadVtsFile(file);

            if (vtsCustomScenario == null) return null;

            CustomScenario customScenario = new CustomScenario();

            return customScenario;
        }

        #endregion
    }
}
