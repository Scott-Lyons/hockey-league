using Domain;

namespace DataAccess.Mappings
{
    public class PlayerMapping : EntityMapping<Player>
    {
        public PlayerMapping()
        {
            Property(prop => prop.Name).IsRequired();
            Property(prop => prop.DateOfBirth).IsRequired();
            Property(prop => prop.TimeInTeam).IsRequired();
            Property(prop => prop.PlayerPositionIdx).IsRequired();
            Property(prop => prop.TeamIdx).IsRequired();
        }
    }
}