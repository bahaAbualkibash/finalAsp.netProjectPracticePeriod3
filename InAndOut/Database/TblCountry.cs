using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InAndOut.Database
{
    [Table("tblCountry")]
    public partial class TblCountry
    {
        [Key]
        [Column("CountryID")]
        public int CountryId { get; set; }
        [StringLength(255)]
        public string CountryName { get; set; }
        [Column("FilmID")]
        public int? FilmId { get; set; }

        [ForeignKey(nameof(FilmId))]
        [InverseProperty(nameof(TblFilm.TblCountries))]
        public virtual TblFilm Film { get; set; }
    }
}
