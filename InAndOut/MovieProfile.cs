using AutoMapper;
using InAndOut.Database;
using InAndOut.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<TblFilm, ListMoviesViewModel>();
        }
    }
}
