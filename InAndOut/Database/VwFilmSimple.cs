using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InAndOut.Database
{
    [Keyless]
    public partial class VwFilmSimple
    {
        [Column("FilmID")]
        public int FilmId { get; set; }
        [StringLength(255)]
        public string FilmName { get; set; }
        public int? FilmBoxOfficeDollars { get; set; }
    }
}
