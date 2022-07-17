using FluentMigrator;

namespace MercadoLivre.Clone.Data.Migrations
{

    [MercadoLivreMigration(20220628203942, "Adição da coluna UserId para referenciar usuário dono do produto.")]
    public class M015AddColumnUserIdInTableProduct : Migration
    {
        private string ColumnName = "UserId";
        private string TableName = "Product";

        public override void Down()
        {
            Delete.Column(ColumnName)
                .FromTable(TableName);
        }

        public override void Up()
        {
            Alter.Table(TableName)
                .AddColumn(ColumnName)
                .AsGuid()
                .Nullable();
        }
    }
}
//  dotnet-fm migrate -a .\MercadoLivre.Clone.Data.Migrations.dll -p SqlServer2016 -o -t local -c "Server=localhost,1433;DataBase=MercadoLivreClone;User Id=sa;Password=P@ssword42;Trusted_Connection=false"     --allowDirtyAssemblies