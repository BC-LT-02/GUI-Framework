using System;

namespace SeleniumTest.Helpers;

public class IdHelper
{
    public static string GetNewId()
    {
        return Guid.NewGuid().ToString();
    }
}
