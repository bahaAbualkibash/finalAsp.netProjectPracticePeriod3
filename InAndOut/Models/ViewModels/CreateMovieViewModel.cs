using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Models.ViewModels
{
    public class CreateMovieViewModel
    {
        [Key]
        [Required]
        public int MovieId { get; set; }

        [Required]
        [Display(Name ="Enter Movie Name")]
        public string MovieName { get; set; }
        [Required]
        [Display(Name = "Enter Movie Release Year")]

        public string MovieYearOfRelease { get; set; }
        [Required]
        [Display(Name = "Enter Movie Pirce")]

        public string MoviePrice { get; set; }

    }
}
