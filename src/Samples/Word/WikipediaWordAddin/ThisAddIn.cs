﻿using System;
using System.Windows;
using VSTOContrib.Autofac;
using VSTOContrib.Core;
using VSTOContrib.Word.RibbonFactory;
using Office = Microsoft.Office.Core;

namespace WikipediaWordAddin
{
    public partial class ThisAddIn
    {
        private void ThisAddInStartup(object sender, EventArgs e)
        {
        }

        private void ThisAddInShutdown(object sender, EventArgs e)
        {
        }


        protected override Office.IRibbonExtensibility CreateRibbonExtensibilityObject()
        {
            //Required for WPF support
            if (System.Windows.Application.Current == null)
                new Application { ShutdownMode = ShutdownMode.OnExplicitShutdown };

            VstoContribLog.ToTrace();
            VstoContribLog.SetLevel(VstoContribLogLevel.Debug);

            return new WordRibbonFactory(this)
            {
                ViewModelFactory = new AutofacViewModelFactory(new AddinModule())
            };
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            Startup += ThisAddInStartup;
            Shutdown += ThisAddInShutdown;
        }

        #endregion
    }
}
