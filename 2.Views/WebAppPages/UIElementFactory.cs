using System.Reflection;
using Todoly.Core.Helpers;
using Todoly.Core.UIElements.Commons;
using Todoly.Core.UIElements.Enums;
using Todoly.Views.WebAppPages.Attributes;

namespace Todoly.Views.WebAppPages;

public class UIElementFactory
{
    private const string ViewsAssemblyName = "Todoly.Views.WebAppPages";
    private const string ElementTypeClassName = "Todoly.Core.UIElements.Web.{0}";
    private const string UIElementsAssemblyName = "Todoly.Core.UIElements";

    private static Type GetViewClassType(string viewName)
    {
        return Assembly.Load(ViewsAssemblyName).GetTypes()
                .Where(classType => classType.IsClass &&
                    classType.GetCustomAttribute<ViewAttribute>()?.Name == viewName).FirstOrDefault()!;
    }

    public static dynamic GetElement(string elementName, string viewName, string locatorArgument = "")
    {
        PropertyInfo elementInfo;
        try
        {
            var viewClassType = GetViewClassType(viewName);
            elementInfo = viewClassType.GetTypeInfo().GetProperties()
                .Where(property => property.GetCustomAttribute<ElementAttribute>()!.Name == elementName)
                .FirstOrDefault()!;
        }
        catch (ArgumentNullException error)
        {
            ConfigLogger.Error($"'{viewName}' web page doesn't exist");
            throw error;
        }

        try
        {
            ElementType elementType = elementInfo.GetCustomAttribute<ElementAttribute>()!.Type;
            string className = string.Format(ElementTypeClassName, elementType.ToString());
            Type elementClassType = Assembly.Load(UIElementsAssemblyName).GetType(className)!;

            return Activator.CreateInstance(elementClassType, new object[] { elementName, GetLocator(elementInfo, locatorArgument) })!;
        }
        catch (ArgumentNullException error)
        {
            ConfigLogger.Error($"'{elementName}' element doesn't exist in '{viewName}' view page");
            throw error;
        }
    }

    private static Locator GetLocator(PropertyInfo elementInfo, string locatorArgument = "")
    {
        LocatorAttribute locatorAttr = elementInfo.GetCustomAttributes<LocatorAttribute>().FirstOrDefault()!;
        string locator = string.Format(locatorAttr.LocatorValue, locatorArgument);
        return new Locator(locatorAttr.LocatorType, locator);
    }
}
