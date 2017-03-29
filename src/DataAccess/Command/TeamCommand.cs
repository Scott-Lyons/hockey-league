using Domain;

namespace DataAccess.Command
{
    public interface ITeamCommand
    {
        void Add(Team team);
    }

    public class TeamCommand : ITeamCommand
    {
        private readonly IHockeyLeagueContext _hockeyLeagueContext;

        public TeamCommand(IHockeyLeagueContext hockeyLeagueContext)
        {
            _hockeyLeagueContext = hockeyLeagueContext;
        }

        public void Add(Team team)
        {
            _hockeyLeagueContext.InsertEntity(team);
            _hockeyLeagueContext.SaveChanges();
        }
    }
}
