using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AndreiBsk.BskNetCore.Mvc.TagHelpers
{
    [HtmlTargetElement("input", Attributes = TagHelperUtils.AspDisabledAttributeName, TagStructure = TagStructure.WithoutEndTag)]
    [HtmlTargetElement("input", Attributes = TagHelperUtils.AspDisabledHiddenAttributeName, TagStructure = TagStructure.WithoutEndTag)]
    public class ExtendedInputTagHelper : InputTagHelper, IAspDisabledHiddenTagHelper
    {
        public ExtendedInputTagHelper(IHtmlGenerator generator) : base(generator)
        {
        }

        [HtmlAttributeName(TagHelperUtils.AspDisabledAttributeName)]
        public bool AspDisabled { set; get; }

        [HtmlAttributeName(TagHelperUtils.AspDisabledHiddenAttributeName)]
        public bool AspDisabledHidden { set; get; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);
            this.ProcessAspDisabledHiddenAttribute(output);
        }
    }
}
