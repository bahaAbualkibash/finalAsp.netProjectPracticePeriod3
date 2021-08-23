using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InAndOut.Database
{
    [Table("tblCertificate")]
    public partial class TblCertificate
    {
        [Key]
        [Column("CertificateID")]
        public long CertificateId { get; set; }
        [StringLength(255)]
        public string Certificate { get; set; }
    }
}
