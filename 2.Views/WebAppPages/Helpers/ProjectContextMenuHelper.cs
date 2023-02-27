using System.Linq;

namespace Todoly.Views.Helpers;

public class ProjectContextMenuHelper
{
    public static string ParseButtonName(string name)
    {
        Dictionary<string, string> contextMenuOptions = new Dictionary<string, string>() {
            { "Edit", "edit" },
            { "Add item above", "add separator" },
            { "Add item below", "add" },
            { "Delete", "delete" }
        };

        string res = contextMenuOptions.GetValueOrDefault(name)!;

        if (res != null)
        {
            return res;
        }
        else
        {
            throw new ArgumentException($"Invalid context menu option: {name}");
        }
    }
}
