using OpenQA.Selenium;
using Todoly.Core.UIElements.Enums;

namespace Todoly.Views.WebAppPages;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
public class LocatorAttribute : Attribute
{
    public LocatorType LocatorType { get; set; }

    public string LocatorValue { get; set; }

    public LocatorAttribute(LocatorType locatorType, string locatorValue)
    {
        LocatorType = locatorType;
        LocatorValue = locatorValue;
    }
}
