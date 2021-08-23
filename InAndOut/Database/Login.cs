using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Database
{
    public class Login
    {
        [Key]
        [Column("user_id")]
        public int UserId { get; set; }
        [Required]
        [StringLength(255)]

        public string Email { get; set; }
        [Required]
        [Column("password")]
        [StringLength(50)]
        [DisplayName("Password")]

        public string Password { get; set; }
    }
}
