using FluentMigrator;

namespace MercadoLivre.Clone.Data.Migrations
{
    [MercadoLivreMigration(20220720195742, "Criação da tabela ProductReview")]
    public class M017CreateProductReviewTable : Migration
    {
        private string TABLE_NAME = "ProductReview";

        public override void Down()
        {
            Delete.Table(TABLE_NAME);
        }

        public override void Up()
        {
            Create.Table(TABLE_NAME)
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Rate").AsInt64()
                .WithColumn("Title").AsString(150)
                .WithColumn("Description").AsString(500)
                .WithColumn("ProductId").AsInt64().ForeignKey()
                .WithColumn("UserId").AsInt64().ForeignKey();
        }
    }
}
//  dotnet-fm migrate -a .\MercadoLivre.Clone.Data.Migrations.dll -p SqlServer2016 -o -t local -c "Server=localhost,1433;DataBase=MercadoLivreClone;User Id=sa;Password=P@ssword42;Trusted_Connection=false"     --allowDirtyAssemblies