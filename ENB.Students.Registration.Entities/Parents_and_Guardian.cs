using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENB.Students.Registration.Entities.Collections;
using ENB.Students.Registration.Infrastucture;
using ErrorOr;


namespace ENB.Students.Registration.Entities
{
    public class Parents_and_Guardian : DomainEntity<int>,IDateTracking
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the Physician class.
        /// </summary>
        public Parents_and_Guardian( )
        {
          
            AddressParentGuardian = new Address(string.Empty,string.Empty,string.Empty,string.Empty,string.Empty);
            //StaffSkills = new();
            //MinistriesStaffs= new();
        }

        #endregion

        #region "Public Properties"

        /// <summary>
        /// Gets or sets the first name of this Customer.
        /// </summary>
        [Required]
        public string FirstName { get; set; } =string.Empty;

        /// <summary>
        /// Gets or sets the last name of this Customer.
        /// </summary>
        [Required]
        public string LastName { get; set; }=String.Empty;

      

        public string EmailAddress { get; set; } = string.Empty;

        public Gender Gender { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the Other_details of the Customer.
        /// </summary>
        /// 
        public string Other_details { get; set; } = string.Empty;

        /// <summary>
        /// Gets the full name of this person.
        /// </summary>
        public string FullName
        {
            get
            {
                string temp = FirstName ?? string.Empty;
                if (!string.IsNullOrEmpty(LastName))
                {
                    if (temp.Length > 0)
                    {
                        temp += " ";
                    }
                    temp += LastName;
                }
                return temp;
            }
        }

        

        public Address AddressParentGuardian { get; set; }

        //public StaffSkills StaffSkills  { get; set; }
        //public MinistriesStaffs MinistriesStaffs  { get; set; }
        /// <summary>
        /// Gets or sets the date and time the object was last modified.
        /// </summary>
        public DateTime DateCreated { get ; set ; }

        /// <summary>
        /// Gets or sets the date and time the object was last modified.
        /// </summary>
        /// 
        public DateTime DateModified { get ; set ; }

        public List<Error>? Errors => throw new NotImplementedException();

        public bool IsError => throw new NotImplementedException();
        #endregion

        #region Methods

        /// <summary>
        /// Validates this object. It validates dependencies between properties and also calls Validate on child collections;
        /// </summary>
        /// <param name="validationContext"></param>
        /// <returns>A IEnumerable of ValidationResult. The IEnumerable is empty when the object is in a valid state.</returns>
        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //    if (DateOfBirth < DateTime.Now.AddYears(Constants.MaxAgePerson * -1))
            //    {
            //        yield return new ValidationResult("Invalid range for DateOfBirth; must be between today and 130 years ago.", new[] { "DateOfBirth" });
            //    }
            //    if (DateOfBirth > DateTime.Now)
            //    {
            //        yield return new ValidationResult("Invalid range for DateOfBirth; must be between today and 130 years ago.", new[] { "DateOfBirth" });
            //    }
            yield return new ValidationResult("", new[] { "" });
        }
        #endregion
    }
}
