﻿using ENB.Students.Registration.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENB.Students.Registration.Entities.Collections
{
    public class Parents_and_Guardians : CollectionBase<Parents_and_Guardian>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Operators"/> class.
        /// </summary>
        public Parents_and_Guardians() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Operators"/> class.
        /// </summary>
        /// <param name="initialList">Accepts an IList of Person as the initial list.</param>
        public Parents_and_Guardians(IList<Parents_and_Guardian> initialList) : base(initialList) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Operators"/> class.
        /// </summary>
        /// <param name="initialList">Accepts a CollectionBase of Person as the initial list.</param>
        public Parents_and_Guardians(CollectionBase<Parents_and_Guardian> initialList) : base(initialList) { }

        /// <summary>
        /// Validates the current collection by validating each individual item in the collection.
        /// </summary>
        /// <returns>A IEnumerable of ValidationResult. The IEnumerable is empty when the object is in a valid state.</returns>
        public IEnumerable<ValidationResult> Validate()
        {
            var errors = new List<ValidationResult>();
            foreach (var physician in this)
            {
                errors.AddRange(physician.Validate());
            }
            return errors;
        }
    }
}

