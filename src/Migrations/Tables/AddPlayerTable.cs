using FluentMigrator;

namespace Migrations.Tables
{
    [Migration(201702220839)]
    public class AddPlayerTable : Migration
    {
        public override void Up()
        {
            Create.Table("Player")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Idx").AsGuid().Unique()
                .WithColumn("Name").AsString(200)
                .WithColumn("DateOfBirth").AsDate()
                .WithColumn("TimeInTeam").AsDate()
                .WithColumn("PlayerPositionIdx").AsGuid().ForeignKey("PlayerPosition", "Idx")
                .WithColumn("TeamIdx").AsGuid().ForeignKey("Team", "Idx").Nullable();
        }

        public override void Down()
        {
            Delete.Table("Player");
        }
    }
}
