using Todoly.Core.UIElements.Enums;

namespace Todoly.Views.WebAppPages.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class ElementAttribute : Attribute
{
    public string Name { get; set; }

    public ElementType Type { get; set; }

    public ElementAttribute(string name, ElementType type)
    {
        Name = name;
        Type = type;
    }
}

