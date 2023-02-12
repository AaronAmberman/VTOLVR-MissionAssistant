﻿using System;
using VTS.Data;
using VTS.Data.Abstractions;
using VTS.Data.Diagnostics;
using VTS.Data.Raw;
using VTS.File;

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

        public void ProcessFile(string file)
        {
            //VtsCustomScenarioObject vtsCustomScenarioObject = VtsReader.ReadVtsFile(file);

            //if (vtsCustomScenarioObject == null) return;

            //bool success = VtsWriter.WriteVtsFile(vtsCustomScenarioObject, temp);

            DiagnosticOptions.OutputCustomScenarioConversionTime = true;
            //DiagnosticOptions.OutputUnitFieldsGroups = true;
            //CustomScenario customScenario = CustomScenario.ReadVtsFile(file);

            //if (customScenario == null) return;

            //CustomScenario clone = customScenario.Clone();
            //clone.File = @"C:\Users\Aaron\Desktop\VTS Files\temp-vts-file.vts";

            //bool success = CustomScenario.WriteVtsFile(clone);

            //VTS.Data.Runtime.CustomScenario scenario = new VTS.Data.Runtime.CustomScenario(customScenario);
            VTS.Data.Runtime.CustomScenario scenario = new VTS.Data.Runtime.CustomScenario(file);

            if (!scenario.HasError)
            {
                VTS.Data.Runtime.CustomScenario clone = scenario.Clone();
                clone.File = @"C:\Users\Aaron\Desktop\VTS Files\temp-vts-file.vts";

                bool success = clone.Save();
            }
        }

        #endregion
    }
}