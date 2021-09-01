using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InAndOut.Database 
{
    [Table("tblGenre")]
    public partial class TblGenre
    {
        [Key]
        public long GenreId { get; set; }
        [StringLength(50)]
        public string GenreName { get; set; }
        
    }
}
