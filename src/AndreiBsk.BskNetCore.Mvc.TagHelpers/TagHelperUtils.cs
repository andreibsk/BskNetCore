using System;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AndreiBsk.BskNetCore.Mvc.TagHelpers
{
    public static class TagHelperUtils
    {
        public const string AspDisabledAttributeName = "asp-disabled";
        public const string AspDisabledHiddenAttributeName = "asp-disabled-hidden";

        public const string DisabledAttributeName = "disabled";
        public const string DisabledAttributeValue = "disabled";

        internal static void ProcessAspDisabledAttribute(this IAspDisabledTagHelper tagHelper, TagHelperOutput output)
        {
            if (output.Attributes.TryGetAttribute(DisabledAttributeName, out TagHelperAttribute attribute))
            {
                if (!tagHelper.AspDisabled)
                    output.Attributes.Remove(attribute);
            }
            else if (tagHelper.AspDisabled)
                output.Attributes.Add(DisabledAttributeName, DisabledAttributeValue);
        }

        internal static void ProcessAspDisabledHiddenAttribute(this IAspDisabledHiddenTagHelper tagHelper, TagHelperOutput output)
        {
            if (tagHelper.AspDisabledHidden)
                tagHelper.AspDisabled = true;

            ProcessAspDisabledAttribute(tagHelper, output);

            string value;
            if (tagHelper.AspDisabledHidden &&
                output.Attributes.TryGetAttribute("id", out TagHelperAttribute idAttribute) &&
                output.Attributes.TryGetAttribute("name", out TagHelperAttribute nameAttribute) &&
                !string.IsNullOrEmpty(value = tagHelper.For.Model.ToString()))
                output.PreElement.AppendFormat(
                    $"<input type=\"hidden\" id=\"{idAttribute.Value}\" name=\"{nameAttribute.Value}\" value=\"{value}\">" +
                    Environment.NewLine);
        }
    }
}
