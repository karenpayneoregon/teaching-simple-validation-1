using System;
using System.ComponentModel.DataAnnotations;
using AnnotationValidationLibrary.Models;

namespace AnnotationValidationLibrary.Rules
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class ValidCountryNameAttribute : ValidationAttribute
    {
        public override bool IsValid(object value) => value switch
            {
                null => false,
                Country country => country.CountryName != "Select",
                              _ => throw new ArgumentException($"Must be a {nameof(Country)}")
            };
    }
}