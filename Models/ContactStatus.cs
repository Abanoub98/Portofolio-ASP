using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Portofolio.Models
{
    [Table("contactstatuses")]
    [Index(nameof(Status), Name = "Status", IsUnique = true)]
    public partial class ContactStatus
    {
        public ContactStatus()
        {
            Contacts = new HashSet<Contact>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Status { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime UpdatedAt { get; set; }

        [InverseProperty(nameof(Contact.Status))]
        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
