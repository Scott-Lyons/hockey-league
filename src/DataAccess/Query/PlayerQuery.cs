using System.Collections.Generic;
using System.Linq;
using Domain;

namespace DataAccess.Query
{
    public interface IPlayerQuery
    {
        IEnumerable<PlayerPosition> ListPositions();
    }

    public class PlayerQuery : IPlayerQuery
    {
        private readonly IHockeyLeagueContext _hockeyLeagueContext;

        public PlayerQuery(IHockeyLeagueContext hockeyLeagueContext)
        {
            _hockeyLeagueContext = hockeyLeagueContext;
        }

        public IEnumerable<PlayerPosition> ListPositions()
        {
            return _hockeyLeagueContext.GetEntities<PlayerPosition>().AsEnumerable();
        }
    }
}
