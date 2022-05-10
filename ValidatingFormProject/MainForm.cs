using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AnnotationValidationLibrary.Models;
using ValidatingFormProject.Classes;
using ValidatingFormProject.Extensions;
using WindowsFormsLibrary.Classes;

namespace ValidatingFormProject
{
    public partial class MainForm : Form
    {

        private readonly BindingSource _customerBindingSource = new();
        public MainForm()
        {
            InitializeComponent();
            Debug.WriteLine(BuildInfo.BuildDateText);
            Debug.WriteLine(BuildInfo.VersionText);

            Shown += MainForm_Shown;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            CountryComboBox.DataSource = Operations.Countries();

            // so we start-off with a valid Customer
            CountryComboBox.SelectedIndex = 1;

            SocialSecurityNumberTextBox.ToggleShow(false);

            // This sets up for binding to the sole customer
            _customerBindingSource.DataSource = Operations.Customers;

            // data bind to customer properties
            FirstNameTextBox.DataBindings.Add("Text", _customerBindingSource, nameof(Customer.FirstName));
            LastNameTextBox.DataBindings.Add("Text", _customerBindingSource, nameof(Customer.LastName));
            BirthDatePicker.DataBindings.Add("Text", _customerBindingSource, nameof(Customer.BirthDate), true, DataSourceUpdateMode.OnPropertyChanged);
            PinTextBox.DataBindings.Add("Text", _customerBindingSource, nameof(Customer.Pin));
            SocialSecurityNumberTextBox.DataBindings.Add("Text", _customerBindingSource, nameof(Customer.SocialSecurity));
            PostalCodeTextBox.DataBindings.Add("Text", _customerBindingSource, nameof(Customer.PostalCode));
            CountryComboBox.DataBindings.Add(new Binding("SelectedValue", _customerBindingSource, nameof(Customer.Country), true, DataSourceUpdateMode.OnPropertyChanged));
            CreditCardTextBox.DataBindings.Add("Text", _customerBindingSource, nameof(Customer.CreditCardNumber));
            AppointmentDateTimePicker1.DataBindings.Add("Text", _customerBindingSource, nameof(Customer.AppointmentDate));


        }

        private void ShowHidePasswordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SocialSecurityNumberTextBox.ToggleShow(ShowHidePasswordCheckBox.Checked);
        }

        private void ValidateButton_Click(object sender, EventArgs e)
        {
            try
            {
                var customer = (Customer)_customerBindingSource.Current;
                var (success, errorMessages) = ValidationOperations.IsValidCustomer(customer);
                Dialogs.Information(this, success ? "Valid" : $"Not valid\n{errorMessages}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
