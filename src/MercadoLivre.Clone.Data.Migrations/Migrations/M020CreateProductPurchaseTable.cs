using FluentMigrator;

namespace MercadoLivre.Clone.Data.Migrations
{
    [MercadoLivreMigration(20220726202942, "Criação da tabela ProductPurchase")]
    public class M020CreateProductPurchaseTable : Migration
    {
        private const string TABLE_NAME = "ProductPurchase";
        public override void Down()
        {
            Delete.Table(TABLE_NAME);
        }

        public override void Up()
        {
            Create.Table(TABLE_NAME)
                .WithColumn("Id").AsGuid().PrimaryKey()
                .WithColumn("Quantity").AsInt64().NotNullable()
                .WithColumn("Gateway").AsInt16().NotNullable()
                .WithColumn("ProductId").AsInt64().NotNullable().ForeignKey();

            Create.ForeignKey()
                .FromTable(TABLE_NAME).ForeignColumn("ProductId")
                .ToTable("Product").PrimaryColumn("Id");
        }
    }
}
//  dotnet-fm migrate -a .\MercadoLivre.Clone.Data.Migrations.dll -p SqlServer2016 -o -t local -c "Server=localhost,1433;DataBase=MercadoLivreClone;User Id=sa;Password=P@ssword42;Trusted_Connection=false"     --allowDirtyAssemblies