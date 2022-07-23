using FluentMigrator;

namespace MercadoLivre.Clone.Data.Migrations
{

    [MercadoLivreMigration(20220720200342, "Correção no tipo da coluna UserId de Int para UniqueIdentifier na tabela ProductReview")]
    public class M018FixUserIdColumnOnProductReviewTable : Migration
    {
        private const string TABLE_NAME = "ProductReview";
        private const string COLUMN_NAME = "UserId";

        public override void Down()
        {
            Delete.Column(COLUMN_NAME)
                .FromTable(TABLE_NAME);

            Alter.Table(TABLE_NAME)
               .AddColumn(COLUMN_NAME)
               .AsInt64().ForeignKey();
        }

        public override void Up()
        {
            Delete.Column(COLUMN_NAME)
                .FromTable(TABLE_NAME);

            Alter.Table(TABLE_NAME)
                .AddColumn(COLUMN_NAME)
                .AsGuid().ForeignKey();

        }
    }
}
//  dotnet-fm migrate -a .\MercadoLivre.Clone.Data.Migrations.dll -p SqlServer2016 -o -t local -c "Server=localhost,1433;DataBase=MercadoLivreClone;User Id=sa;Password=P@ssword42;Trusted_Connection=false"     --allowDirtyAssemblies
//  dotnet-fm rollback -a .\MercadoLivre.Clone.Data.Migrations.dll -p SqlServer2016 -o -t local -c "Server=localhost,1433;DataBase=MercadoLivreClone;User Id=sa;Password=P@ssword42;Trusted_Connection=false"     --allowDirtyAssemblies
