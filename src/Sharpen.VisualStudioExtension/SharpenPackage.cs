﻿using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Sharpen.VisualStudioExtension.Commands;
using Sharpen.VisualStudioExtension.Commands.ContextCommands;
using Sharpen.VisualStudioExtension.ToolWindows;

namespace Sharpen.VisualStudioExtension
{
    [ProvideAutoLoad(UIContextGuids80.SolutionExists)]
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", "0.7.0", IconResourceID = 400)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(PackageGuidString)]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "pkgdef, VS and vsixmanifest are valid VS terms.")]
    [ProvideToolWindow(typeof(SharpenResultsToolWindow), Style = VsDockStyle.Tabbed, Window = "34E76E81-EE4A-11D0-AE2E-00A0C90FFFC3" /* Output Window. */)]
    public sealed class SharpenPackage : Package
    {
        public const string PackageGuidString = "01263ec2-7232-4367-a2cd-3982380b3985";

        protected override void Initialize()
        {
            SharpenExtensionService.CreateSingleInstance();

            AnalyzeSolutionCommand.Initialize(this, SharpenExtensionService.Instance);
            AnalyzeSelectedProjectsCommand.Initialize(this, SharpenExtensionService.Instance);
            
            ShowOptionsDialogCommand.Initialize(this);
            ShowSharpenResultsToolWindowCommand.Initialize(this);

            AnalyzeCurrentDocumentContextCommand.Initialize(this, SharpenExtensionService.Instance);
            AnalyzeSolutionContextCommand.Initialize(this, SharpenExtensionService.Instance);
            AnalyzeSelectedProjectsContextCommand.Initialize(this, SharpenExtensionService.Instance);
            AnalyzeSelectedDocumentsContextCommand.Initialize(this, SharpenExtensionService.Instance);
            AnalyzeSelectedFoldersContextCommand.Initialize(this, SharpenExtensionService.Instance);

            base.Initialize();
        }
    }
}