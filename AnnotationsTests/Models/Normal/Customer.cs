#region Required for rules used in this model

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using AnnotationsTests.Rules;
using BaseDataValidatorLibrary.CommonRules;

#endregion

namespace AnnotationsTests.Models.Normal
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public decimal CreditLimit { get; set; }
        public string CreditCardNumber { get; set; }
        public int Discount { get; set; }
        public bool HasDiscount { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public DateTime AppointmentDate { get; set; }
        public Country Country { get; set; }
        public string CountryName => Country.CountryName;
        public string Pin { get; set; }
        public string SocialSecurity { get; set; }
        public DateTime BirthDate { get; set; }
        public List<string> NotesList { get; set; }
    }
}