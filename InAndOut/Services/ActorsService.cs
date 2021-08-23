using InAndOut.Database;
using InAndOut.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace InAndOut.Services
{
    public class ActorsService : IActorsService
    {
        private IData<TblActorsMovie> _data;
        private IData<TblActor> _actors;

        public ActorsService(IData<TblActorsMovie> data,IData<TblActor> actor)
        {
            _data = data;
            _actors = actor;
        }
        public void Delete(int id)
        {
            
            throw new NotImplementedException();
        }

        public TblActorsMovie Get(int id)
        {
            throw new NotImplementedException();
        }



        public List<TblActorsMovie> getlist(int id)
        {
            var list = _data.GetList()
                       .Where(i => i.FilmId == id)
                       .Include(item => item.Actor).ToList();
               
            return list;
            
        }

        public void Insert(TblActorsMovie item)
        {
            
        }
        public TblActorsMovie Search(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
