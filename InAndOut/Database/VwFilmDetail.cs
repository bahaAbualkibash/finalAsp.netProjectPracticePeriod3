using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InAndOut.Database
{
    [Keyless]
    public partial class VwFilmDetail
    {
        [StringLength(255)]
        public string Certificate { get; set; }
    }
}
