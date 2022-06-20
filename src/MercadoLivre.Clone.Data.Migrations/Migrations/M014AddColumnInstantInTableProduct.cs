using FluentMigrator;

namespace MercadoLivre.Clone.Data.Migrations
{
    [MercadoLivreMigration(20220620195342, "Adição da coluna Instant na tabela Product")]
    public class M014AddColumnInstantInTableProduct : Migration
    {
        private string TableName = "Product";
        public string ColumnName = "Instant";
        public override void Down()
        {
            Delete.Column(ColumnName)
                .FromTable(TableName);
        }

        public override void Up()
        {
            Alter.Table(TableName)
                .AddColumn(ColumnName)
                .AsDateTimeOffset().NotNullable();

        }
    }
}
//  dotnet-fm migrate -a .\MercadoLivre.Clone.Data.Migrations.dll -p SqlServer2016 -o -t local -c "Server=localhost,1433;DataBase=MercadoLivreClone;User Id=sa;Password=P@ssword42;Trusted_Connection=false"     --allowDirtyAssemblies