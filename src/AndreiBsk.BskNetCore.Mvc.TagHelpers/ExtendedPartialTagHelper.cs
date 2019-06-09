using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AndreiBsk.BskNetCore.Mvc.TagHelpers
{
    [HtmlTargetElement("partial", Attributes = PrefixAttributeName, TagStructure = TagStructure.WithoutEndTag)]
    public class ExtendedPartialTagHelper : PartialTagHelper
    {
        private const string PrefixAttributeName = "prefix";

        public ExtendedPartialTagHelper(ICompositeViewEngine viewEngine, IViewBufferScope viewBufferScope) :
            base(viewEngine, viewBufferScope)
        { }

        /// <summary>
        /// String prefix used for html input fields.
        /// </summary>
        [HtmlAttributeName(PrefixAttributeName)]
        public string HtmlFieldPrefix { set; get; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            if (string.IsNullOrWhiteSpace(HtmlFieldPrefix))
                await base.ProcessAsync(context, output);

            string prefix = ViewContext.ViewData.TemplateInfo.HtmlFieldPrefix;
            ViewContext.ViewData.TemplateInfo.HtmlFieldPrefix += string.IsNullOrEmpty(prefix) ? HtmlFieldPrefix : $".{HtmlFieldPrefix}";
            await base.ProcessAsync(context, output);
            ViewContext.ViewData.TemplateInfo.HtmlFieldPrefix = prefix;
        }
    }
}
