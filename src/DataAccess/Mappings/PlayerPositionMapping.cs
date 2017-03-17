using Domain;

namespace DataAccess.Mappings
{
    public class PlayerPositionMapping : EntityMapping<PlayerPosition>
    {
        public PlayerPositionMapping()
        {
            Property(prop => prop.Name).IsRequired();
        }
    }
}
