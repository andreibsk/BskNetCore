using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AndreiBsk.BskNetCore.Mvc.TagHelpers
{
    [HtmlTargetElement("a", Attributes = ForAttributeName)]
    [HtmlTargetElement("div", Attributes = ForAttributeName)]
    [HtmlTargetElement("li", Attributes = ForAttributeName)]
    [HtmlTargetElement("small", Attributes = ForAttributeName)]
    [HtmlTargetElement("span", Attributes = ForAttributeName)]
    [HtmlTargetElement("strong", Attributes = ForAttributeName)]
    [HtmlTargetElement("text", Attributes = ForAttributeName)]
    [HtmlTargetElement("td", Attributes = ForAttributeName)]
    public class DisplayForTagHelper : TagHelper
    {
        private const string ForAttributeName = "asp-for";
        private readonly IViewBufferScope _bufferScope;
        private readonly ICompositeViewEngine _viewEngine;

        public DisplayForTagHelper(IViewBufferScope bufferScope, ICompositeViewEngine viewEngine)
        {
            _bufferScope = bufferScope;
            _viewEngine = viewEngine;
        }

        /// <summary>
        /// An expression to be evaluated against the current model.
        /// </summary>
        [HtmlAttributeName(ForAttributeName)]
        public ModelExpression For { get; set; }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (output == null) throw new ArgumentNullException(nameof(output));

            var builder = new TemplateBuilder(_viewEngine, _bufferScope, ViewContext, ViewContext.ViewData,
                For.ModelExplorer, For.Name, templateName: null, readOnly: true, additionalViewData: null);

            output.PreContent.SetHtmlContent(builder.Build());

            if (output.TagName == "text")
                output.TagName = null;
        }
    }
}
