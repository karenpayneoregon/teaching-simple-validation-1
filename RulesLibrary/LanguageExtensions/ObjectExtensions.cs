﻿using System.Collections;

namespace RulesLibrary.LanguageExtensions;

public static class ObjectExtensions
{
    public static bool IsList(this object sender)
    {
            
        if (sender == null) return false;

        return sender is IList &&
               sender.GetType().IsGenericType &&
               sender.GetType().GetGenericTypeDefinition().IsAssignableFrom(typeof(List<>));
    }
}