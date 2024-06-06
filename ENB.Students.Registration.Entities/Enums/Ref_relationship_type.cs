using System.ComponentModel.DataAnnotations;

namespace ENB.Students.Registration.Entities
{
    /// <summary>
    /// Determines the type of a contact record.
    /// </summary>
    public enum Ref_relationship_type
    {
        /// <summary>
        /// Indicates an unidentified value.
        /// </summary>
        None = 0,

        /// <summary>
        /// Indicates a business contact record.
        /// </summary>
        Father = 1,
        
        /// <summary>
        /// Indicates a personal contact record.
        /// </summary>
        Mother = 2
    }
}
