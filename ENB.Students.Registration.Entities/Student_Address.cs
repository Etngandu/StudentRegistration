using ENB.Students.Registration.Infrastucture;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENB.Students.Registration.Entities
{
    public class Student_Address:  ValueObject<Student_Address>
    {
        private Student_Address()
        {
            
        }
        public Student_Address(string other_details, DateTime date_first_rental,
                   DateTime date_left_university, string number_street, string city, string zipcode,
                   string state_province_county, string country)
        {
            Other_details=other_details;
            Date_first_rental=date_first_rental;
            Date_left_university=date_left_university;
            Number_street = number_street;
            City = city;
            Zipcode = zipcode;
            State_province_county =state_province_county; 
            Country = country;
        }
        #region "Public Properties"
        public DateTime Date_first_rental { get; set; }
        public  DateTime Date_left_university { get; set; }
        public string Other_details { get; set; } = string.Empty;/// </summary>
                                                                 /// 
        public string Number_street { get; private set; }

        /// <summary>
        /// Gets or sets the City of the Customer.
        /// </summary>
        /// 
        public string City { get; private set; }
        /// <summary>
        /// Gets or sets the Zipcode of the Customer.
        /// </summary>
        /// 
        public string Zipcode { get; private set; }

        /// <summary>
        /// Gets or sets the State_province_county of the Customer.
        /// </summary>
        /// 
        public string State_province_county { get; private set; }

        /// <summary>
        /// Gets or sets the Country of the Customer.
        /// </summary>
        /// 
        public string Country { get; private set; }

        /// <summary>
        /// Determines if this address can be considered to represent a "null" value.
        /// </summary>
        // <returns>True when all four properties of the address contain null; false otherwise. 
        public bool IsNull
        {
            get
            {
                return (string.IsNullOrEmpty(Number_street) && string.IsNullOrEmpty(City) && string.IsNullOrEmpty(State_province_county)
                    && string.IsNullOrEmpty(Zipcode) && string.IsNullOrEmpty(Country) && string.IsNullOrEmpty(Other_details));
            }
        }
#endregion


        #region Methods

        /// <summary>
        /// Validates this object. 
        /// </summary>
        /// <param name="validationContext"></param>
        /// <returns>A IEnumerable of ValidationResult. The IEnumerable is empty when the object is in a valid state.</returns>
        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!IsNull)
            {

                if (string.IsNullOrEmpty(Number_street))
                {
                    yield return new ValidationResult("Number_street can't be null or empty", new[] { "Number_street" });
                }
                if (string.IsNullOrEmpty(City))
                {
                    yield return new ValidationResult("City can't be null or empty", new[] { "City" });
                }
                if (string.IsNullOrEmpty(Zipcode))
                {
                    yield return new ValidationResult("Zipcode can't be null or empty", new[] { "Zipcode" });
                }
                if (string.IsNullOrEmpty(State_province_county))
                {
                    yield return new ValidationResult("State_province_county can't be null or empty", new[] { "State_province_county" });
                }
                if (string.IsNullOrEmpty(Country))
                {
                    yield return new ValidationResult("Country can't be null or empty", new[] { "Country" });
                }
                if (string.IsNullOrEmpty(Other_details))
                {
                    yield return new ValidationResult("Other_details can't be null or empty", new[] { "Other_details" });
                }
            }
        }
        #endregion
    }
}
