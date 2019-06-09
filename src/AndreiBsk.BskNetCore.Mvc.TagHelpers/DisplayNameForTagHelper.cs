using System;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AndreiBsk.BskNetCore.Mvc.TagHelpers
{
    [HtmlTargetElement("th", Attributes = NameForAttributeName)]
    public class DisplayNameForTagHelper : TagHelper
    {
        private const string NameForAttributeName = "asp-name-for";

        /// <summary>
        /// An expression to be evaluated against the current model.
        /// </summary>
        [HtmlAttributeName(NameForAttributeName)]
        public ModelExpression NameFor { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (output == null) throw new ArgumentNullException(nameof(output));

            int i;
            string text = NameFor.ModelExplorer.Metadata.DisplayName ?? NameFor.ModelExplorer.Metadata.PropertyName ??
                ((i = NameFor.Name.LastIndexOf('.')) == -1 ? NameFor.Name : NameFor.Name.Substring(i));
            output.PreContent.SetContent(text);
        }
    }
}
