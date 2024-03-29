﻿using SimpleLogger;
using System.Windows;
using VTOLVR_MissionAssistant.ViewModels;
using WPF.Translations;

namespace VTOLVR_MissionAssistant
{
    internal class ServiceLocator
    {
        #region Fields

        private static ServiceLocator instance = new ServiceLocator();
        private static readonly object @lock = new object();

        #endregion

        #region Properties

        /// <summary>Gets the instance of the <see cref="ServiceLocator" /> to use throughout the entire application.</summary>
        public static ServiceLocator Instance
        {
            get
            {
                lock (@lock)
                {
                    return instance;
                }
            }
        }

        public MainWindowViewModel MainWindowViewModel { get; set; }

        public Logger Logger { get; set; }

        public Translator<ResourceDictionary> Translator { get; set; }

        #endregion

        #region Constructors

        private ServiceLocator()
        {
            Logger = new Logger();
        }

        #endregion
    }
}
