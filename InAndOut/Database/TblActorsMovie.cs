using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InAndOut.Database
{
    [Keyless]
    [Table("Tbl_Actors_Movies")]
    public partial class TblActorsMovie
    {
        [Column("FilmID")]
        public int? FilmId { get; set; }
        [Column("ActorID")]
        public int? ActorId { get; set; }

        [ForeignKey(nameof(ActorId))]
        public virtual TblActor Actor { get; set; }
        [ForeignKey(nameof(FilmId))]
        public virtual TblFilm Film { get; set; }
    }
}
