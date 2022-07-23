using FluentMigrator;

namespace MercadoLivre.Clone.Data.Migrations
{
    [MercadoLivreMigration(20220723172242, "Criação da tabela ProductQuestion")]
    public class M019CreateProductQuestionTable : Migration
    {
        private const string TABLE_NAME = "ProductQuestion";

        public override void Down()
        {
            Delete.Table(TABLE_NAME);
        }

        public override void Up()
        {
            Create.Table(TABLE_NAME)
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Title").AsString().NotNullable()
                .WithColumn("QuestionDate").AsDateTime().NotNullable()
                .WithColumn("UserId").AsCustom("nvarchar(450)").NotNullable().ForeignKey()
                .WithColumn("Productid").AsInt64().NotNullable().ForeignKey();

            Create.ForeignKey()
                  .FromTable(TABLE_NAME).ForeignColumn("UserId")
                  .ToTable("AspNetUsers").PrimaryColumn("Id");

            Create.ForeignKey()
                .FromTable(TABLE_NAME).ForeignColumn("ProductId")
                .ToTable("Product").PrimaryColumn("Id");
        }
    }
}
//  dotnet-fm migrate -a .\MercadoLivre.Clone.Data.Migrations.dll -p SqlServer2016 -o -t local -c "Server=localhost,1433;DataBase=MercadoLivreClone;User Id=sa;Password=P@ssword42;Trusted_Connection=false"     --allowDirtyAssemblies