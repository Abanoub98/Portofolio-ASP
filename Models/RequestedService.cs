using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portofolio.Models
{
    public class RequestedService
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int ServiceId { get; set; }

        public int ContactId { get; set; }

        public DateTime UpdatedAt {get; set;}

        public DateTime CreatedAt {get; set;}

        [ForeignKey(nameof(ContactId))]
        [InverseProperty(nameof(Contact.RequestedServices))]
        public virtual Contact AssociatedContact { get; set; }

        [ForeignKey(nameof(ServiceId))]
        [InverseProperty(nameof(Service.Requests))]

        public virtual Service AssociatedService { get; set; }
    }
}