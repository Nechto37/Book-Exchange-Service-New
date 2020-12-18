namespace Сервис_по_обмену_книгами.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Message")]
    public partial class Message
    {
        [Key]
        public int Message_Id { get; set; }

        public short Sender_Id { get; set; }

        public short Receiver_Id { get; set; }

        [Required]
        public string Text { get; set; }

        public DateTime Date { get; set; }

        public virtual User Sender { get; set; }

        public virtual User Receiver { get; set; }
    }
}
