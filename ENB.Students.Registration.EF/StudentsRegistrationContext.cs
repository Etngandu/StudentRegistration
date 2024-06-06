using System.ComponentModel.DataAnnotations;
using System.Data;
using ENB.Students.Registration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ENB.Students.Registration.EF.ConfigurationEntity;
using Microsoft.IdentityModel.Tokens;
using ENB.Students.Registration.Infrastucture;

namespace ENB.Students.Registration.EF
{
    /// <summary>
    /// This is the main DbContext to work with data in the database.
    /// </summary>
    public class StudentsRegistrationContext : IdentityDbContext<ApplicationUser>
    {
       

        public StudentsRegistrationContext(DbContextOptions<StudentsRegistrationContext>  options)
               :base(options)
        {
            
        }

        //public DbSet<Ministry>? Ministries  { get; set; }
        //public DbSet<Member>? Members  { get; set; }
        //public DbSet<Activity>? Activities { get; set; }




        /// <summary>
        /// Hooks into the Save process to get a last-minute chance to look at the entities and change them. Also intercepts exceptions and 
        /// wraps them in a new Exception type.
        /// </summary>
        /// <returns>The number of affected rows.</returns>


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            

            
            try
            {
                var modified = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified || e.State == EntityState.Added);
                foreach (EntityEntry item in modified)
                {
                    var changedOrAddedItem = item.Entity as IDateTracking;
                    if (changedOrAddedItem != null)
                    {
                        if (item.State == EntityState.Added)
                        {
                            changedOrAddedItem.DateCreated = DateTime.Now;
                        }
                        changedOrAddedItem.DateModified = DateTime.Now;
                    }
                    var valProvider = new ValidationDbContextServiceProvider(this);
                    var validationContext = new ValidationContext(item, valProvider, null);
                   // Validator.ValidateObject(item, validationContext);
                    var entityErrors = new List<ValidationResult>();
                    if (!Validator.TryValidateObject(
                        item, validationContext, entityErrors, true))
                    {
                       
                        throw new ModelValidationException("Exception", entityErrors);
                        
                    }
                }
               
            }
            catch (Exception )
            {

               // throw new ModelValidationException(result.ToString(), entityException, allErrors);
                
            }
            return base.SaveChangesAsync(cancellationToken);
        }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }



    }
}