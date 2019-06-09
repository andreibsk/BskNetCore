using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AndreiBsk.BskNetCore.Mvc.TagHelpers
{
    internal interface IAspDisabledTagHelper : ITagHelper
    {
        bool AspDisabled { set; get; }
    }
}
