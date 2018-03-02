using System;
using System.Collections.Generic;
using ResPublica.Base;

namespace ResPublica.Implementation.ViewModel
{
	public class RegisterViewModel : ProjectBaseViewModel
	{

		/// <summary>
		/// Initializes a new instance of the <see cref="RegisterViewModel"/> class.
		/// </summary>
		public RegisterViewModel()
		{
			// TODO: Get Nationalities
		}

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>
		/// The name.
		/// </value>
		public string Name { get; set; } = string.Empty;

		/// <summary>
		/// Gets or sets the surname.
		/// </summary>
		/// <value>
		/// The surname.
		/// </value>
		public string Surname { get; set; } = string.Empty;

		/// <summary>
		/// Gets or sets the gender.
		/// </summary>
		/// <value>
		/// The gender.
		/// </value>
		public string Gender { get; set; }

		/// <summary>
		/// Gets or sets the nationality.
		/// </summary>
		/// <value>
		/// The nationality.
		/// </value>
		public string Nationality { get; set; } = string.Empty;

		/// <summary>
		/// Gets or sets the nationalities other.
		/// </summary>
		/// <value>
		/// The nationalities other.
		/// </value>
		public string NationalitiesOther { get; set; } = string.Empty;

		/// <summary>
		/// Gets or sets the national identifier number.
		/// </summary>
		/// <value>
		/// The national identifier number.
		/// </value>
		public string NationalIdNumber { get; set; } = string.Empty;

		/// <summary>
		/// Gets or sets the country code.
		/// </summary>
		/// <value>
		/// The country code.
		/// </value>
		public string CountryCode { get; set; } = string.Empty;

		/// <summary>
		/// Gets or sets the mobile number.
		/// </summary>
		/// <value>
		/// The mobile number.
		/// </value>
		public string MobileNumber { get; set; } = string.Empty;

		/// <summary>
		/// Gets or sets the email address.
		/// </summary>
		/// <value>
		/// The email address.
		/// </value>
		public string EmailAddress { get; set; } = string.Empty;

		/// <summary>
		/// Gets or sets the email address confirm.
		/// </summary>
		/// <value>
		/// The email address confirm.
		/// </value>
		public string EmailAddressConfirm { get; set; } = string.Empty;

		/// <summary>
		/// Gets or sets the nationalities.
		/// </summary>
		/// <value>
		/// The nationalities.
		/// </value>
		public List<string> Nationalities { get; set; } = new List<string>() { "South Africa", "Austrailia", "United States", "Other" };

		/// <summary>
		/// Gets or sets the gender types.
		/// </summary>
		/// <value>
		/// The gender types.
		/// </value>
		public List<string> GenderTypes { get; set; } = new List<string>() { GenderType.Male.ToString(), GenderType.Female.ToString(), GenderType.Other.ToString() };

		/// <summary>
		/// Gets or sets the gender other.
		/// </summary>
		/// <value>
		/// The gender other.
		/// </value>
		public string GenderOther { get; set; } = string.Empty;
	}

	public enum GenderType
	{
		Male,
		Female,
		Other
	}

}