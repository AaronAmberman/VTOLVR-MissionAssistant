using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VTOLVR_MissionAssistant.Core.Types;
using VTOLVR_VtsFileParser;

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
            VtsFileParser parser = new VtsFileParser();
            VtsCustomScenario vtsCustomScenario = parser.ParseVtsFile(file);

            if (vtsCustomScenario == null) return null;

            CustomScenario customScenario = new CustomScenario();

            return customScenario;
        }

        #endregion
    }
}
