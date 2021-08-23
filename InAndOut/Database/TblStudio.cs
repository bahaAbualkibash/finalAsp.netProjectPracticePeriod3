using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InAndOut.Database
{
    [Table("tblStudio")]
    public partial class TblStudio
    {
        [Key]
        [Column("StudioID")]
        public int StudioId { get; set; }
        [StringLength(255)]
        public string StudioName { get; set; }
        [Column("FilmID")]
        public int? FilmId { get; set; }

        [ForeignKey(nameof(FilmId))]
        [InverseProperty(nameof(TblFilm.TblStudios))]
        public virtual TblFilm Film { get; set; }
    }
}
