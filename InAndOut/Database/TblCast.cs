using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InAndOut.Database
{
    [Table("tblCast")]
    public partial class TblCast
    {
        [Key]
        [Column("CastID")]
        public int CastId { get; set; }
        [Column("CastFilmID")]
        public int? CastFilmId { get; set; }
        [Column("CastActorID")]
        public int? CastActorId { get; set; }
        [StringLength(255)]
        public string CastCharacterName { get; set; }
        [Column("FilmID")]
        public int? FilmId { get; set; }

        [ForeignKey(nameof(FilmId))]
        [InverseProperty(nameof(TblFilm.TblCasts))]
        public virtual TblFilm Film { get; set; }
    }
}
