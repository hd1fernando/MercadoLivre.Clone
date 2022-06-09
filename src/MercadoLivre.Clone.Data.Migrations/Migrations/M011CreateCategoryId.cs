using FluentMigrator;


namespace MercadoLivre.Clone.Data.Migrations
{
    [Migration(20220609195942, "Criação do campo CategoryId para referenciar uma categoria tabela Category")]
    public class M011CreateCategoryId : Migration
    {
        private string TableName = "Category";

        public override void Down()
        {
            Delete.Column("CategoryId")
                .FromTable(TableName);
        }

        public override void Up()
        {
            Alter.Table(TableName)
                .AddColumn("CategoryId").AsInt64().Nullable()
                .WithColumnDescription("Id referente a categoria pai");
        }
    }

}
//  dotnet-fm migrate -a .\MercadoLivre.Clone.Data.Migrations.dll -p SqlServer2016 -o -t local -c "Server=localhost,1433;DataBase=MercadoLivreClone;User Id=sa;Password=P@ssword42;Trusted_Connection=false"     --allowDirtyAssemblies