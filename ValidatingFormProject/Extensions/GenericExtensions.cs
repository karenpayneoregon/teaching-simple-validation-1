﻿
using Customer = ValidatingFormProject.Models.Customer;

namespace ValidatingFormProject.Extensions;

public static class GenericExtensions
{

    public static void ToggleShow(this TextBox sender, bool show = true)
    {
        sender.PasswordChar = show ?
            '\0' :
            '\u25CF';
    }

    /// <summary>
    /// Is the instance of a class null
    /// </summary>
    /// <typeparam name="T">Concrete class type</typeparam>
    /// <param name="senderInstance">Instance of concrete class</param>
    /// <returns>True if null, false if not null</returns>
    public static bool IsNull<T>(this T senderInstance) where T : new() => senderInstance is null;

    /// <summary>
    /// Is the instance of a class not null
    /// </summary>
    /// <typeparam name="T">Concrete class type</typeparam>
    /// <param name="senderInstance">Instance of concrete class</param>
    /// <returns>True if not null, false if null</returns>
    public static bool IsNotNull<T>(this T senderInstance) where T : new() => !senderInstance.IsNull();

    public static Customer Customer(this BindingSource bindingSource) => (Customer)bindingSource.Current;
}