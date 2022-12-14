using TrainCore.Module.Models;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using OrchardCore.ContentFields.Fields;
using TrainCore.Module.Indexes;
using YesSql.Sql;

namespace TrainCore.Module.Migrations
{
    public class CoachePartMigrations : DataMigration
    {
        private readonly IContentDefinitionManager contentDefinitionManager;

        public CoachePartMigrations(IContentDefinitionManager contentDefinitionManager)
        {
            this.contentDefinitionManager = contentDefinitionManager;
        }

        public int Create()
        {
            contentDefinitionManager.AlterPartDefinition(nameof(CoachPart), part => part
                .Attachable()
                .Reusable()
            );

            contentDefinitionManager.AlterTypeDefinition("CoachPage", type => type
                .Creatable()
                .Listable()
                .Draftable()
                .Versionable()
                .Securable()
                .WithPart(nameof(HtmlField))
            );

            SchemaBuilder.CreateMapIndexTable<BasicTrainIndex>(table => table
                .Column<string>(nameof(BasicTrainIndex.CompanyName), column => column.WithLength(16))
                .Column<string>(nameof(BasicTrainIndex.ModelEra), column => column.WithLength(10))
            );

            SchemaBuilder.AlterIndexTable<BasicTrainIndex>(table => table
                .CreateIndex($"IDX_{nameof(BasicTrainIndex)}_{nameof(BasicTrainIndex.Id)}",
                nameof(BasicTrainIndex.CompanyName))
            );

            return 5;
        }

        public int UpdateForm2()
        {
            SchemaBuilder.CreateMapIndexTable<BasicTrainIndex>(table => table
                .Column<string>(nameof(BasicTrainIndex.CompanyName), column => column.WithLength(16))
                .Column<string>(nameof(BasicTrainIndex.ModelEra), column => column.WithLength(10))
            );

            SchemaBuilder.AlterIndexTable<BasicTrainIndex>(table => table
                .CreateIndex($"IDX_{nameof(BasicTrainIndex)}_{nameof(BasicTrainIndex.Id)}",
                nameof(BasicTrainIndex.CompanyName))
            );

            return 5;
        }
    }
}
