namespace Сервис_по_обмену_книгами.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Settlement")]
    public partial class Settlement
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Settlement()
        {
            User = new HashSet<User>();
        }

        [Key]
        [StringLength(50)]
        public string Settlement_name { get; set; }

        [Required]
        [StringLength(20)]
        public string Type { get; set; }

        public long? Population { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> User { get; set; }
    }
}
