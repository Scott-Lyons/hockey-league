using System;
using FluentMigrator;

namespace Migrations.Tables
{
    [Migration(201702220800)]
    public class AddPlayerPositionTable : Migration
    {
        public override void Up()
        {
            Create.Table("PlayerPosition")
                .WithColumn("Id").AsInt32().PrimaryKey()
                .WithColumn("Idx").AsGuid().Unique()
                .WithColumn("Name").AsString(100);

            Insert.IntoTable("PlayerPosition")
                .Row(new {Id = 0, Idx = Guid.NewGuid(), Name = "Forward"})
                .Row(new {Id = 1, Idx = Guid.NewGuid(), Name = "Defence"})
                .Row(new {Id = 2, Idx = Guid.NewGuid(), Name = "Enforcer"})
                .Row(new {Id = 3, Idx = Guid.NewGuid(), Name = "Netminder"});
        }

        public override void Down()
        {
            Delete.Table("PlayerPosition");
        }
    }
}
