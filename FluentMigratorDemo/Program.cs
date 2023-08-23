using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using FluentMigratorDemo.Migrations;

var connectionString = "Data Source=.\\SQLEXPRESS;Database=Demo;Trusted_Connection=yes;";

var services = new ServiceCollection();

services.AddFluentMigratorCore()
    .ConfigureRunner(rb => rb
        .AddSqlServer2016()
        .WithGlobalConnectionString(connectionString)
        .ScanIn(typeof(InitialSchema).Assembly).For.Migrations())
    .AddLogging(lb => lb.AddFluentMigratorConsole());

IServiceProvider serviceProvider = services.BuildServiceProvider(false);

using var scope = serviceProvider.CreateScope();

var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();

runner.MigrateUp();

