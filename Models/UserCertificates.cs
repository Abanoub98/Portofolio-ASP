using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Portofolio.AppModels.Utils.Constants;
namespace Portofolio.Models
{
    [Table("UserCertificates")]
    public class UserCertificates
    {

        public UserCertificates()
        {
            ImagePath = NotAssigned;
            Description = NotAssigned;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Owner is required")]
        public int UserId { get; set; }

        public string ImagePath { get; set; }

        public string Description { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(User.Certificates))]
        public virtual User Owner { get; set; }
    }
}