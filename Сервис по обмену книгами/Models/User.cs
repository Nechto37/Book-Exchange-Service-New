namespace Сервис_по_обмену_книгами.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            SendedMessages = new HashSet<Message>();
            ReceivedMessages = new HashSet<Message>();
            Offers = new HashSet<Book>();
            Wishes = new HashSet<Book>();
        }

        public short Id { get; set; }

        [Column("_name")]
        [Required]
        [StringLength(20)]
        public string C_name { get; set; }

        [Required]
        [StringLength(30)]
        public string Surname { get; set; }

        [Required]
        [StringLength(30)]
        public string Login { get; set; }

        [Required]
        [StringLength(30)]
        public string Password { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date_of_birth { get; set; }

        [StringLength(15)]
        public string Phone_number { get; set; }

        [Required]
        [StringLength(50)]
        public string Settlement { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Message> SendedMessages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Message> ReceivedMessages { get; set; }

        public virtual Settlement SettlementTable { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Book> Offers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Book> Wishes { get; set; }
    }
}
