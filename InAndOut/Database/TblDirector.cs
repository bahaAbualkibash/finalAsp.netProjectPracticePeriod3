using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InAndOut.Database
{
    [Table("tblDirector")]
    public partial class TblDirector
    {
        public TblDirector()
        {
            TblFilms = new HashSet<TblFilm>();
        }

        [Key]
        [Column("DirectorID")]
        public int DirectorId { get; set; }
        [StringLength(255)]
        public string DirectorName { get; set; }
        [Column("DirectorDOB", TypeName = "datetime")]
        public DateTime? DirectorDob { get; set; }
        [StringLength(255)]
        public string DirectorGender { get; set; }

        [InverseProperty(nameof(TblFilm.FilmDirector))]
        public virtual ICollection<TblFilm> TblFilms { get; set; }
    }
}
