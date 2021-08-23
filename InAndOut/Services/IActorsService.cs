using InAndOut.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Services
{
 public   interface IActorsService
    {
        public List<TblActorsMovie> getlist(int id);
    }
}
