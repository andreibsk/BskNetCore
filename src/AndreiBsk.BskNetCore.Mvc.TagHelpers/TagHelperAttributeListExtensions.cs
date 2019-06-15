using System;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AndreiBsk.BskNetCore.Mvc.TagHelpers
{
    public static class TagHelperAttributeListExtensions
    {
        public static bool AddClass(this TagHelperAttributeList attributes, string className)
        {
            if (string.IsNullOrWhiteSpace(className))
                throw new ArgumentNullException(nameof(className));

            if (!attributes.TryGetAttribute("class", out TagHelperAttribute classAttribute))
            {
                attributes.Add(new TagHelperAttribute("class", className));
                return true;
            }

            if (attributes.ContainsClass(className))
                return false;

            string classes = classAttribute.Value.ToString();
            attributes.SetAttribute("class", string.Join(" ", className, classes));
            return true;
        }

        public static bool ContainsClass(this TagHelperAttributeList attributes, string className)
        {
            if (string.IsNullOrWhiteSpace(className))
                throw new ArgumentOutOfRangeException(nameof(className), "The class name must not be null or white space.");

            if (!attributes.TryGetAttribute("class", out TagHelperAttribute classAttribute))
                return false;

            string classes = classAttribute.Value.ToString();

            for (int i = 0; i + className.Length <= classes.Length; i++)
            {
                // Find className
                i = classes.IndexOf(className, i);
                if (i == -1)
                    return false;

                // Ensure word boundaries
                if ((i == 0 || char.IsWhiteSpace(classes[i - 1]))
                    && (i + className.Length == classes.Length || char.IsWhiteSpace(classes[i + className.Length])))
                    return true;
            }

            return false;
        }
    }
}
