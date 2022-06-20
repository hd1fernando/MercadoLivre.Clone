using FluentMigrator;

namespace MercadoLivre.Clone.Data.Migrations
{
    [MercadoLivreMigration(20220620193842, "Criação da tabela Product")]
    public class M013CreateProduct : Migration
    {
        private string TableName = "Product";
        public override void Down()
        {
            Delete.Table(TableName);
        }

        public override void Up()
        {
            Create.Table(TableName)
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("Price").AsDecimal(12, 2).NotNullable()
                .WithColumn("AvailableQuantity").AsInt64().NotNullable()
                .WithColumn("Features").AsString().NotNullable()
                .WithColumn("Description").AsString()
                .WithColumn("CategoryId ").AsInt64().NotNullable().ForeignKey("Category", "Id");
        }
    }
}
//  dotnet-fm migrate -a .\MercadoLivre.Clone.Data.Migrations.dll -p SqlServer2016 -o -t local -c "Server=localhost,1433;DataBase=MercadoLivreClone;User Id=sa;Password=P@ssword42;Trusted_Connection=false"     --allowDirtyAssemblies