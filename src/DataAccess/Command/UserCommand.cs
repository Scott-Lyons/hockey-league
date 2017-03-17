using Domain;

namespace DataAccess.Command
{
    public interface IPlayerCommand
    {
        int Add(Player player);
    }

    public class PlayerCommand : IPlayerCommand
    {
        private readonly IHockeyLeagueContext _hockeyLeagueContext;

        public PlayerCommand(IHockeyLeagueContext hockeyLeagueContext)
        {
            _hockeyLeagueContext = hockeyLeagueContext;
        }

        public int Add(Player player)
        {
            _hockeyLeagueContext.InsertEntity(player);
            _hockeyLeagueContext.SaveChanges();

            return player.Id;
        }
    }
}
