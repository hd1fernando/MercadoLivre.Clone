using FluentMigrator;


namespace MercadoLivre.Clone.Data.Migrations
{
    [Migration(2022202442, "Criação da tabela Categoria")]
    public class M010CreateCategoryTable : Migration
    {
        private string TableName = "Category";

        public override void Down()
        {
            Delete.Table(TableName);
        }

        public override void Up()
        {

            Create.Table(TableName)
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Name").AsString();
        }
    }
}
//  dotnet-fm migrate -a .\MercadoLivre.Clone.Data.Migrations.dll -p SqlServer2016 -o -t local -c "Server=localhost,1433;DataBase=MercadoLivreClone;User Id=sa;Password=P@ssword42;Trusted_Connection=false"     --allowDirtyAssemblies