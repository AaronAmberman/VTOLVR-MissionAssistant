﻿using System;
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
            VtsCustomScenarioObject vtsCustomScenarioObject = VtsReader.ReadVtsFile(file);

            if (vtsCustomScenarioObject == null) return null;

            string temp = @"C:\Users\Aaron\Desktop\temp-vts-file.vts";
            bool success = VtsWriter.WriteVtsFile(vtsCustomScenarioObject, temp);

            CustomScenario customScenario = new CustomScenario();

            return customScenario;
        }

        #endregion
    }
}
