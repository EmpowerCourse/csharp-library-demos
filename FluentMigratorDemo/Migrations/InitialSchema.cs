using FluentMigrator;

namespace FluentMigratorDemo.Migrations;

[Migration(0)]
public class InitialSchema : Migration
{
    public override void Up()
    {
        Create.Table("Customers")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
            .WithColumn("Name").AsString(50).Nullable();
    }

    public override void Down()
    {
        Delete.Table("Customers");
    }
}
