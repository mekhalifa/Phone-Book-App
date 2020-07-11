namespace PhoneBookApp.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PhoneBookModel : DbContext
    {
        public PhoneBookModel()
            : base("name=PhoneBookModel")
        {
        }

        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>()
                .Property(e => e.ContactId)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PhoneNumber>()
                .Property(e => e.PhoneNumberID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PhoneNumber>()
                .Property(e => e.ContactId)
                .HasPrecision(18, 0);
        }
    }
}
