using System;
using System.Collections.Generic;
using System.Linq;
using TilesNav.Model;
using TilesNav.Model.Repos;

namespace TilesNav.Persistence.SqlServer
{
    class TileDefinitionRepository : ITileDefinitionRepository
    {
        private readonly TilesContext _ctx;
        public TileDefinitionRepository(TilesContext ctx)
        {
            _ctx = ctx;
        }
        public TileDefinition Create(TileDefinition tileDefinition)
        {
            var added = _ctx.TileDefinitions.Add(tileDefinition);
            _ctx.SaveChanges();
            return added.Entity;
        }

        public TileDefinition Delete(int id)
        {
            TileDefinition toDelete = this.Get(id);
            var deleted = _ctx.Remove(toDelete);
            _ctx.SaveChanges();
            return deleted.Entity;
        }

        public TileDefinition Get(int id)
        {
            var result = (from t in _ctx.TileDefinitions where t.ID == id select t).FirstOrDefault();
            return result;
        }

        public IEnumerable<TileDefinition> GetAll()
        {
            return _ctx.TileDefinitions;
        }

        public TileDefinition Update(TileDefinition tileDefinition)
        {
            var updated = _ctx.Update(tileDefinition);
            _ctx.SaveChanges();
            return updated.Entity;
        }
    }
}
