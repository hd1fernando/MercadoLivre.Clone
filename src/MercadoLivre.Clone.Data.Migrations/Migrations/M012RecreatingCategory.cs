using FluentMigrator;


namespace MercadoLivre.Clone.Data.Migrations
{
    [Migration(20220609204143, "Recriando tabela de categorias")]
    public class M012RecreatingCategory : Migration
    {
        private string TableName = "Category";

        public override void Down()
        {
            throw new System.NotImplementedException();
        }

        public override void Up()
        {
            Delete.Table(TableName);

            Create.Table(TableName)
               .WithColumn("Id").AsInt64().PrimaryKey().Identity()
               .WithColumn("Name").AsString()
               .WithColumn("ParentId").AsInt64().Nullable();
        }
    }
}
//  dotnet-fm migrate -a .\MercadoLivre.Clone.Data.Migrations.dll -p SqlServer2016 -o -t local -c "Server=localhost,1433;DataBase=MercadoLivreClone;User Id=sa;Password=P@ssword42;Trusted_Connection=false"     --allowDirtyAssemblies