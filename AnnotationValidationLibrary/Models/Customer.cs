using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;
using BaseDataValidatorLibrary.CommonRules;


namespace AnnotationValidationLibrary.Models
{
    public class Customer : INotifyPropertyChanged
    {
        private Country _country;
        private DateTime _birthDate;

        public int Id { get; set; }

        [Required(ErrorMessage = "{0} is required"), DataType(DataType.Text)]
        [MaxLength(12, ErrorMessage = "The {0} can not have more than {1} characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "{0} is required"), DataType(DataType.Text)]
        [MaxLength(12, ErrorMessage = "The {0} can not have more than {1} characters")]
        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public decimal CreditLimit { get; set; }

        [CreditCard]
        public string CreditCardNumber { get; set; }
        public int Discount { get; set; }
        public bool HasDiscount { get; set; }
        public string Address { get; set; }

        [ValidPostalCode]
        public string PostalCode { get; set; }

        [WeekendDateNotPermitted]
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

        [ValidPin]
        public string Pin { get; set; }

        [SocialSecurity]
        public string SocialSecurity { get; set; }

        [YearRange(maximumYear: 2022, MinimumYear = 1931, ErrorMessage = "Valid years are between {0} and {1}")]
        public DateTime BirthDate
        {
            get => _birthDate;
            set
            {
                _birthDate = value;
                OnPropertyChanged();
            }
        }

        [ListMustContainFewerThan]
        public List<string> NotesList { get; set; }

        public override string ToString() => $"{FirstName} {LastName}";


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}