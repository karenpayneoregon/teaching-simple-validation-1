﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

#region Required for rules used in this model
using AnnotationsTests.Rules;
using RLC = RulesLibrary.Classes;
using BaseDataValidatorLibrary.CommonRules;
#endregion

namespace AnnotationsTests.Models
{
    public class Customer : INotifyPropertyChanged
    {
        private Country _country;
        private DateTime _birthDate;

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} is required"), DataType(DataType.Text)]
        [MaxLength(12, ErrorMessage = "The {0} can not have more than {1} characters")]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "{0} is required"), DataType(DataType.Text)]
        [MaxLength(12, ErrorMessage = "The {0} can not have more than {1} characters")]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Display(Name = "Personal email address")]
        public string Email { get; set; }

        [Display(Name = "Credit limit")]
        public decimal CreditLimit { get; set; }

        [CreditCard]
        [Display(Name = "Credit card number")]
        public string CreditCardNumber { get; set; }

        [Display(Name = "Current discount")]
        public int Discount { get; set; }

        public bool HasDiscount { get; set; }

        [Display(Name = "Street")]
        public string Address { get; set; }

        [ValidPostalCode]
        [Display(Name = "Zip code")]
        public string PostalCode { get; set; }

        [RLC.WeekendDateNotPermitted]
        [Display(Prompt = "Next appointment date")]
        public DateTime AppointmentDate { get; set; }

        [Required]
        public Country Country
        {
            get => _country;
            set
            {
                _country = value;
                OnPropertyChanged();
            }
        }

        [ValidCountryName(ErrorMessage = "Country name is required")]
        public string CountryName => Country.CountryName;

        [ValidPin]
        [Display(Prompt = "Security pin")]
        public string Pin { get; set; }

        [RulesLibrary.Classes.SocialSecurity]
        [Display(Prompt = "SSN")]
        public string SocialSecurity { get; set; }

        [RLC.YearRange(maximumYear: 2022, MinimumYear = 1932)]
        [Display(Prompt = "Birth date")]
        public DateTime BirthDate
        {
            get => _birthDate;
            set
            {
                _birthDate = value;
                OnPropertyChanged();
            }
        }

        [RLC.ListMustContainFewerThan(5)]
        public List<string> NotesList { get; set; }

        public override string ToString() => $"{FirstName} {LastName}";


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}