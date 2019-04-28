using System.Globalization;
using CleanCode;
using CleanCode.Features.ExcessiveIndentation;
using CleanCode.Resources;
using JetBrains.DocumentModel;
using JetBrains.ReSharper.Feature.Services.Daemon;
using JetBrains.ReSharper.Psi.CSharp;

[assembly: RegisterConfigurableSeverity(ExcessiveIndentHighlighting.SeverityID, null,
    CleanCodeHighlightingGroupIds.CleanCode, "Excessive indentation", "The nesting in this method is excessive.",
    Severity.WARNING)]

namespace CleanCode.Features.ExcessiveIndentation
{
    [ConfigurableSeverityHighlighting(SeverityID, CSharpLanguage.Name)]
    public class ExcessiveIndentHighlighting : IHighlighting
    {
        internal const string SeverityID = "ExcessiveIndentation";
        private readonly DocumentRange _documentRange;

        public ExcessiveIndentHighlighting(DocumentRange documentRange, int threshold, int currentValue)
        {
            ToolTip = string.Format(CultureInfo.CurrentCulture, Warnings.ExcessiveDepth, currentValue, threshold);
            _documentRange = documentRange;
        }

        public DocumentRange CalculateRange() => _documentRange;

        public string ToolTip { get; }

        public string ErrorStripeToolTip => ToolTip;

        public bool IsValid() => true;
    }
}