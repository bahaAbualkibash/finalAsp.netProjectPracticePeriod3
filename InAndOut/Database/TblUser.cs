using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InAndOut.Database
{
    [Table("TblUser")]
    public partial class TblUser
    {
        [Key]
        [Column("user_id")]
        public int UserId { get; set; }
        [Required]
        [Column("username")]
        [StringLength(50)]
        public string Username { get; set; }
        [Required]
        [StringLength(255)]
        public string Email { get; set; }
        [Required]
        [Column("password")]
        [StringLength(50)]
        public string Password { get; set; }
        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }
        [Column("userImage", TypeName = "image")]
        public byte[] UserImage { get; set; }
        [Column("FilmID")]
        public int? FilmId { get; set; }

        [ForeignKey(nameof(FilmId))]
        [InverseProperty(nameof(TblFilm.TblUsers))]
        public virtual TblFilm Film { get; set; }
    }
}
