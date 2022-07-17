using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
#nullable disable

namespace Portofolio.Models
{
    [Table("contacts")]
    [Index(nameof(StatusId), Name = "StatusId")]
    public partial class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int StatusId { get; set; }
        [Required]
        [StringLength(100)]
        [RegularExpression("([a-z]| |[A-Z])+", ErrorMessage = "Please enter a valid name, no digits are allowed")]
        public string ContactName { get; set; }
        [Required]
        [StringLength(15)]
        [Phone]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Required]
        [StringLength(320)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Column(TypeName = "text")]
        public string Message { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime UpdatedAt { get; set; }

        [ForeignKey(nameof(StatusId))]
        [InverseProperty(nameof(ContactStatus.Contacts))]
        public virtual ContactStatus Status { get; set; }

        [InverseProperty(nameof(RequestedService.AssociatedContact))]
        public virtual ICollection<RequestedService> RequestedServices { get; set; }

    }
}
