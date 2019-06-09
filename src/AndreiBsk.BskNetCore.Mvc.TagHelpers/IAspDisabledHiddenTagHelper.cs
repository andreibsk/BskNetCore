using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace AndreiBsk.BskNetCore.Mvc.TagHelpers
{
    internal interface IAspDisabledHiddenTagHelper : IAspDisabledTagHelper
    {
        bool AspDisabledHidden { set; get; }
        ModelExpression For { get; set; }
    }
}
