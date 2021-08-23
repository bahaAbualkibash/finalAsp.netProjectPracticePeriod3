using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InAndOut.Database
{
    [Table("tblActor")]
    public partial class TblActor
    {
        public TblActor()
        {
            TblFilms = new HashSet<TblFilm>();
        }

        [Key]
        [Column("ActorID")]
        public int ActorId { get; set; }
        [StringLength(255)]
        public string ActorName { get; set; }
        [Column("ActorDOB", TypeName = "datetime")]
        public DateTime? ActorDob { get; set; }
        [StringLength(255)]
        public string ActorGender { get; set; }

        [InverseProperty(nameof(TblFilm.FilmActor))]
        public virtual ICollection<TblFilm> TblFilms { get; set; }
    }
}
