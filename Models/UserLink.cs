using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Portofolio.Models
{
    [Table("userlinks")]
    [Index(nameof(TypeId), Name = "TypeId")]
    [Index(nameof(UserId), Name = "UserId")]
    public partial class UserLink
    {
        public UserLink()
        {
            Link = "#";
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TypeId { get; set; }
        
        [Column(TypeName = "text")]
        public string Link { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime UpdatedAt { get; set; }

        [ForeignKey(nameof(TypeId))]
        [InverseProperty(nameof(LinkType.UserLinks))]
        public virtual LinkType Type { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("UserLinks")]
        public virtual User User { get; set; }
    }
}
