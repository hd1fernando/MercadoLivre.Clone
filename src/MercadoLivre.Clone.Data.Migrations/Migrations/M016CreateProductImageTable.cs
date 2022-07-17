using FluentMigrator;

namespace MercadoLivre.Clone.Data.Migrations
{
    [MercadoLivreMigration(20220716211942, "Criação da tabela Productimage")]
    public class M016CreateProductImageTable : Migration
    {
        public string TableName = "ProductImage";

        public override void Down()
        {
            Delete.Table(TableName);
        }

        public override void Up()
        {
            Create.Table(TableName)
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Path").AsString().NotNullable()
                .WithColumn("ProductId").AsInt64().ForeignKey();
        }
    }
}
//  dotnet-fm migrate -a .\MercadoLivre.Clone.Data.Migrations.dll -p SqlServer2016 -o -t local -c "Server=localhost,1433;DataBase=MercadoLivreClone;User Id=sa;Password=P@ssword42;Trusted_Connection=false"     --allowDirtyAssemblies