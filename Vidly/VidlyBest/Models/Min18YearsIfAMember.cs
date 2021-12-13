using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyBest.Models
{
	public class Min18YearsIfAMember : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			var customer = (Customer)validationContext.ObjectInstance;

			if (customer.MembershipTypeId == MembershipType.Unknown || 
				customer.MembershipTypeId == MembershipType.PayAsYouGo)
				return ValidationResult.Success;

			if (customer.Birthdate == null)
				return new ValidationResult("Data urodzenia jest wymagana.");

			var age = DateTime.Today.Year - customer.Birthdate.Value.Year;

			return (age >= 18) 
				? ValidationResult.Success 
				: new ValidationResult("Użytkownik powinien ukończyć 18 lat aby dołączyć do tego typu członkostwa. " +
				"Wybierz członkostwo 'Pay as You Go'");
			// Pay as You Go, bo wyżej customer.MembershipTypeId == 1, a w tabeli pod id == 1 jest członkostwo Pay as You Go
		}
	}
}