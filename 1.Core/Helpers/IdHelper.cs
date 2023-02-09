using System;

namespace Todoly.Core.Helpers;

public class IdHelper
{
    public static string GetNewId()
    {
        return Guid.NewGuid().ToString();
    }
}
