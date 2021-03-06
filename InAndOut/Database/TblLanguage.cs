using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InAndOut.Database
{
    [Table("tblLanguage")]
    public partial class TblLanguage
    {
        [Key]
        [Column("LanguageID")]
        public int LanguageId { get; set; }
        [StringLength(255)]
        public string Language { get; set; }


    }
}
