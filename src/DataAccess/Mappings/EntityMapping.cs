using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Domain;

namespace DataAccess.Mappings
{
    public class EntityMapping<T> : EntityTypeConfiguration<T> where T : Entity
    {
        public EntityMapping()
        {
            ToTable(typeof(T).Name);
            HasKey(mapping => mapping.Id);

            Property(prop => prop.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(prop => prop.Idx).IsRequired();
            
        }
    }
}
