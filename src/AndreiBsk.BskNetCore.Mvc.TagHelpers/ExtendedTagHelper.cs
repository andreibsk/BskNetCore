using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AndreiBsk.BskNetCore.Mvc.TagHelpers
{
    [HtmlTargetElement("button", Attributes = TagHelperUtils.AspDisabledAttributeName)]
    public class ExtendedTagHelper : TagHelper, IAspDisabledTagHelper
    {
        [HtmlAttributeName(TagHelperUtils.AspDisabledAttributeName)]
        public bool AspDisabled { set; get; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);
            this.ProcessAspDisabledAttribute(output);
        }
    }
}
