using InAndOut.Database;
using InAndOut.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace InAndOut.Services
{
    public class ActorsService : IJunctionService<TblActorsMovie,TblActor>
    {
        private IData<TblActorsMovie> _data;
        private IData<TblActor> _actor;

        public ActorsService(IData<TblActorsMovie> data,IData<TblActor> actor)
        {
            _data = data;
            _actor = actor;
        }
        public void Delete(TblActorsMovie item)
        {
            _data.Delete(item);
        }

        public TblActorsMovie Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<TblActor> getAlllist()
        {
            var list = _actor.GetList().ToList();
            return list;
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
        public TblActorsMovie Search(int FilmId, int ActorId,int oldActorId)
        {
            return getlist(FilmId).Where(item => item.ActorId == oldActorId).FirstOrDefault(); 
        }

        public void Update(int FilmId,int ActorId,int oldActorId)
        {
            var actor = Search(FilmId, ActorId,oldActorId);

            if ( actor != null)
            {
                actor.ActorId = ActorId;
                actor.FilmId = FilmId;
                _data.Update(actor);

            }
        }
    }
}
