using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AndreiBsk.BskNetCore.Mvc.TagHelpers
{
    [HtmlTargetElement("select", Attributes = TagHelperUtils.AspDisabledAttributeName)]
    [HtmlTargetElement("select", Attributes = TagHelperUtils.AspDisabledHiddenAttributeName)]
    [HtmlTargetElement("select", Attributes = AspDefaultOptionAttributeName)]
    public class ExtendedSelectTagHelper : SelectTagHelper, IAspDisabledHiddenTagHelper
    {
        public const string AspDefaultOptionAttributeName = "asp-default-option";
        private readonly IHtmlLocalizer<ExtendedSelectTagHelper> _localizer;

        public ExtendedSelectTagHelper(IHtmlGenerator generator, IHtmlLocalizer<ExtendedSelectTagHelper> localizer) : base(generator)
        {
            _localizer = localizer;
        }

        [HtmlAttributeName(AspDefaultOptionAttributeName)]
        public bool AspDefaultOption { get; set; }

        [HtmlAttributeName(TagHelperUtils.AspDisabledAttributeName)]
        public bool AspDisabled { set; get; }

        [HtmlAttributeName(TagHelperUtils.AspDisabledHiddenAttributeName)]
        public bool AspDisabledHidden { set; get; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (AspDisabled || AspDisabledHidden)
            {
                this.ProcessAspDisabledHiddenAttribute(output);
            }

            if (AspDefaultOption)
            {
                TagHelperContent initialContent = output.PostContent;

                output.PostContent.SetHtmlContent(
                    $@"<option disabled selected>{_localizer["Please select an option"]}</option>" +
                    initialContent.GetContent());
            }
        }
    }
}
