namespace PhoneBookApp.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhoneNumber")]
    public partial class PhoneNumber
    {
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal PhoneNumberID { get; set; }

        [StringLength(50)]
        public string Number { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ContactId { get; set; }

        public virtual Contact Contact { get; set; }
    }
}
