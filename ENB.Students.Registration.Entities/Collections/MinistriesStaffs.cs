﻿
//using ENB.Church.Members.Entities;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ENB.Church.Members.Entities.Collections
//{
//    public class MinistriesStaffs : CollectionBase<MinistryStaff>
//    {
//        /// <summary>
//        /// Initializes a new instance of the <see cref="Operators"/> class.
//        /// </summary>
//        public MinistriesStaffs() { }

//        /// <summary>
//        /// Initializes a new instance of the <see cref="Operators"/> class.
//        /// </summary>
//        /// <param name="initialList">Accepts an IList of Person as the initial list.</param>
//        public MinistriesStaffs(IList<MinistryStaff> initialList) : base(initialList) { }

//        /// <summary>
//        /// Initializes a new instance of the <see cref="Operators"/> class.
//        /// </summary>
//        /// <param name="initialList">Accepts a CollectionBase of Person as the initial list.</param>
//        public MinistriesStaffs(CollectionBase<MinistryStaff> initialList) : base(initialList) { }

//        /// <summary>
//        /// Validates the current collection by validating each individual item in the collection.
//        /// </summary>
//        /// <returns>A IEnumerable of ValidationResult. The IEnumerable is empty when the object is in a valid state.</returns>
//        public IEnumerable<ValidationResult> Validate()
//        {
//            var errors = new List<ValidationResult>();
//            foreach (var ministryStaff in this)
//            {
//                errors.AddRange(ministryStaff.Validate());
//            }
//            return errors;
//        }
//    }
//}

