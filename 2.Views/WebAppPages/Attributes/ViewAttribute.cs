namespace Todoly.Views.WebAppPages.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class ViewAttribute : Attribute
{
    public string Name { get; set; }

    public ViewAttribute(string name)
    {
        Name = name;
    }
}

