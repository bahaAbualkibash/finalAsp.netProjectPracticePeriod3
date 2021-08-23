using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InAndOut.Database
{
    [Keyless]
    public partial class VwFilm
    {
        [StringLength(255)]
        public string FilmName { get; set; }
        [StringLength(255)]
        public string DirectorName { get; set; }
        [StringLength(255)]
        public string CountryName { get; set; }
        [StringLength(255)]
        public string Language { get; set; }
        [StringLength(255)]
        public string Certificate { get; set; }
        [StringLength(255)]
        public string StudioName { get; set; }
    }
}
