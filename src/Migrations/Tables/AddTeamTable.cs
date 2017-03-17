using FluentMigrator;

namespace Migrations.Tables
{
    [Migration(201702220801)]
    public class AddTeamTable : Migration
    {
        public override void Up()
        {
            Create.Table("Team")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Idx").AsGuid().Unique()
                .WithColumn("Name").AsString(100);
        }

        public override void Down()
        {
            Delete.Table("Team");
        }
    }
}
