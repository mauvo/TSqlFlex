﻿using System;
using System.Data.SqlClient;
using RedGate.SIPFrameworkShared;

namespace TSqlFlex
{
    class RunCommand : ISharedCommand
    {
        private readonly ISsmsFunctionalityProvider6 ssmsProvider;
        private readonly ICommandImage commandImage = new CommandImageNone();
        private ObjectExplorerNodeDescriptorBase currentNode = null;

        private IToolWindow formWindow;
        private FlexMainWindow flexMainWindow;
        private Guid formGuid = new Guid("579fa20c-38cb-4da6-9f57-6651d10e31d0");

        private FlexMainWindow TheWindow()
        {
            return flexMainWindow;
        }

        public void SetSelectedDBNode(ObjectExplorerNodeDescriptorBase theSelectedNode)
        {
            currentNode = theSelectedNode;

            var objectExplorerNode = currentNode as IOeNode;
            IConnectionInfo ci = null;
            if (objectExplorerNode != null
                    && objectExplorerNode.HasConnection
                    && objectExplorerNode.TryGetConnection(out ci))
            {
                var w = TheWindow();
                if (w != null)
                {
                    w.SetConnection(new SqlConnectionStringBuilder(ci.ConnectionString));
                }
            }
        }

        public RunCommand(ISsmsFunctionalityProvider6 provider)
        {
            ssmsProvider = provider;
            if (ssmsProvider == null)
            {
                throw new ArgumentException("Could not initialize provider for RunCommand.");
            }
        }

        public void Execute()
        {
            if (formWindow == null)
            {
                flexMainWindow = new FlexMainWindow();
                formWindow = ssmsProvider.ToolWindow.Create(flexMainWindow, Caption, formGuid, true);

                try
                {
                    formWindow.Window.IsFloating = true;
                    formWindow.Window.WindowState = WindowState.Maximize;
                }
                catch (Exception ex)
                {
                    
                }
                formWindow.Window.IsFloating = false; // can't be docked
                formWindow.Window.Linkable = false;
                SetSelectedDBNode(currentNode);                
            }

            formWindow.Activate(true);
        }

        public string Name { get { return "Open_TSQL_Flex"; } }
        public string Caption { get { return "T-SQL Flex"; } }
        public string Tooltip { get { return "Runs a command for scripting"; } }
        public ICommandImage Icon { get { return commandImage; } }
        public string[] DefaultBindings { get { return new string[] {}; } }
        public bool Visible { get { return true; } }
        public bool Enabled { get { return true; } }
    }
}
