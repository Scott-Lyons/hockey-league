using Domain;

namespace DataAccess.Mappings
{
    public class TeamMapping : EntityMapping<Team>
    {
        public TeamMapping()
        {
            Property(prop => prop.Name).IsRequired();
        }
    }
}
